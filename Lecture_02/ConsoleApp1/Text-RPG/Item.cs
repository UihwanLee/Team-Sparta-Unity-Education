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
        /*
         * Item 스크립트
         * 
         * 이 게임에서 사용하는 아이템 옵션은 다음과 같다.
         * [Armor] 방어구
         * [Weapon] 무기
         * [Porion] 포션
         * [Etc] 기타 아이템
         * 
         */
        public string name;
        public string effect;
        public string description;
        public int price;
        public ItemType Type { get; private set; }

        public bool isEquipped;

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

        public void DisplayInfo()
        {
            // 현재 장착 관리 상태인지 확인 후 아이템 정보 표시
            string isEquippedTxt = (isEquipped) ? "[E]" : "";
            string itemName = $"{isEquippedTxt}{name}";

            Console.WriteLine(
                $"{UIManager.Instance.PadRightForConsole(itemName, 20)} | " +
                $"{UIManager.Instance.PadRightForConsole(effect, 15)} | " +
                $"{description}"
            );
        }
    }
}
