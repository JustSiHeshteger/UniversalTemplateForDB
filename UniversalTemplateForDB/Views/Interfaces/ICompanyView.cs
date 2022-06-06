using System;
using System.Windows.Forms;

namespace UniversalTemplateForDB.Views.Interfaces
{
    internal interface ICompanyView
    {
        #region Свойства

        string CompanyId { get; set; }
        string NameCompany { get; set; }
        string Address { get; set; }
        string Phone { get; set; }


        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string AddColumn { get; set; }

        #endregion


        #region События

        event EventHandler SearchEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler AddColumnEvent;
        event EventHandler DropColumnEvent;

        #endregion


        #region Методы

        void SetCompanyListBindingSource(BindingSource CompanyList);
        void Show();

        #endregion
    }
}
