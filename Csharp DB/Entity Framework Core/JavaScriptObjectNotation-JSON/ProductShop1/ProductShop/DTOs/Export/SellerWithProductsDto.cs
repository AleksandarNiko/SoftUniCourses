using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Export
{
    public class SellerWithProductsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<SoldProductsDto> SoldProducts { get; set; }
    }

}
