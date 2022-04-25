using System;
using System.Windows.Forms;
using UniversalTemplateForDB.Views.Interfaces;

namespace UniversalTemplateForDB.Views.Forms
{
    public partial class MaterialView : Form, IMaterialView
    {
        private bool _isEdit;
        private bool _isSuccessful;
        private string _message;

        public MaterialView()
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

        public string MaterialId 
        { 
            get => IDTB.Text; 
            set => IDTB.Text = value; 
        }
        public string ProductId 
        {
            get => IdProductTB.Text;
            set => IdProductTB.Text = value; 
        }
        public string MaterialName 
        {
            get => NameTB.Text; 
            set => NameTB.Text = value;
        }
        public string MaterialPrice
        { 
            get => PriceTB.Text; 
            set => PriceTB.Text = value;
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

        public void SetMaterialListBindingSource(BindingSource materialList)
        {
            dataGridView.DataSource = materialList;
        }

        private static MaterialView _instance;
        internal static MaterialView GetInstance(Form parentForm)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new MaterialView()
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
