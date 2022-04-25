using System;
using System.Windows.Forms;
using UniversalTemplateForDB;
using UniversalTemplateForDB.Models.Repositories;
using UniversalTemplateForDB.Repositories;
using UniversalTemplateForDB.Views.Forms;
using UniversalTemplateForDB.Views.Interfaces;
using UniversalTemplateForDB.Presenters;
using System.Configuration;

namespace ChildrenParty
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            IMainView view = new MainForm();
            new MainPresenter(view, sqlConnectionString);

            Application.Run((Form)view);
        }
    }
}