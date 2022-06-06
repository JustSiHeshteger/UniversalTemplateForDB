using System.Collections.Generic;
using System.Data;
using UniversalTemplateForDB.Models.Model;

namespace UniversalTemplateForDB.Models.Repositories
{
    internal interface IMaterialRepository
    {
        void Add(MaterialModel companyModel);
        void Edit(MaterialModel companyModel);
        void Delete(int id);
        DataTable GetAll();
        DataTable GetByValue(string value); //Поиск по значению
        void AddColumn(string name);
        void DropColumn(string name);
    }
}
