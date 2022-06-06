using System;
using System.Windows.Forms;
using UniversalTemplateForDB.Views.Interfaces;

namespace UniversalTemplateForDB.Views.Forms
{
    public partial class CompanyView : Form, ICompanyView
    {
        private string _message;
        private bool _isSuccessful;
        private bool _isEdit;

        public CompanyView()
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

            AddColumnBtn.Click += delegate
            {
                if (!string.IsNullOrWhiteSpace(NameColumn.Text))
                {
                    AddColumnEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            DeleteColumnBtn.Click += delegate
            {
                if (!string.IsNullOrWhiteSpace(NameColumn.Text))
                {
                    DropColumnEvent?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public string CompanyId 
        { 
            get => IDTB.Text;
            set => IDTB.Text = value; 
        }
        public string NameCompany 
        { 
            get => NameTB.Text;
            set => NameTB.Text = value; 
        }
        public string Address
        {
            get => AddressTB.Text; 
            set => AddressTB.Text = value; 
        }
        public string Phone 
        { 
            get => PhoneTB.Text; 
            set => PhoneTB.Text = value; 
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
        public string AddColumn 
        {
            get => NameColumn.Text;
            set => NameColumn.Text = value;
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler AddColumnEvent;
        public event EventHandler DropColumnEvent;

        public void SetCompanyListBindingSource(BindingSource CompanyList)
        {
            dataGridView.DataSource = CompanyList;
        }

        private static CompanyView _instance;
        internal static CompanyView GetInstance(Form parentForm)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new CompanyView
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
