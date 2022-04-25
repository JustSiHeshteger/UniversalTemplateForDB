using System.Collections.Generic;
using UniversalTemplateForDB.Models.Model;

namespace UniversalTemplateForDB.Models.Repositories
{
    internal interface ICompanyRepository
    {
        void Add(CompanyModel companyModel);
        void Edit(CompanyModel companyModel);
        void Delete(int id);
        IEnumerable<CompanyModel> GetAll();
        IEnumerable<CompanyModel> GetByValue(string value); //Поиск по значению
    }
}
