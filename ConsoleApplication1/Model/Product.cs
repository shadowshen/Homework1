using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string StoreName { get; set; }
        public int Amount { get; set; }
        public int DiscountPrice { get; set; }
    }
}
