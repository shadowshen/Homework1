using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Model;


namespace ConsoleApplication1.Biz
{
    class ShoppingCart
    {
        public int total;
        public string carList = "";

        public void addcarList(Product product, int amount)
        {
            carList = carList + "項目：" + product.storeName + "- (" + product.ID + ") " + product.productName + "，數量：" + amount + "，小計：" + (product.productPrice * amount) + "元\n";
            total = total + (product.productPrice * Convert.ToInt32(amount));
        }
    }
}
