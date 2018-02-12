using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.Biz
{
    internal class Shipment
    {
        public int ID { get; set; }
        public string ShipmentName { get; set; }
        public int Fee { get; set; }
        public string StoreName { get; set; }

        public void ShowShipment(List<Shipment> s)
        {
            Console.WriteLine("=======物流選擇列表=======");
            for (int i = 0; i < s.Count; i++)
            {
                Console.WriteLine("({0}){1} 運費：{2}元", s[i].ID, s[i].ShipmentName, s[i].Fee);
            }
        }

        public Dictionary<int, Shipment> SelectShipment(List<Product> carList, List<Shipment> s)
        {
            int carlistStoreCount = carList.Select(x => x.StoreName).Distinct().Count();

            List<string> carListStore = carList.Select(x => x.StoreName).Distinct().ToList();

            Dictionary<int, Shipment> dicSelectShipment = new Dictionary<int, Shipment>();
            int i = 0;
            foreach (var item in carListStore)
            {
                Console.WriteLine("請選擇{0}的配送方式：", item);

                string selectShipment = Console.ReadLine();

                bool canConvert = int.TryParse(selectShipment, out int checkNumber);

                if (carList.Where(x => x.StoreName == item).Sum(y => y.Amount) >= 3)
                {
                    dicSelectShipment.Add(i, new Shipment() { ID = i, ShipmentName = s[i].ShipmentName, Fee = 0, StoreName = item });
                }
                else if (item == "OO商店" && checkNumber == 1)
                {
                    dicSelectShipment.Add(i, new Shipment() { ID = i, ShipmentName = s[i].ShipmentName, Fee = Convert.ToInt32(s[checkNumber - 1].Fee * 0.8), StoreName = item });
                }
                else
                {
                    dicSelectShipment.Add(i, new Shipment() { ID = i, ShipmentName = s[i].ShipmentName, Fee = Convert.ToInt32(s[checkNumber - 1].Fee * 0.8), StoreName = item });
                }
                i += 1;
            }
            return dicSelectShipment;
        }
    }
}