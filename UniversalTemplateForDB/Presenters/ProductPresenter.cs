using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using UniversalTemplateForDB.Models.Model;
using UniversalTemplateForDB.Models.Repositories;
using UniversalTemplateForDB.Views.Interfaces;

namespace UniversalTemplateForDB.Presenters
{
    internal class ProductPresenter
    {
        private readonly IProductView _view;
        private readonly IProductRepository _repository;
        private readonly BindingSource _bindingSource;
        private DataTable _productList;

        public ProductPresenter(IProductView view, IProductRepository repository)
        {
            this._view = view;
            this._repository = repository;
            this._bindingSource = new BindingSource();

            this._view.SearchEvent += SearchProduct;
            this._view.AddEvent += AddProduct;
            this._view.EditEvent += EditProduct;
            this._view.DeleteEvent += DeleteProduct;
            this._view.SaveEvent += SaveProduct;
            this._view.CancelEvent += CancelAction;
            this._view.AddColumnEvent += AddColumn;
            this._view.DropColumnEvent += DropColumn;

            this._view.SetProductListBindingSource(_bindingSource);

            LoadAllProductList();

            this._view.Show();
        }

        private void AddColumn(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_view.AddColumn))
            {
                _repository.AddColumn(_view.AddColumn);
                LoadAllProductList();
            }
        }

        private void DropColumn(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_view.AddColumn))
            {
                _repository.DropColumn(_view.AddColumn);
                LoadAllProductList();
            }
        }

        private void LoadAllProductList()
        {
            _productList = _repository.GetAll();
            _bindingSource.DataSource = _productList;
        }

        private void SearchProduct(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_view.SearchValue))
                _productList = _repository.GetByValue(_view.SearchValue);
            else
                _productList = _repository.GetAll();

            _bindingSource.DataSource = _productList;
        }

        private void AddProduct(object sender, EventArgs e)
        {
            _view.IsEdit = false;
        }

        private void EditProduct(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
                return;

            var item = (ProductModel)_bindingSource.Current;
            _view.ProductId = item.Id.ToString();
            _view.MasterId = item.IdMaster.ToString();
            _view.CompanyId = item.IdCompany.ToString();
            _view.ProductName = item.NameProduct.ToString();
            _view.ProductInfo = item.Info.ToString();

            _view.IsEdit = true;
        }

        private void DeleteProduct(object sender, EventArgs e)
        {
            try
            {
                if (_bindingSource.Current == null)
                    return;

                var item = (ProductModel)_bindingSource.Current;
                _repository.Delete(item.Id);
                _view.IsSuccessful = true;
                LoadAllProductList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void SaveProduct(object sender, EventArgs e)
        {
            try
            {
                var model = new ProductModel()
                {
                    Id = int.TryParse(_view.ProductId, out _) ? Convert.ToInt32(_view.ProductId) : 0,
                    IdCompany = int.TryParse(_view.CompanyId, out _) ? Convert.ToInt32(_view.CompanyId) : 0,
                    IdMaster = int.TryParse(_view.MasterId, out _) ? Convert.ToInt32(_view.MasterId) : 0,
                    NameProduct = _view.ProductName,
                    Info = _view.ProductInfo
                };

                new Base.DataValidation().Validate(model);
                if (_view.IsEdit)
                {
                    _repository.Edit(model);
                }
                else
                {
                    _repository.Add(model);
                }
                _view.IsSuccessful = true;
                LoadAllProductList();
                ClearFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void CancelAction(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            _view.ProductId = "0";
            _view.ProductName = "";
            _view.CompanyId = "0";
            _view.MasterId = "0";
            _view.ProductInfo = "";
        }
    }
}
