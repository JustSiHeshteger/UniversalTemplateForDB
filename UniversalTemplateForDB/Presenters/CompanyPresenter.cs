using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UniversalTemplateForDB.Models.Model;
using UniversalTemplateForDB.Models.Repositories;
using UniversalTemplateForDB.Views.Interfaces;

namespace UniversalTemplateForDB.Presenters
{
    internal class CompanyPresenter
    {
        private readonly ICompanyView _view;
        private readonly ICompanyRepository _repository;
        private readonly BindingSource _bindingSource;
        private IEnumerable<CompanyModel> _companyList;

        public CompanyPresenter(ICompanyView view, ICompanyRepository repository)
        {
            this._bindingSource = new BindingSource();
            this._view = view;
            this._repository = repository;

            this._view.SearchEvent += SearchCompany;
            this._view.AddEvent += AddCompany;
            this._view.EditEvent += EditCompany;
            this._view.DeleteEvent += DeleteCompany;
            this._view.SaveEvent += SaveCompany;
            this._view.CancelEvent += CancelAction;

            this._view.SetCompanyListBindingSource(_bindingSource);

            LoadAllCompanyList();

            this._view.Show();
        }

        private void LoadAllCompanyList()
        {
            _companyList = _repository.GetAll();
            _bindingSource.DataSource = _companyList;
        }

        #region События
        private void CancelAction(object sender, EventArgs e)
        {
            
        }

        private void SaveCompany(object sender, EventArgs e)
        {
            try
            {
                var model = new CompanyModel()
                {
                    Id = int.TryParse(_view.CompanyId, out _) ? Convert.ToInt32(_view.CompanyId) : 0,
                    NameCompany = _view.NameCompany,
                    Address = _view.Address,
                    Phone = int.TryParse(_view.Phone, out _) ? Convert.ToInt32(_view.Phone) : 0,
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
                LoadAllCompanyList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void DeleteCompany(object sender, EventArgs e)
        {
            try
            {
                if (_bindingSource.Current == null)
                    return;

                var item = (CompanyModel)_bindingSource.Current;
                _repository.Delete(item.Id);
                _view.IsSuccessful = true;
                LoadAllCompanyList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void EditCompany(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
                return;

            var item = (CompanyModel)_bindingSource.Current;
            _view.CompanyId = item.Id.ToString();
            _view.NameCompany = item.NameCompany.ToString();
            _view.Address = item.Address.ToString();
            _view.Phone = item.Phone.ToString();

            _view.IsEdit = true;
        }

        private void AddCompany(object sender, EventArgs e)
        {
            _view.IsEdit = false;
        }

        private void SearchCompany(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this._view.SearchValue))
                _companyList = _repository.GetByValue(this._view.SearchValue);
            else
                _companyList = _repository.GetAll();

            _bindingSource.DataSource = _companyList;

        }

        #endregion
    }
}
