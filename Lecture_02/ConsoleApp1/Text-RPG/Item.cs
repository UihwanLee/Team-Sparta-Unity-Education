using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public enum ItemType { Weapon, Armor, Potion, Etc }

    public class Item
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

        public int Id { get; }
        public string name;
        public string effect;
        public string description;
        public int price;
        public ItemType Type { get; private set; }

        public bool isEquipped;
        public bool isPurchase;

        public Item(int id, string name, string effect, string description, int price, ItemType type)
        {
            this.Id = id;
            this.name = name;
            this.price = price;
            this.Type = type;
            this.effect = effect;
            this.description = description;
            this.isEquipped = false;
            this.isPurchase = false;
        }

        // 아이템 장착은 무기/방어구 클래스에서 실행한다.
        public virtual void EquipItem(Player player, bool isEquipped)
        {
            // 아이템 장착/해제
            this.isEquipped = isEquipped;
        }

        public void DisplayInfo()
        {
            // 현재 장착 관리 상태인지 확인 후 아이템 정보 표시
            string isEquippedTxt = (isEquipped) ? "[E]" : "";
            string itemName = $"{isEquippedTxt}{name}";

            Console.WriteLine(
                string.Format("{0} | {1} | {2}",
                UIManager.Instance.PadRightForConsole(itemName, 20),
                UIManager.Instance.PadRightForConsole(effect, 15),
                description));
        }

        public void DisplayInfoProduct()
        {
            // 상품 목록에서 보여줄 아이템 정보 표시
            string itemPurchase = (isPurchase) ? "구매완료" : $"{price}";
            string isGoldIcon = (isPurchase) ? "" : "G";

            Console.WriteLine( 
                string.Format("{0} | {1} | {2} | {3} {4}",
                UIManager.Instance.PadRightForConsole(name, 20),
                UIManager.Instance.PadRightForConsole(effect, 15),
                UIManager.Instance.PadRightForConsole(description, 50),
                UIManager.Instance.PadRightForConsole(itemPurchase, 6),
                isGoldIcon));
        }

        // 아이템 복제
        public virtual Item Clone()
        {
            return new Item(Id, name, effect, description, price, Type);
        }
    }
}
