using System.Collections.Generic;
using UniversalTemplateForDB.Models.Model;

namespace UniversalTemplateForDB.Models.Repositories
{
    internal interface IMasterRepository
    {
        void Add(MasterModel companyModel);
        void Edit(MasterModel companyModel);
        void Delete(int id);
        IEnumerable<MasterModel> GetAll();
        IEnumerable<MasterModel> GetByValue(string value); //Поиск по значению
    }
}
