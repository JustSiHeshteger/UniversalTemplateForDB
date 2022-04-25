using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalTemplateForDB.Models.Model;
using UniversalTemplateForDB.Models.Repositories;
using UniversalTemplateForDB.Views.Interfaces;

namespace UniversalTemplateForDB.Presenters
{
    internal class MaterialPresenter
    {
        private readonly IMaterialView _view;
        private readonly IMaterialRepository _repository;
        private readonly BindingSource _bindingSource;
        private IEnumerable<MaterialModel> _materialList;

        public MaterialPresenter(IMaterialView view, IMaterialRepository repository)
        {
            this._view = view;
            this._repository = repository;
            this._bindingSource = new BindingSource();

            this._view.SearchEvent += SearchMaterial;
            this._view.AddEvent += AddMaterial;
            this._view.EditEvent += EditMaterial;
            this._view.DeleteEvent += DeleteMaterial;
            this._view.SaveEvent += SaveMaterial;
            this._view.CancelEvent += CancelAction;

            this._view.SetMaterialListBindingSource(_bindingSource);

            LoadAllMaterialList();

            this._view.Show();
        }

        private void LoadAllMaterialList()
        {
            _materialList = _repository.GetAll();
            _bindingSource.DataSource = _materialList;
        }

        private void SearchMaterial(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_view.SearchValue))
                _materialList = _repository.GetByValue(_view.SearchValue);
            else
                _materialList = _repository.GetAll();

            _bindingSource.DataSource = _materialList;
        }

        private void AddMaterial(object sender, EventArgs e)
        {
            _view.IsEdit = false;
        }

        private void EditMaterial(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
                return;

            var item = (MaterialModel)_bindingSource.Current;
            _view.MaterialId = item.IdMaterial.ToString();
            _view.ProductId = item.IdProduct.ToString();
            _view.MaterialName = item.NameMaterial.ToString();
            _view.MaterialPrice = item.Price.ToString();

            _view.IsEdit = true;
        }

        private void DeleteMaterial(object sender, EventArgs e)
        {
            try
            {
                if (_bindingSource.Current == null)
                    return;

                var item = (MaterialModel)_bindingSource.Current;
                _repository.Delete(item.IdMaterial);
                _view.IsSuccessful = true;
                LoadAllMaterialList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void SaveMaterial(object sender, EventArgs e)
        {
            try
            {
                var model = new MaterialModel()
                {
                    IdMaterial = int.TryParse(_view.MaterialId, out _) ? Convert.ToInt32(_view.MaterialId) : 0,
                    IdProduct = int.TryParse(_view.ProductId, out _) ? Convert.ToInt32(_view.ProductId) : 0,
                    NameMaterial = _view.MaterialName,
                    Price = int.TryParse(_view.MaterialPrice, out _) ? Convert.ToInt32(_view.MaterialPrice) : 0,
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
                LoadAllMaterialList();
                ClearFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void ClearFields()
        {
            _view.MaterialId = "0";
            _view.ProductId = "0";
            _view.MaterialName = "";
            _view.MaterialPrice = "0";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
