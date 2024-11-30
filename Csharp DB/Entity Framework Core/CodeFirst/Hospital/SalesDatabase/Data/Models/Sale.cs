using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        public  DateTime Date { get; set; }

        public  int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public  int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public  int StoreId { get; set; }
        public Store Store { get; set; } = null!;
    }
}
