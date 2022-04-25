using System.Collections.Generic;
using UniversalTemplateForDB.Models.Model;

namespace UniversalTemplateForDB.Models.Repositories
{
    internal interface IMaterialRepository
    {
        void Add(MaterialModel companyModel);
        void Edit(MaterialModel companyModel);
        void Delete(int id);
        IEnumerable<MaterialModel> GetAll();
        IEnumerable<MaterialModel> GetByValue(string value); //Поиск по значению
    }
}
