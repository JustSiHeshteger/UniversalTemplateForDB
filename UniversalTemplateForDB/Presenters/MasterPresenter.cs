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
    internal class MasterPresenter
    {
        private readonly IMasterView _view;
        private readonly IMasterRepository _repository;
        private readonly BindingSource _bindingSource;
        private IEnumerable<MasterModel> _masterList;

        public MasterPresenter(IMasterView view, IMasterRepository repository)
        {
            this._view = view;
            this._repository = repository;
            this._bindingSource = new BindingSource();

            this._view.SearchEvent += SearchMaster;
            this._view.AddEvent += AddMaster;
            this._view.EditEvent += EditMaster;
            this._view.DeleteEvent += DeleteMaster;
            this._view.SaveEvent += SaveMaster;
            this._view.CancelEvent += CancelAction;

            this._view.SetMasterListBindingSource(_bindingSource);

            LoadAllMasterList();

            this._view.Show();
        }

        private void LoadAllMasterList()
        {
            _masterList = _repository.GetAll();
            _bindingSource.DataSource = _masterList;
        }

        private void SearchMaster(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_view.SearchValue))
                _masterList = _repository.GetByValue(_view.SearchValue);
            else
                _masterList = _repository.GetAll();

            _bindingSource.DataSource = _masterList;
        }

        private void AddMaster(object sender, EventArgs e)
        {
            _view.IsEdit = false;
        }

        private void EditMaster(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
                return;

            var item = (MasterModel)_bindingSource.Current;
            _view.MasterId = item.Id.ToString();
            _view.MasterName = item.Name.ToString();
            _view.MasterSecondName = item.SecondName.ToString();
            _view.MasterExperience = item.Experience.ToString();

            _view.IsEdit = true;
        }

        private void DeleteMaster(object sender, EventArgs e)
        {
            try
            {
                if (_bindingSource.Current == null)
                    return;

                var item = (CompanyModel)_bindingSource.Current;
                _repository.Delete(item.Id);
                _view.IsSuccessful = true;
                LoadAllMasterList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void SaveMaster(object sender, EventArgs e)
        {
            try
            {
                var model = new MasterModel()
                {
                    Id = int.TryParse(_view.MasterId, out _) ? Convert.ToInt32(_view.MasterId) : 0,
                    Name = _view.MasterName,
                    SecondName = _view.MasterSecondName,
                    Experience = int.TryParse(_view.MasterExperience, out _) ? Convert.ToInt32(_view.MasterExperience) : 0,
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
                LoadAllMasterList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void CancelAction(object sender, EventArgs e)
        {
        }
    }
}
