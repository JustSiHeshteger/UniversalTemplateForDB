using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalTemplateForDB.Views.Interfaces;

namespace UniversalTemplateForDB.Views.Forms
{
    public partial class ProductView : Form, IProductView
    {
        private bool _isEdit;
        private bool _isSuccessful;
        private string _message;

        public ProductView()
        {
            InitializeComponent();
            AssociateViewEvents();
            tabControl1.TabPages.Remove(Info);
        }

        private void AssociateViewEvents()
        {
            SearchBtn.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            SearchTB.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            AddBtn.Click += delegate {
                AddEvent?.Invoke(this, EventArgs.Empty);
                IDTB.Text = "0";
                tabControl1.TabPages.Remove(Main);
                tabControl1.TabPages.Add(Info);
                Info.Text = "Добавить";
            };

            EditBtn.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(Main);
                tabControl1.TabPages.Add(Info);
                Info.Text = "Редактировать";
            };

            DeleteBtn.Click += delegate
            {
                var operation = MessageBox.Show("Вы действительно хотите удалить данный элемент?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (operation == DialogResult.Yes)
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
            };

            SaveBtn.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (_isSuccessful)
                {
                    tabControl1.TabPages.Add(Main);
                    tabControl1.TabPages.Remove(Info);
                }
            };

            CancelBtn.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Add(Main);
                tabControl1.TabPages.Remove(Info);
            };
        }

        public string ProductId 
        { 
            get => IDTB.Text; 
            set => IDTB.Text = value; 
        }
        string IProductView.ProductName 
        { 
            get => NameTB.Text; 
            set => NameTB.Text = value; 
        }
        public string MasterId
        { 
            get => IdMasterTB.Text; 
            set => IdMasterTB.Text = value; 
        }
        public string CompanyId 
        { 
            get => IdCompanyTB.Text;
            set => IdCompanyTB.Text = value;
        }
        public string ProductInfo
        {
            get => InfoTB.Text;
            set => InfoTB.Text = value;
        }
        public string SearchValue 
        {
            get => SearchTB.Text; 
            set => SearchTB.Text = value; 
        }
        public bool IsEdit
        { 
            get => _isEdit;
            set => _isEdit = value; 
        }
        public bool IsSuccessful 
        {
            get => _isSuccessful;
            set => _isSuccessful = value; 
        }
        public string Message 
        {
            get => _message; 
            set => _message = value;
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetProductListBindingSource(BindingSource productList)
        {
            dataGridView.DataSource = productList;
        }

        private static ProductView _instance;

        public static ProductView GetInstance(Form parentForm)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new ProductView()
                {
                    MdiParent = parentForm
                };
            }
            else
            {
                if (_instance.WindowState == FormWindowState.Minimized)
                    _instance.WindowState = FormWindowState.Normal;
                _instance.BringToFront();
            }

            return _instance;
        }
    }
}
