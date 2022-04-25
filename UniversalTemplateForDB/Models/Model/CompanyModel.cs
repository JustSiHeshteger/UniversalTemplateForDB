using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UniversalTemplateForDB.Models.Model
{
    internal class CompanyModel
    {
        private int _id;
        private string _nameCompany;
        private string _address;
        private int _phone;


        [DisplayName("Id компании")]
        public int Id 
        { 
            get => _id; 
            set => _id = value; 
        }


        [DisplayName("Название компании")]
        [Required(ErrorMessage = "Название компании не должно быть пустым")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Название компании должно быть от 3 до 30 символов")]
        public string NameCompany 
        { 
            get => _nameCompany;
            set => _nameCompany = value; 
        }


        [DisplayName("Адрес компании")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Адрес компании должен быть от 3 до 50 символов")]
        public string Address 
        { 
            get => _address; 
            set => _address = value; 
        }


        [DisplayName("Телефон компании")]
        public int Phone 
        { 
            get => _phone; 
            set => _phone = value; 
        }
    }
}
