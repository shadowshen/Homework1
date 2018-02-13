using ConsoleApplication1.Biz;
using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int productID, amount;
            int number = 0;
            int costTotal = 0;

            List<Product> p = new List<Product>
            {
                new Product { ID = 1, ProductName = "二手蘋果手機", ProductPrice = 8700, StoreName = "XX商店" },
                new Product { ID = 2, ProductName = "C# cookbook", ProductPrice = 568, StoreName = "XX商店" },
                new Product { ID = 3, ProductName = "HP 筆電", ProductPrice = 16888, StoreName = "XX商店" },
                new Product { ID = 4, ProductName = "哈利波特影集", ProductPrice = 2250, StoreName = "OO商店" },
                new Product { ID = 5, ProductName = "無間道三部曲", ProductPrice = 1090, StoreName = "OO商店" }
            };

            List<Shipment> s = new List<Shipment>
            {
                new Shipment { ID = 1, ShipmentName = "宅急便", Fee = 60 },
                new Shipment { ID = 2, ShipmentName = "郵局", Fee = 40 },
                new Shipment { ID = 3, ShipmentName = "超商店到店", Fee = 50 }
            };

            List<Product> cartList = new List<Product>();

            Console.WriteLine("=======商品列表=======");
            for (int i = 0; i < p.Count; i++)
            {
                Console.WriteLine("({0}){1} 售價：${2} 店家：{3}", p[i].ID, p[i].ProductName, p[i].ProductPrice, p[i].StoreName);
            }
            Console.WriteLine("({0})結帳", (p.Count) + 1);

            
            do
            {
                productID = GetUserSeletProduct("請輸入您要的產品，或請按(6)進行結帳>", p);

                if (productID == p.Count + 1) break;

                number = productID - 1;
                amount = GetUserInput("請輸入您要購買的數量>", p.Count);

                cartList.Add(new Product { ID = p[number].ID, ProductName = p[number].ProductName, Amount = amount, ProductPrice = p[number].ProductPrice, StoreName = p[number].StoreName });
            } while (productID != (p.Count) + 1);

            ShoppingCart shoppingCart = new ShoppingCart();
            cartList = shoppingCart.MergeShoppingCartSameProduct(cartList);

            ShipmentBiz shipmentBiz = new ShipmentBiz();
            shipmentBiz.ShowShipment(s);

            Dictionary<int, Shipment> dicSelectShipment = new Dictionary<int, Shipment>();
            dicSelectShipment = shipmentBiz.SelectShipment(cartList, s);

            costTotal = shoppingCart.StoreOnSale(cartList);

            shoppingCart.ShowDetail(cartList, costTotal, dicSelectShipment);
        }

        /// <summary>
        /// Gets the user input.
        /// </summary>
        /// <param name="writeTitle">The write title.</param>
        /// <param name="productCount">The product count.</param>
        /// <returns></returns>
        private static int GetUserInput(string writeTitle, int productCount)
        {
            Console.WriteLine(writeTitle);
            string selectProduct = null;
            selectProduct = Console.ReadLine();

            bool canConvert = int.TryParse(selectProduct, out int checkNumber);

            if (canConvert == false || checkNumber == 0)
            {
                Console.WriteLine("錯誤！！您輸入的數量有誤！");
                checkNumber = GetUserInput(writeTitle, productCount);
            }

            return checkNumber;
        }

        /// <summary>
        /// Gets the user selet product.
        /// </summary>
        /// <param name="writeTitle">The write title.</param>
        /// <param name="productList">The product list.</param>
        /// <returns></returns>
        private static int GetUserSeletProduct(string writeTitle, List<Product> productList)
        {
            string selectProduct = null;
            Console.WriteLine(writeTitle);
            selectProduct = Console.ReadLine();

            bool canConvert = int.TryParse(selectProduct, out int checkNumber);

            if (productList.Where(x => x.ID == checkNumber).Count() == 0 && checkNumber != productList.Count + 1)
            {
                Console.WriteLine("你輸入的產品不存在");
                checkNumber = GetUserSeletProduct(writeTitle, productList);
            }

            return checkNumber;
        }
    }
}