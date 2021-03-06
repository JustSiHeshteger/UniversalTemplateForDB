using System.Collections.Generic;
using System.Data;
using UniversalTemplateForDB.Models.Model;

namespace UniversalTemplateForDB.Models.Repositories
{
    internal interface IMasterRepository
    {
        void Add(MasterModel companyModel);
        void Edit(MasterModel companyModel);
        void Delete(int id);
        DataTable GetAll();
        DataTable GetByValue(string value); //Поиск по значению
        void AddColumn(string name);
        void DropColumn(string name);
    }
}
