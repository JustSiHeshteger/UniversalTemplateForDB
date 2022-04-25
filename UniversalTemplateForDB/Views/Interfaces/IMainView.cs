using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalTemplateForDB.Views.Interfaces
{
    public interface IMainView
    {
        event EventHandler ShowCompanyView;
        event EventHandler ShowMasterView;
        event EventHandler ShowMaterialView;
        event EventHandler ShowProductView;
    }
}
