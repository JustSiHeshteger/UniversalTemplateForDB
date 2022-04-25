using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalTemplateForDB.Views;
using UniversalTemplateForDB.Views.Interfaces;

namespace UniversalTemplateForDB
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();

            CompanyBtn.Click += delegate { ShowCompanyView?.Invoke(this, EventArgs.Empty); };
            MasterBtn.Click += delegate { ShowMasterView?.Invoke(this, EventArgs.Empty); };
            MaterialBtn.Click += delegate { ShowMaterialView?.Invoke(this, EventArgs.Empty); };
            ProductBtn.Click += delegate { ShowProductView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowCompanyView;
        public event EventHandler ShowMasterView;
        public event EventHandler ShowMaterialView;
        public event EventHandler ShowProductView;
    }
}
