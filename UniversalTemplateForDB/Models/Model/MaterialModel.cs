using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversalTemplateForDB.Models.Model
{
    internal class MaterialModel
    {
        private int _idMaterial;
        private int _idProduct;
        private string _nameMaterial;
        private int _price;

        
        [DisplayName("Id материала")]
        public int IdMaterial
        { 
            get => _idMaterial; 
            set => _idMaterial = value; 
        }


        [DisplayName("Id продукта")]
        public int IdProduct
        {
            get => _idProduct;
            set => _idProduct = value;
        }


        [DisplayName("Название материала")]
        [Required(ErrorMessage = "Название материала не должно быть пустым")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Название метариала должно быть от 3 до 30 символов")]
        public string NameMaterial 
        {
            get => _nameMaterial; 
            set => _nameMaterial = value; 
        }


        [DisplayName("Цена материала")]
        [Required(ErrorMessage = "Цена материала не должна быть пустой")]
        public int Price
        { 
            get => _price; 
            set => _price = value; 
        }
    }
}
