using System.Collections.Generic;
using System.Data;
using UniversalTemplateForDB.Models.Model;

namespace UniversalTemplateForDB.Models.Repositories
{
    internal interface ICompanyRepository
    {
        void Add(CompanyModel companyModel);
        void Edit(CompanyModel companyModel);
        void Delete(int id);
        DataTable GetAll();
        DataTable GetByValue(string value); //Поиск по значению
        void AddColumn(string name);
        void DropColumn(string name);
    }
}
