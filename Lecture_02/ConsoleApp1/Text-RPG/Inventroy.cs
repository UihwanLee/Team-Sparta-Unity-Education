using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Inventroy
    {
        /*
         * 인벤토리는 캐릭터에 소속된다.
         * 아이템 리스트를 가지고 있으며
         * 각 아이템을 관리할 수 있는 기능을 가지고 있다.
         * 
         * [인벤토리 기능]
         *  - 아이템 추기
         *  - 아이템 삭제
         *  - 아이템 찾기(이름/인덱스)
         *  - 아이템 장착/해제
         *  - 아이템 정보 표시
         * 
         */
        // 아이템 리스트
        private List<Item> items = new List<Item>();

        // 생성자
        public Inventroy() 
        {
            items.Clear();
        }

        // 아이템 추가
        public void Add(Item _item)
        {
            items.Add(_item);
        }

        // 아이템 삭제
        public void Remove(Item _item)
        {
            items.Remove(_item);
        }

        // 인벤토리 초기화
        public void Clear()
        {
            items.Clear();
        }

        // 장비 장착/해제 - 아이템 검색
        public void EquipItem(Item _item, bool isEquipped)
        {
            foreach(var item in items)
            {
                if(item.Id == _item.Id)
                {
                    item.EquipItem(GameManager.Instance.GetPlayer(), isEquipped);
                }
            }
        }

        // 장비 장착/해제 - 인덱스 검색
        public void EquipItemByIdx(int idx)
        {
            if(items.Count <= 0 || idx >= items.Count) return;

            // 이미 장착 중이라면 장착 해제
            if (items[idx].isEquipped) { 
                items[idx].EquipItem(GameManager.Instance.GetPlayer(), false);
            }

            // 장착 중인 상태가 아니라면 장착
            else { 
                items[idx].EquipItem(GameManager.Instance.GetPlayer(), true);
            }
        }

        // Armor, Weapon 유무 알려주기

        // 인벤토리 보여주기
        public void DisplayInfo(bool isEquipped)
        {
            Console.WriteLine("[아이템 목록]\n");
            Console.WriteLine(
                ((isEquipped) ? UIManager.Instance.PadRightForConsole(" ", 6) : $"  ") +
                $"{UIManager.Instance.PadRightForConsole("[아이템 이름]", 20)} | " +
                $"{UIManager.Instance.PadRightForConsole("[아이템 효과]", 15)} | " +
                $"[아이템 설명]\n");

            for (int i=0; i<items.Count; i++)
            {
                string idxTxt = (isEquipped) ? $"{i + 1} : " : "";
                Console.Write($"- {idxTxt}");
                items[i].DisplayInfo();
            }
        }

        // 아이템 정렬
        public void SortItemByOption(int option)
        {
            switch(option)
            {
                case 1:     // 이름 정렬
                    items = ItemSorter.SortByName(items);
                    break;
                case 2:     // 장착 순 정렬
                    items = ItemSorter.SortByEquipped(items);
                    break;
                case 3:     // 공격력 정렬
                    items = ItemSorter.SortByAtk(items);
                    break;
                case 4:     // 방어력 정렬
                    items = ItemSorter.SortByDef(items);
                    break;
                default:
                    break;
            }
        }

        // 프로퍼티 변수
        public List<Item> Items { get { return items; } }
    }
}
