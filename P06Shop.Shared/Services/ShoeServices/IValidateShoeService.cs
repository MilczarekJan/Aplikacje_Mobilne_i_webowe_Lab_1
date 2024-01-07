using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Services.ShoeServices
{
	public interface IValidateShoeService
	{
		public bool validateShoe(double shoeSize, string shoeName, string shoeDescription);
	}
}
