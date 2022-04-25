using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Windows.Forms;

namespace UniversalTemplateForDB.Presenters.Base
{
    internal class DataValidation
    {
        public void Validate(object model)
        {
            string errorMessage = "";
            List<ValidationResult> result = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, result, true);

            if (!isValid)
            {
                foreach(var item in result)
                {
                    errorMessage += "Ошибка: " + item.ErrorMessage + "\n";
                }
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception(errorMessage);
            }
        }
    }
}
