using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversalTemplateForDB.Models.Model
{
    internal class ProductModel
    {
        private int _id;
        private string _nameProduct;
        private int _idMaster;
        private int _idCompany;
        private string _info;

        
        [DisplayName("Id продукта")]
        public int Id 
        { 
            get => _id; 
            set => _id = value; 
        }


        [DisplayName("Название продукта")]
        [Required(ErrorMessage = "Название продукта не должно быть пустым")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Название продукта должно быть от 3 до 30 символов")]
        public string NameProduct 
        { 
            get => _nameProduct; 
            set => _nameProduct = value; 
        }


        [DisplayName("Id мастера")]
        [Required(ErrorMessage = "Id мастера не должно быть пустым")]
        public int IdMaster 
        { 
            get => _idMaster; 
            set => _idMaster = value; 
        }


        [DisplayName("Id компании")]
        [Required(ErrorMessage = "Id компании не должно быть пустым")]
        public int IdCompany 
        { 
            get => _idCompany; 
            set => _idCompany = value;
        }


        [DisplayName("Информация о продукте")]
        [StringLength(200)]
        public string Info 
        { 
            get => _info; 
            set => _info = value; 
        }
    }
}
