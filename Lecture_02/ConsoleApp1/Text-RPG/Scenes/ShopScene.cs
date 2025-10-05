using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    internal class ShopScene : Scene
    {
        /*
         * ShopScene: 상점 씬
         * 
         * [상점 기능]
         * - 필요한 아이템을 얻을 수 있습니다.
         * - Shop 클래스 보유
         * 
         */

        private Shop shop;

        public ShopScene(int index) : base(index)
        {
        }

        public override void Init()
        {
            base.Init();

            // bool 초기화
            hasExecutedList["ShopView"] = false;
            hasExecutedList["ShopPurchaseView"] = false;

            // Shop 설정
            this.shop = GameManager.Instance.GetShop();

            // 처음 View 설정: InventoryView
            ChangeView(ShopView);
        }

        public override void Start()
        {
            base.Start();

            // 초기화 (모든 값 false로)
            foreach (var key in hasExecutedList.Keys.ToList())
            {
                hasExecutedList[key] = false;
            }
        }

        public override void Update(float elapsed)
        {
            base.Update(elapsed);

            // 오브젝트 업데이트
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(elapsed);
            }

            currentView?.Invoke(elapsed);
        }

        private void ShopView(float elapsed)
        {
            if (!hasExecutedList["ShopView"])
            {
                UIManager.Instance.ShopView(player, shop);
                hasExecutedList["ShopView"] = true;
            }

            var choice = GetUserChoice(["0", "1"]);

            if (choice == "0") { GameManager.Instance.LoadScene("MainScene"); return; }

            // 아이템 구매
            ChangeView(ShopPurchaseView);
        }

        private void ShopPurchaseView(float elapsed)
        {
            if (!hasExecutedList["ShopPurchaseView"])
            {
                UIManager.Instance.ShopPurchaseView(player, shop);
                hasExecutedList["ShopPurchaseView"] = true;
            }

            int vaildCount = shop.ProductList.Count;
            string[] vaildItemOption = Enumerable.Range(0, vaildCount + 1).Select(i => i.ToString()).ToArray();   // LINQ 문법
            var choice = GetUserChoice(vaildItemOption);

            if (choice == "0") { ChangeView(ShopView); return; }

            // 아이템 구매
            while(true)
            {
                if(shop.PurchaseItemByIdx(int.Parse(choice)-1)==true)
                {
                    break;
                }

                choice = GetUserChoice(vaildItemOption);
            }

            // 구매가 완료 되었으면 1초 후 갱신
            Thread.Sleep(1000);
            ChangeView(ShopPurchaseView);
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
