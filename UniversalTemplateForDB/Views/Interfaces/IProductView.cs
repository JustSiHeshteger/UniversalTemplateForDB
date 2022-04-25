using System;
using System.Windows.Forms;

namespace UniversalTemplateForDB.Views.Interfaces
{
    internal interface IProductView
    {
        #region Свойства

        string ProductId { get; set; }
        string ProductName { get; set; }
        string MasterId { get; set; }
        string CompanyId { get; set; }
        string ProductInfo { get; set; }


        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        #endregion


        #region События

        event EventHandler SearchEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        #endregion


        #region Методы

        void SetProductListBindingSource(BindingSource ProductList);
        void Show();

        #endregion
    }
}
