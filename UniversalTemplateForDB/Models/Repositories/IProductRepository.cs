using System.Collections.Generic;
using UniversalTemplateForDB.Models.Model;

namespace UniversalTemplateForDB.Models.Repositories
{
    internal interface IProductRepository
    {
        void Add(ProductModel companyModel);
        void Edit(ProductModel companyModel);
        void Delete(int id);
        IEnumerable<ProductModel> GetAll();
        IEnumerable<ProductModel> GetByValue(string value); //Поиск по значению
    }
}
