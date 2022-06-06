using System;
using System.Windows.Forms;

namespace UniversalTemplateForDB.Views.Interfaces
{
    internal interface IMasterView
    {
        #region Свойства

        string MasterId { get; set; }
        string MasterName { get; set; }
        string MasterSecondName { get; set; }
        string MasterExperience { get; set; }


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

        void SetMasterListBindingSource(BindingSource MasterList);
        void Show();

        #endregion
    }
}
