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

        private int width = 20;
        private int height = 5;

        public UIManager() { }

        private void DisplayScreen()
        {
            Console.Write("『");
            for (int i = 0; i < width; i++) Console.Write(" ");
            for (int i = 0; i < height; i++) Console.WriteLine();
            for (int i = 0; i < width; i++) Console.Write(" ");
            Console.Write("』");
            Console.WriteLine();
        }

        private void DisplayOption(string[] options)
        {
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 메인 화면
        public void MainView()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가진 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[마을]");
            DisplayScreen();
            DisplayOption(["1. 상태 보기", "2. 인벤토리", "3. 랜덤 모험", "4. 마을 순찰하기", "5. 훈련하기", "6. 상점"]);
        }

        // 캐릭터 정보 화면
        public void StateView(Player player)
        {
            Console.WriteLine("[캐릭터 상태]");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            DisplayScreen();
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
            DisplayScreen();
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // 마을 순찰
        public void TownView()
        {
            Console.WriteLine("[마을 순찰]");
            DisplayScreen();
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // 훈련
        public void TrainingView()
        {
            Console.WriteLine("[훈련]");
            DisplayScreen();
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

        // 오류 메세지
        public void MessageError()
        {
            Console.WriteLine("잘못된 입력입니다");
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // Text 관리 : 공통
        public string NoStamina = "스태미나가 부족합니다.";
        public string UseStamin(int stamina) { return $"스태미나 {stamina} 소모되었습니다."; }
        public string NothingHappen = "아무 일도 일어나지 않았다";
        public string Entering = "입장중...";

        public string ERROR_INDEX = "인덱스 에러";

        public string GainGold(int gold) { return (gold >= 0) ? $"{gold}G 흭득" : $"{gold}G 소모"; }
        public string GainExp(int exp) { return$"{exp}exp 흭득"; }


        // Text 관리 : 모험
        public string MatchMonster = "몬스터 조우!"; 

        // Text 관리 : 마을 순찰
        public string PatrolTown_FindChild = "마을 아이들이 모여있다. 간식을 사줘볼까?";
        public string PatrolTown_FindHeadMan = "촌장님을 만나서 심부름을 했다.";
        public string PatrolTown_LostMan = "길 읽은 사람을 안내해주었다.";
        public string PatrolTown_FindPeople = "마을 주민과 인사를 나눴다. 선물을 받았다.";

        // Text 관리 : 훈련
        public string Training_GreatSuccess = "훈련이 잘 되었습니다!";
        public string Training_Success = "오늘하루 열심히 훈련했습니다.";
        public string Training_Fail = "하기 싫다... 훈련이...";

        // Text 관리 : 상점
        public string Shop_Already_Purchase = "이미 구매한 아이템입니다.";
        public string Shop_Success_Purchase = "구매를 완료했습니다.";
        public string Not_Enough_Gold = "Gold가 부족합니다.";

        public string Shop_Success_Sale = "판매를 완료했습니다.";

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // SetCurPosition 함수를 이용한 한 줄 덮어쓰기 함수
        public void WriteLine(string message, int line)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, line);
            Console.Write(message);
        }

        // 문자열 깜빡임 애니메이션
        public void BlinkingMessageWithDot(int baseLine, string baseMessage)
        {
            int dotCount = ((int)(TimeManager.Instance.LocalElapsed * 2) % 3) + 1; // 1~3점
            string message = baseMessage + new string('.', dotCount);
            WriteLine(message, baseLine);
        }

        // 문자열 실제 표시 폭 계산 (한글 2칸, 알파벳 1칸 가정)
        public int GetDisplayWidth(string text)
        {
            int width = 0;
            foreach (char c in text)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter) width += 2; // 한글 등 넓은 글자
                else width += 1; // 알파벳, 숫자 등
            }
            return width;
        }

        // 문자열을 특정 칸에 맞춰 정렬
        public string PadRightForConsole(string text, int totalWidth)
        {
            int pad = totalWidth - GetDisplayWidth(text);
            if (pad > 0) return text + new string(' ', pad);
            else return text;
        }
    }
}
