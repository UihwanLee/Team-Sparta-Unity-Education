using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal static class ItemSorter
    {
        /*
         * Item 정렬 클래스
         * 
         * [정렬 기능]
         * Id
         * 이름 
         * 장착 
         * 공격력
         * 방어력
         * 
         */

        // 아이템 정렬 - Id
        public static List<Item> SortById(List<Item> list)
        {
            return list.OrderBy(item => item.Id).ToList();
        }

        // 아이템 정렬 - 이름
        public static List<Item> SortByName(List<Item> list)
        {
            return list.OrderBy(item => item.name).ToList();
        }

        // 아이템 정렬 - 장착
        public static List<Item> SortByEquipped(List<Item> list)
        {
            return list.OrderBy(item => !item.isEquipped).ToList();
        }

        // 아이템 정렬 - 공격력
        public static List<Item> SortByAtk(List<Item> list)
        {
            return list.OrderByDescending(item => item is Weapon)
                        .ThenByDescending(Item => (Item as Weapon)?.ATK ?? 0).ToList();
        }

        // 아이템 정렬 - 방어력
        public static List<Item> SortByDef(List<Item> list)
        {
            return list.OrderByDescending(item => item is Armor)
                        .ThenByDescending(Item => (Item as Armor)?.DEF ?? 0).ToList();
        }
    }
}
