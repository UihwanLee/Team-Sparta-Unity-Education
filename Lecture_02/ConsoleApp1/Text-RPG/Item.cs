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

        bool isEquipped;

        public Item(string name, string effect, string description, int price, ItemType type, bool isEquipped)
        {
            this.name = name;
            this.price = price;
            this.Type = type;
            this.effect = effect;
            this.description = description;
            this.isEquipped = isEquipped;
        }

        public void EquippedItem(bool _isEquipped)
        {
            // 아이템 장착/해제
            isEquipped = _isEquipped;
        }

        public void DisplayInfo(bool _isEquipped)
        {
            // 현재 장착 관리 상태인지 확인 후 아이템 정보 표시
            string isEquippedTxt = (isEquipped && _isEquipped) ? "[E]" : "";
            Console.WriteLine($"{isEquippedTxt}{name}  | {effect}  | {description}");
        }
    }
}
