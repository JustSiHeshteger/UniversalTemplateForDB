using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalTemplateForDB.Models.Repositories;
using UniversalTemplateForDB.Repositories;
using UniversalTemplateForDB.Views.Forms;
using UniversalTemplateForDB.Views.Interfaces;

namespace UniversalTemplateForDB.Presenters
{
    internal class MainPresenter
    {
        private readonly IMainView _mainView;
        private readonly string _sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this._mainView = mainView;
            this._sqlConnectionString = sqlConnectionString;
            this._mainView.ShowCompanyView += ShowCompanyView;
            this._mainView.ShowMasterView += ShowMasterView;
            this._mainView.ShowMaterialView += ShowMaterialView;
            this._mainView.ShowProductView += ShowProductView;
        }

        private void ShowProductView(object sender, EventArgs e)
        {
            IProductView view = ProductView.GetInstance((MainForm)_mainView);
            IProductRepository repository = new ProductRepository(_sqlConnectionString);
            new ProductPresenter(view, repository);
        }

        private void ShowCompanyView(object sender, EventArgs e)
        {
            ICompanyView view = CompanyView.GetInstance((MainForm)_mainView);
            ICompanyRepository repository = new CompanyRepository(_sqlConnectionString);
            new CompanyPresenter(view, repository);
        }

        private void ShowMasterView(object sender, EventArgs e)
        {
            IMasterView view = MasterView.GetInstance((MainForm)_mainView);
            IMasterRepository repository = new MasterRepository(_sqlConnectionString);
            new MasterPresenter(view, repository);
        }

        private void ShowMaterialView(object sender, EventArgs e)
        {
            IMaterialView view = MaterialView.GetInstance((MainForm)_mainView);
            IMaterialRepository repository = new MaterialRepository(_sqlConnectionString);
            new MaterialPresenter(view, repository);
        }
    }
}
