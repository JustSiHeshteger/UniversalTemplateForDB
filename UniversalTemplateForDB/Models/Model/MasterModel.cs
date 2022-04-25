using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversalTemplateForDB.Models.Model
{
    internal class MasterModel
    {
        private int _id;
        private string _name;
        private string _secondName;
        private int _experience;

        
        [DisplayName("Id мастера")]
        public int Id 
        { 
            get => _id; 
            set => _id = value; 
        }


        [DisplayName("Имя мастера")]
        [Required(ErrorMessage = "Имя мастера не должно быть пустым")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Имя мастера должно быть от 2 до 20 символов")]
        public string Name 
        { 
            get => _name; 
            set => _name = value; 
        }


        [DisplayName("Фамилия мастера")]
        [Required(ErrorMessage = "Фамилия мастера не должна быть пустым")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Фамилия мастера должна быть от 2 до 20 символов")]
        public string SecondName 
        { 
            get => _secondName; 
            set => _secondName = value; 
        }


        [DisplayName("Опыт работы мастера")]
        [Required(ErrorMessage = "Опыт работы мастера не должна быть пустым")]
        public int Experience 
        { 
            get => _experience; 
            set => _experience = value; 
        }
    }
}
