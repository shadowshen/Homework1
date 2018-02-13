using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.Biz
{
    internal class ShoppingCart
    {
        /// <summary>
        /// Stores the on sale.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <returns></returns>
        public int StoreOnSale(List<Product> shoppingCart)
        {
            List<string> carlistStoreCount = shoppingCart.Select(x => x.StoreName).Distinct().ToList();

            int carListTotal = 0;
            for (int i = 0; i < shoppingCart.Count; i++)
            {
                if (shoppingCart[i].StoreName == "OO商店")
                {
                    if (shoppingCart[i].Amount >= 3)
                    {
                        double discount = 0.7;
                        shoppingCart[i].DiscountPrice = Convert.ToInt32((shoppingCart[i].ProductPrice * shoppingCart[i].Amount) * discount);
                        carListTotal += shoppingCart[i].DiscountPrice;
                    }
                    else if (shoppingCart[i].Amount >= 2)
                    {
                        double discount = 0.9;
                        shoppingCart[i].DiscountPrice = Convert.ToInt32((shoppingCart[i].ProductPrice * shoppingCart[i].Amount) * discount);
                        carListTotal += shoppingCart[i].DiscountPrice;
                    }
                    else
                    {
                        carListTotal += shoppingCart[i].ProductPrice * shoppingCart[i].Amount;
                    }
                }
                else if (shoppingCart[i].StoreName == "XX商店")
                {
                    carListTotal += shoppingCart[i].ProductPrice * shoppingCart[i].Amount;
                }
            }
            return carListTotal;
        }
        /// <summary>
        /// Merges the shopping cart same product.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <returns></returns>
        public List<Product> MergeShoppingCartSameProduct(List<Product> shoppingCart)
        {
            var listByProduct = shoppingCart.GroupBy(x => new { x.ID, x.ProductName, x.ProductPrice, x.StoreName }).Select(y => new Product
            {
                ID = y.First().ID,
                ProductName = y.First().ProductName,
                ProductPrice = y.First().ProductPrice,
                StoreName = y.First().StoreName,
                Amount = y.Sum(z => z.Amount)
            }).ToList();

            return listByProduct;
        }
        /// <summary>
        /// Shows the detail.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="total">The total.</param>
        /// <param name="dicSelectShipment">The dic select shipment.</param>
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