using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Model
{
    class Product
    {
        private static int productID;
        public int ID;
        public string productName;
        public int productPrice;
        public string storeName;

        public Product(string productName, int productPrice, string storeName)
        {
            productID++;
            this.ID = productID;
            this.productName = productName;
            this.productPrice = productPrice;
            this.storeName = storeName;
        }
    }
}
