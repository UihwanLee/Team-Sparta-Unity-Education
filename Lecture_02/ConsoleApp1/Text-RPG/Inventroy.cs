using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 인벤토리는 캐릭터에 소속된다.
 * 아이템 리스트를 가지고 있으며
 * 각 아이템을 관리할 수 있는 기능을 가지고 있다.
 */
namespace Text_RPG
{
    internal class Inventroy
    {
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
        public void EquippedItem(Item _item, bool isEquipped)
        {
            foreach(var item in items)
            {
                if(item.name == _item.name)
                {
                    item.EquippedItem(isEquipped);
                }
            }
        }

        // 장비 장착/해제 - 인덱스 검색
        public void EquippedItemByIdx(int idx)
        {
            if(items.Count <= 0 || idx >= items.Count) return;

            // 이미 장착 중이라면 장착 해제
            if (items[idx].isEquipped) { items[idx].EquippedItem(false); }

            // 장착 중인 상태가 아니라면 장착
            else { items[idx].EquippedItem(true); }
        }

        // 인벤토리 보여주기
        public void DisplayInfo(bool isEquipped)
        {
            Console.WriteLine("[아이템 목록]");
            for(int i=0; i<items.Count; i++)
            {
                string idxTxt = (isEquipped) ? $"{i + 1} : " : "";
                Console.Write($"- {idxTxt}");
                items[i].DisplayInfo();
            }
        }

        // 프로퍼티 변수
        public List<Item> Items { get { return items; } }
    }
}
