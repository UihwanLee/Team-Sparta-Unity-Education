using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public enum ItemType { Weapon, Armor, Potion, Etc }

    internal class Item
    {
        public string name;
        public int price;
        public ItemType Type { get; private set; }

        public Item(string name, int price, ItemType type)
        {
            this.name = name;
            this.price = price;
            this.Type = type;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"아이템: {name}, 가격: {price}G");
        }
    }
}
