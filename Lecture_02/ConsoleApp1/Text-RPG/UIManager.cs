using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  * UIManager 스크립트
  * 
  * 게임에 나오는 내용들이 UI등을 관리하는 스크립트이다.
  * 
  * UIManager 객체는 단 한게 밖에 없으며
  * 어디서든 사용할 수 있다.
  * 
  */
namespace Text_RPG
{
    internal class UIManager
    {
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

        // 메인 화면
        public void MainView()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가진 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 랜덤 모험");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 캐릭터 정보 화면
        public void StateView(Player player)
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
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
            Console.WriteLine("인벤토리");
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
            Console.WriteLine("인벤토리 - 장착 관리");
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
        
        // 모험 화면
        public void AdventureView(Player player)
        {
            int width = 20;
            int height = 5;
            Console.WriteLine("[모험 패널]");
            Console.Write("『");
            for (int i = 0; i < width; i++) Console.Write(" ");
            for (int i = 0; i < height; i++) Console.WriteLine();
            for (int i = 0; i < width; i++) Console.Write(" ");
            Console.Write("』");
            Console.WriteLine();
            Console.WriteLine($"현재 스태미나: {player.Stamina}");
            Console.WriteLine("1. 랜덤 모험");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }

        // 랜덤 모험
        public void RandomAdventureView()
        {
            int width = 20;
            int height = 5;
            Console.WriteLine("[랜덤 모험]");
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
    }
}
