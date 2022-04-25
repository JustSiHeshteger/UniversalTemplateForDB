using System;
using System.Windows.Forms;

namespace UniversalTemplateForDB.Views.Interfaces
{
    internal interface IMaterialView
    {
        #region Свойства

        string MaterialId { get; set; }
        string ProductId { get; set; }
        string MaterialName { get; set; }
        string MaterialPrice { get; set; }


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

        void SetMaterialListBindingSource(BindingSource MaterialList);
        void Show();

        #endregion
    }
}
