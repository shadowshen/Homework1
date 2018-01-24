using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ConsoleApplication1.Biz;
using ConsoleApplication1.Model;


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
            ShoppingCart shoppingCart = new ShoppingCart();

            Console.WriteLine("=======商品列表=======");
            for (int i = 0; i < arrProducts.Length;i++ )
            {
                Console.WriteLine("({0}){1} 售價：${2} 店家：{3}",arrProducts[i].ID,arrProducts[i].productName,arrProducts[i].productPrice,arrProducts[i].storeName);
            }
            Console.WriteLine("({0})結帳",(arrProducts.Length+1));

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
                        shoppingCart.addcarList(arrProducts[number], Convert.ToInt32(amount));
                    }
                }
                else if (number > (arrProducts.Length))
                {
                    Console.WriteLine("你輸入的選擇無效");
                }
            } while (number != (arrProducts.Length));

            if (shoppingCart.carList == null)
            {
                shoppingCart.carList = "您的購物車是空的";
            }
            Console.Write("\n您本次的消費明細如下：\n{0}\n本次消費金額{1}元", shoppingCart.carList, shoppingCart.total);
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
    }
}