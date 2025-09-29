using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public enum ItemType { Weapon, Armor, Potion, Etc }

    internal class Item
    {
        public string name;
        public string effect;
        public string description;
        public int price;
        public ItemType Type { get; private set; }

        public Item(string name, string effect, string description, int price, ItemType type)
        {
            this.name = name;
            this.price = price;
            this.Type = type;
            this.effect = effect;
            this.description = description;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{name}  | {effect}  | {description}");
        }
    }
}
