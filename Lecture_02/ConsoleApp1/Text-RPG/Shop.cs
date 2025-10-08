using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Text_RPG
{
    public class Shop
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

        private List<Item> productList = new List<Item>();
        private float saleRate = 0.85f;     // 판매 가격 환율

        public Shop() 
        {
            Init();
        }

        // Shop 정보 저장
        public SaveData ToSaveData(SaveData saveData)
        {
            saveData.shopProductList = this.productList;

            return saveData;
        }

        // SavaData 저장 데이터 복원
        public void LoadFromSaveData(SaveData saveData)
        {
            this.productList = saveData.shopProductList;
        }

        private void Init()
        {
            // 상품 리스트 초기화
            productList.Clear();

            // 상품 리스트 채우기
            productList.Add(ItemDatabase.GetArmor("수련자 갑옷"));
            productList.Add(ItemDatabase.GetArmor("무쇠갑옷"));
            productList.Add(ItemDatabase.GetArmor("스파르타의 갑옷"));
            productList.Add(ItemDatabase.GetWeapon("낡은 검"));
            productList.Add(ItemDatabase.GetWeapon("청동 도끼"));
            productList.Add(ItemDatabase.GetWeapon("스파르타의 창"));
        }

        // 상품 구매 시도 - 인덱스 검색
        public bool TryPurchaseItem(int idx)
        {
            if (productList.Count <= 0 || idx >= productList.Count) return false;

            // 이미 구매한 상품이라면 구매한 아이템입니다 출력
            if (productList[idx].isPurchase)
            {
                Console.WriteLine(UIManager.Instance.Shop_Already_Purchase);
                return false;
            }

            // 플레이어의 골드가 충분한지 체크
            Player player = GameManager.Instance.GetPlayer();
            if(player.Gold < productList[idx].price)
            {
                Console.WriteLine(UIManager.Instance.Not_Enough_Gold);
                return false;
            }

            // 아이템 구매
            PurchaseItem(productList[idx]);
            return true;
        }

        // 상품 구매
        public void PurchaseItem(Item item)
        {
            item.isPurchase = true;
            Player player = GameManager.Instance.GetPlayer();

            // 상품 품목의 복제본을 player에게 전달
            player.PurchaseItem(item.Clone());

            Console.WriteLine(UIManager.Instance.Shop_Success_Purchase);
        }

        // 상품 판매 시도 - 인덱스 검색
        public bool TrySaleItem(int idx)
        {
            Player player = GameManager.Instance.GetPlayer();
            if (player.Inventroy.Items.Count <= 0 || idx >= player.Inventroy.Items.Count) return false;

            // 아이템 판매
            SailItem(idx);
            return true;
        }

        // 상품 구매
        public void SailItem(int idx)
        {
            Player player = GameManager.Instance.GetPlayer();

            // 이미 장착 중인 아이템이라면 장착 해제
            if (player.Inventroy.Items[idx].isEquipped)
            {
                player.Inventroy.Items[idx].EquipItem(player, false);
            }

            // 판매 골드 흭득 : 85%
            player.Gold += (int)(player.Inventroy.Items[idx].price * saleRate);

            // 판매 및 골드 흭득 메세지 출력
            Console.WriteLine(UIManager.Instance.Shop_Success_Sale(player.Inventroy.Items[idx]));

            // 플레이어 인벤토리에서 삭제
            player.Inventroy.Items.RemoveAt(idx);
        }

        // 상품 목록 보여주기
        public void DisplayInfo(bool isPurchase)
        {
            Console.WriteLine("[아이템 목록]\n");
            string purchase = (isPurchase) ? UIManager.Instance.PadRightForConsole(" ", 6) : $"  ";

            Console.WriteLine(
                string.Format("{0}{1} | {2} | {3} | {4}",
                purchase,
                UIManager.Instance.PadRightForConsole("[아이템 이름]", 20),
                UIManager.Instance.PadRightForConsole("[아이템 효과]", 15),
                UIManager.Instance.PadRightForConsole("[아이템 설명]", 50),
                "[아이템 가격]\n"));

            for (int i = 0; i < productList.Count; i++)
            {
                string idxTxt = (isPurchase) ? $"{i + 1} : " : "";
                Console.Write($"- {idxTxt}");
                productList[i].DisplayInfoProduct();
            }
        }

        // 프로퍼티 변수
        public List<Item> ProductList { get { return productList; } set { productList = value; } }
    }
}
