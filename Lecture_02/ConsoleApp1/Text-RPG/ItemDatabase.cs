using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal static class ItemDatabase
    {
        /*
         * ItemDatabase: 아이템 데이터베이스 클래스
         * 
         * 게임에서 사용하는 모든 아이템 정보를 보관한 Database 클래스입니다.
         * 
         */

        private static Dictionary<string, Item> itemDatabase = new Dictionary<string, Item>();

        static ItemDatabase()
        {

            InitDatabase();
        } 

        // 아이템 데이터베이스 : 아이템 생성
        private static void InitDatabase()
        {
            // 무기
            itemDatabase["낡은 검"] = new Weapon("낡은 검", "공격력+2", "쉽게 볼 수 있는 낡은 검 입니다.", 600, ItemType.Weapon, false, 2);
            itemDatabase["연습용 창"] = new Weapon("연습용 창", "공격력+3", "검보다는 그래도 창이 다루기 쉽죠.", 700, ItemType.Weapon, false, 3);
            itemDatabase["청동 도끼"] = new Weapon("청동 도끼", "공격력+5", "어디선가 사용됐던거 같은 도끼입니다.", 1500, ItemType.Weapon, false, 5);
            itemDatabase["스파르타의 창"] = new Weapon("스파르타의 창", "공격력+7", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 4000, ItemType.Weapon, false, 7);

            // 방어구
            itemDatabase["무쇠갑옷"] = new Armor("무쇠갑옷", "방어력+9", "무쇠로 만들어져 튼튼한 갑옷입니다.", 800, ItemType.Armor, false, 9);
            itemDatabase["수련자 갑옷"] = new Armor("수련자 갑옷", "방어력 +5", "수련에 도움을 주는 갑옷입니다.", 1000, ItemType.Armor, false, 5);
            itemDatabase["스파르타의 갑옷"] = new Armor("스파르타의 갑옷", "방어력 +15", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, ItemType.Armor, false, 15);
        }

        // 아이템 반환
        public static Weapon GetWeapon(string name) { if (itemDatabase.TryGetValue(name, out var item) && item is Weapon weapon) return weapon; else return null; }
        public static Armor GetArmor(string name) { if(itemDatabase.TryGetValue(name, out var item) && item is Armor armor) return armor; else return null; }
        public static Item GetItem(string name) { return itemDatabase.TryGetValue(name, out var item) ? item : null; }
    }
}
