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
    public partial class MasterView : Form, IMasterView
    {
        private bool _isEdit;
        private bool _isSuccessful;
        private string _message;

        public MasterView()
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

        public string MasterId 
        {
            get => IDTB.Text; 
            set => IDTB.Text = value; 
        }
        public string MasterName 
        { 
            get => NameTB.Text;
            set => NameTB.Text = value; 
        }
        public string MasterSecondName 
        {
            get => SecondNameTB.Text; 
            set => SecondNameTB.Text = value; 
        }
        public string MasterExperience
        {
            get => ExperienceTB.Text; 
            set => ExperienceTB.Text = value;
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

        public void SetMasterListBindingSource(BindingSource masterList)
        {
            dataGridView.DataSource = masterList;
        }

        private static MasterView instance;
        internal static MasterView GetInstance(Form parentForm)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new MasterView
                {
                    MdiParent = parentForm
                };
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }

            return instance;
        }
    }
}
