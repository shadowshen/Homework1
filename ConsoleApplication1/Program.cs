using System;
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
            string selectProduct, input, carList = null;
            string[,] Product = new string[3, 2] { { "二手蘋果手機", "8700" }, { "C# CookBook", "568" }, { "HP筆電", "16888" } };
            int number, total = 0;
            Console.WriteLine("請輸入要購買的商品\n(1)二手蘋果手機 售價：$8700元\n(2)C# CookBook 售價：$568元\n(3)HP筆電 售價：$16888元\n(4)結帳");

            do
            {
                selectProduct = null;
                selectProduct = GetUserInput("請輸入您要的產品，或請按(4)進行結帳>");
                Int32.TryParse(selectProduct, out number);
                number = number - 1;

                if (number <= 2)
                {
                    input = GetUserInput("請輸入您要購買的數量，若要重新選擇請輸入0>");
                    if (Convert.ToInt32(input) != 0)
                    {
                        Console.WriteLine("你的選擇是({0}){1}，單價是{2}元，數量：{3}，小計：{4}元\n", selectProduct, Product[number, 0], Product[number, 1], input, (Convert.ToInt32(Product[number, 1]) * Convert.ToInt32(input)));
                        total = total + (Convert.ToInt32(Product[number, 1]) * Convert.ToInt32(input));
                        carList = carList + "項目： (" + selectProduct + ") " + Product[number, 0] + "，數量：" + input + "，小計：" + (Convert.ToInt32(Product[number, 1]) * Convert.ToInt32(input)) + "元\n";
                    }
                }
                else if (number > 3)
                {
                    Console.WriteLine("你輸入的選擇無效");
                }

            } while (number != 3);

            ShoppingList(carList, total);

        }

        static string GetUserInput(string writeTitle)
        {
            string selectProduct = null;
            Console.WriteLine(writeTitle);
            selectProduct = Console.ReadLine();
            long checkNumber = 0;
            bool canConvert = long.TryParse(selectProduct, out checkNumber);
            if (canConvert == false)
            {
                Console.WriteLine("錯誤！！您輸入了非數字的字元！");
                selectProduct = GetUserInput(writeTitle);
            }
            return selectProduct;
        }

        static void ShoppingList(string carList, int total)
        {
            if (carList == null)
            {
                carList = "您的購物車是空的";
            }
            Console.Write("\n您本次的消費明細如下：\n{0}\n本次消費金額{1}元", carList, total);
            Console.ReadLine();
            return;
        }
    }
}