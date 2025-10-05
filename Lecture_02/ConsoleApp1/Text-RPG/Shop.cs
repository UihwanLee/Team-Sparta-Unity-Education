using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Shop
    {
        /*
         * Shop: 상점 클래스
         * 
         * [상점 기능]
         * - 필요한 아이템을 얻을 수 있습니다.
         * - Player와 마찬가지로 GameManager에서 공유
         * - 상품 리스트를 가지고 있음
         * 
         */

        private List<Item> productList;

        public Shop() 
        {
            Init();
        }

        private void Init()
        {
            // 상품 리스트 초기화
            productList = new List<Item>();
            productList.Clear();

            // 상품 리스트 채우기
            productList.Add(ItemDatabase.GetArmor("수련자 갑옷"));
            productList.Add(ItemDatabase.GetArmor("무쇠갑옷"));
            productList.Add(ItemDatabase.GetArmor("스파르타의 갑옷"));
            productList.Add(ItemDatabase.GetWeapon("낡은 검"));
            productList.Add(ItemDatabase.GetWeapon("청동 도끼"));
            productList.Add(ItemDatabase.GetWeapon("스파르타의 창"));
        }

        // 상품 목록 보여주기
        public void DisplayInfo(bool isPurchase)
        {
            Console.WriteLine("[아이템 목록]\n");
            Console.WriteLine(
                ((isPurchase) ? UIManager.Instance.PadRightForConsole(" ", 6) : $"  ") +
                $"{UIManager.Instance.PadRightForConsole("[아이템 이름]", 20)} | " +
                $"{UIManager.Instance.PadRightForConsole("[아이템 효과]", 15)} | " +
                $"[아이템 설명]\n");

            for (int i = 0; i < productList.Count; i++)
            {
                string idxTxt = (isPurchase) ? $"{i + 1} : " : "";
                Console.Write($"- {idxTxt}");
                productList[i].DisplayInfo();
            }
        }

        // 프로퍼티 변수
        public List<Item> ProductList { get { return productList; } }
    }
}
