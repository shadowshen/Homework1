using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Model;
using ConsoleApplication1.Biz;

namespace ConsoleApplication1.Biz
{
    class ShoppingCart
    {

        public int StoreOnSale(List<Product> shoppingCart)
        {
            List<string> carlistStoreCount = shoppingCart.Select(x => x.StoreName).Distinct().ToList();

            int total = 0;
            for (int i = 0; i < shoppingCart.Count; i++)
            {
                if (shoppingCart[i].StoreName == "OO商店")
                {

                    if (shoppingCart[i].Amount >= 3)
                    {
                        double discount = 0.7;
                        shoppingCart[i].DiscountPrice = Convert.ToInt32((shoppingCart[i].ProductPrice * shoppingCart[i].Amount) * discount);
                        total += shoppingCart[i].DiscountPrice;
                    }
                    else if (shoppingCart[i].Amount >= 2)
                    {
                        double discount = 0.9;
                        shoppingCart[i].DiscountPrice = Convert.ToInt32((shoppingCart[i].ProductPrice * shoppingCart[i].Amount) * discount);
                        total += shoppingCart[i].DiscountPrice;
                    }
                    else
                    {
                        total += shoppingCart[i].ProductPrice * shoppingCart[i].Amount;
                    }

                }
                else if (shoppingCart[i].StoreName == "XX商店")
                {
                    total += shoppingCart[i].ProductPrice * shoppingCart[i].Amount;
                }
            }

            return total;
        }

        public void ShowDetail(List<Product> shoppingCart, int total, Dictionary<int, Shipment> dicSelectShipment)
        {

            if (shoppingCart.Count == 0)
            {
                Console.Write("您的購物車是空的");
                Console.ReadLine();
            }
            else
            {
                
                Console.Write("您的購物車明細如下：\n");
                for (int i = 0; i < shoppingCart.Count; i++)
                {
                    Console.WriteLine("項次({0})：({1})-{2} 購買數量：{3} 小計：{4}元，優惠價格：{6}元 - {5}", i + 1, shoppingCart[i].ID, shoppingCart[i].ProductName, shoppingCart[i].Amount, shoppingCart[i].ProductPrice * shoppingCart[i].Amount, shoppingCart[i].StoreName, shoppingCart[i].DiscountPrice);
                }
                Console.WriteLine("商品小計金額為：{0}元\n", total);

                for (int i = 0; i < dicSelectShipment.Count; i++)
                {
                    Console.WriteLine("商家{0}運費為：{1}元", i + 1, dicSelectShipment[i].Fee);
                    total += dicSelectShipment[i].Fee;
                }

                Console.WriteLine("此次消費的總金額是{0}元", total);
                Console.ReadLine();

            }
        }
    }
}
