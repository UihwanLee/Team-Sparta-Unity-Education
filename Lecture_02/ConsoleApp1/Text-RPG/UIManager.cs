using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class UIManager
    {
        /*
          * UIManager 스크립트
          * 
          * 게임에 나오는 내용들이 UI등을 관리하는 스크립트이다.
          * 
          * UIManager 객체는 단 한게 밖에 없으며
          * 어디서든 사용할 수 있다.
          * 
          */

        // 싱글톤 생성
        private static UIManager instance;

        public static UIManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new UIManager();
                }
                return instance;
            }
        }

        public UIManager() { }

        public void DisplayOption(string[] options)
        {
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 메인 화면
        public void MainView(MapManager map)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가진 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[마을]");
            map.DisplayTown();
            DisplayOption(["1. 상태 보기", "2. 인벤토리", "3. 랜덤 모험", "4. 마을 순찰하기", 
                           "5. 훈련하기", "6. 상점", "7. 던전 입장", "8. 휴식하기", "9. 게임 로드", " ", "0. 저장"]);
        }

        // 캐릭터 정보 화면
        public void StateView(Player player)
        {
            Console.WriteLine("[캐릭터 상태]");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            player.ShowInfo();
            Console.WriteLine();
            DisplayOption(["0. 나가기"]);
        }

        // 캐릭터 인벤토리 화면
        public void InventoryView(Inventroy inventory)
        {
            Console.WriteLine("[인벤토리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            inventory.DisplayInfo(false);
            Console.WriteLine();
            DisplayOption(["1. 장착 관리", "2. 아이템 정렬", "0. 나가기"]);
        }

        // 캐릭터 인벤토리 관리 화면
        public void InventoryEquippedView(Inventroy inventory)
        {
            Console.WriteLine("[인벤토리 - 장착 관리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            inventory.DisplayInfo(true);
            Console.WriteLine();
            DisplayOption(["(번호). 해당 장비 장착", "0. 나가기"]);
        }

        // 캐릭터 인벤토리 정렬 화면
        public void InventorySortingView(Inventroy inventory)
        {
            Console.WriteLine("[인벤토리 - 아이템 정렬]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            inventory.DisplayInfo(false);
            Console.WriteLine();
            DisplayOption(["1. 이름", "2. 장착순", "3. 공격력", "4. 방어력", "0. 나가기"]);
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>

        // 랜덤 모험
        public void AdventureView(Player player)
        {
            Console.WriteLine("[랜덤 모험]");
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // 마을 순찰
        public void TownView()
        {
            Console.WriteLine("[마을 순찰]");
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // 훈련
        public void TrainingView()
        {
            Console.WriteLine("[훈련]");;
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // 상점
        public void ShopView(Player player, Shop shop)
        {
            Console.WriteLine("[상점]");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();
            shop.DisplayInfo(false);
            Console.WriteLine();
            DisplayOption(["1. 아이템 구매", "2. 아이템 판매", "0. 나가기"]);
        }

        // 상점 : 상품 구매
        public void ShopPurchaseView(Player player, Shop shop)
        {
            Console.WriteLine("[상점 - 아이템 구매]");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();
            shop.DisplayInfo(true);
            Console.WriteLine();
            DisplayOption(["(번호). 해당 아이템 구매", "0. 나가기"]);
        }

        // 상점 : 아이템 판매
        public void ShopSaleView(Player player)
        {
            Console.WriteLine("[상점 - 아이템 판매]");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G");
            Console.WriteLine();
            player.Inventroy.DisplayInfoWithGold();
            Console.WriteLine();
            DisplayOption(["(번호). 해당 아이템 판매", "0. 나가기"]);
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // 던전
        public void DungeonView(MapManager map)
        {
            Console.WriteLine("[던전입장]");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            map.DisplayDungeon();
            Console.WriteLine();
            Console.WriteLine(string.Format("{0} | 방어력 {1}이상 권장", ConsoleHelper.PadRightForConsole("1. 쉬운 던전", 15), 5));
            Console.WriteLine(string.Format("{0} | 방어력 {1}이상 권장", ConsoleHelper.PadRightForConsole("2. 일반 던전", 15), 11));
            Console.WriteLine(string.Format("{0} | 방어력 {1}이상 권장", ConsoleHelper.PadRightForConsole("3. 어려운 던전", 15), 17));
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 던전 탐험
        public void DungeonTravelView()
        {
            Console.WriteLine("[던전 탐험]");
        }

        // 던전 클리어
        public void DungeonClearView(Player player, Dungeon dungeon)
        {
            Console.WriteLine("[던전 클리어]");
            Console.WriteLine("축하합니다!!");
            Console.WriteLine($"{dungeon.Name}을 클리어 하였습니다.");
            Console.WriteLine();
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {player.Hp} -> {player.Hp-dungeon.GetLoseHp()}");
            Console.WriteLine($"Gold {player.Gold} -> {player.Gold+dungeon.GetRewardGold()}");
            Console.WriteLine();
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // 휴식
        public void RestoreView(int restoreGold, Player player)
        {
            Console.WriteLine("[휴식하기]");
            Console.WriteLine($"{restoreGold} G를 내면 체력을 회복할 수 있습니다. (보유 골드: {player.Gold} G)");
            Console.WriteLine();
            DisplayOption(["1. 휴식하기", "0. 나가기"]);
        }

        // 휴식 중
        public void RestoringView()
        {
            Console.WriteLine("[휴식 중]");
        }
    }
}
