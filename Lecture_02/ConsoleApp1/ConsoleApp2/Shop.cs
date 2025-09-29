using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Shop
    {
        public List<Item> Items = new List<Item>();

        public Shop() { }
        public void AddItem(Item item)
        {
            Console.WriteLine($"상점에 {item.name} 아이템 추가됨");
        }

        public void DisplayItems()
        {
            Console.WriteLine("--- 상점 목록 ---");
            foreach(Item item in Items)
            {
                item.DisplayInfo();
            }
        }
    }
}
