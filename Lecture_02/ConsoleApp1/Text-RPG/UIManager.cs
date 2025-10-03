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

        // 메인 화면
        public void MainView()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가진 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[마을]");
            Console.Write("『");
            for (int i = 0; i < width; i++) Console.Write(" ");
            for (int i = 0; i < height; i++) Console.WriteLine();
            for (int i = 0; i < width; i++) Console.Write(" ");
            Console.Write("』");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 랜덤 모험");
            Console.WriteLine("4. 마을 순찰하기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 캐릭터 정보 화면
        public void StateView(Player player)
        {
            Console.WriteLine("[캐릭터 상태]");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.Write("『");
            for (int i = 0; i < width; i++) Console.Write(" ");
            for (int i = 0; i < height; i++) Console.WriteLine();
            for (int i = 0; i < width; i++) Console.Write(" ");
            Console.Write("』");
            Console.WriteLine();
            player.ShowInfo();
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 캐릭터 인벤토리 화면
        public void InventoryView(Inventroy inventory)
        {
            Console.WriteLine("[인벤토리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            inventory.DisplayInfo(false);
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 캐릭터 인벤토리 관리 화면
        public void InventoryEquippedView(Inventroy inventory)
        {
            Console.WriteLine("[인벤토리 - 장착 관리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            inventory.DisplayInfo(true);
            Console.WriteLine();
            Console.WriteLine("(번호). 해당 장비 장착");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>

        // 랜덤 모험
        public void AdventureView(Player player)
        {
            Console.WriteLine("[랜덤 모험]");
            Console.Write("『");
            for (int i = 0; i < width; i++) Console.Write(" ");
            for (int i = 0; i < height; i++) Console.WriteLine();
            for (int i = 0; i < width; i++) Console.Write(" ");
            Console.Write("』");
            Console.WriteLine();
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // 마을 순찰
        public void TownView()
        {
            Console.WriteLine("[마을 순찰]");
            Console.Write("『");
            for (int i = 0; i < width; i++) Console.Write(" ");
            for (int i = 0; i < height; i++) Console.WriteLine();
            for (int i = 0; i < width; i++) Console.Write(" ");
            Console.Write("』");
            Console.WriteLine();
        }

        // 오류 메세지
        public void MessageError()
        {
            Console.WriteLine("잘못된 입력입니다");
        }

        /// <summary>
        /// -------------------------------------------------------------------------------------------------------
        /// </summary>
        ///

        // Text 관리
        public string NoStamina = "스태미나가 부족합니다.";
        public string UseStamin(int stamina) { return $"스태미나 {stamina} 소모되었습니다."; }
        public string MatchMonsterAndGainGold(int gold) { return $"몬스터 조우! 골드 {gold}G 흭득!"; }
        public string NothingHappen = "아무 일도 일어나지 않았다";
    }
}
