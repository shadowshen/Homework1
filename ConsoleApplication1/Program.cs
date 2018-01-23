﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int productID, amount;
            int number = 0;
            Product[] arrProducts = {new Product("二手蘋果手機",8700,"XX商店"),
                                     new Product("C# CookBook",568,"XX商店"),
                                     new Product("HP筆電",16888,"XX商店"),
                                     new Product("哈利波特影集",2250,"OO商店"),
                                     new Product("無間道三部曲",1090,"OO商店")};
            shoppingCart SC = new shoppingCart();
            Console.WriteLine("請輸入要購買的商品\n(1)二手蘋果手機 售價：$8700元\n(2)C# CookBook 售價：$568元\n(3)HP筆電 售價：$16888元\n(4)哈利波特影集 售價：$2250\n(5)無間道三部曲 售價：$1090\n(6)結帳");

            do
            {
                productID = GetUserInput("請輸入您要的產品，或請按(6)進行結帳>");
                number = productID - 1;
                if (number <= (arrProducts.Length-1))
                {
                    amount = GetUserInput("請輸入您要購買的數量，若要重新選擇請輸入0>");
                    if (Convert.ToInt32(amount) != 0)
                    {
                        Console.WriteLine("你的選擇是{5}的({0}){1}，單價是{2}元，數量：{3}，小計：{4}元\n", arrProducts[number].ID, arrProducts[number].productName,
                                                                                                       arrProducts[number].productPrice,
                                                                                                       amount, (amount * arrProducts[number].productPrice), arrProducts[number].storeName);
                        SC.addcarList(arrProducts[number], Convert.ToInt32(amount));
                    }
                }
                else if (number > (arrProducts.Length))
                {
                    Console.WriteLine("你輸入的選擇無效");
                }
            } while (number != (arrProducts.Length));

            if (SC.carList == null)
            {
                SC.carList = "您的購物車是空的";
            }
            Console.Write("\n您本次的消費明細如下：\n{0}\n本次消費金額{1}元", SC.carList, SC.total);
            Console.ReadLine();
        }

        static int GetUserInput(string writeTitle)
        {
            string selectProduct = null;
            Console.WriteLine(writeTitle);
            selectProduct = Console.ReadLine();
            int checkNumber = 0;
            bool canConvert = int.TryParse(selectProduct, out checkNumber);
            if (canConvert == false)
            {
                Console.WriteLine("錯誤！！您輸入了非數字的字元！");
                checkNumber = GetUserInput(writeTitle);
            }
            return checkNumber;
        }

        class Product
        {
            private static int productID;
            public int ID;
            public string productName;
            public int productPrice;
            public string storeName;

            public Product( string productName, int productPrice, string storeName)
            {
                productID++;
                this.ID = productID;
                this.productName = productName;
                this.productPrice = productPrice;
                this.storeName = storeName;
            }
        }

        class shoppingCart
        {
            public int total;
            public string carList = "";

            public void addcarList(Product selectProduct, int input)
            {
                carList = carList + "項目："+selectProduct.storeName+"- (" + selectProduct.ID + ") " + selectProduct.productName + "，數量：" + input + "，小計：" + (selectProduct.productPrice * Convert.ToInt32(input)) + "元\n";
                total = total + (selectProduct.productPrice * Convert.ToInt32(input));
            }
        }
    }
}