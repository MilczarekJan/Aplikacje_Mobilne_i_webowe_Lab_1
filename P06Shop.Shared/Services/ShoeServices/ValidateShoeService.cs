using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Services.ShoeServices
{
    public class ValidateShoeService : IValidateShoeService
    {
        public bool validateShoe(double shoeSize, string shoeName, string shoeDescription) {
            if (shoeSize > 45.0 || shoeSize < 36) { 
                return false;
            }

            if (shoeSize % 0.5 != 0) {
                return false;
            }

            if (shoeDescription.Length > 200 || shoeName.Length > 100) {
                return false;
            }
            return true;
        }
    }
}
