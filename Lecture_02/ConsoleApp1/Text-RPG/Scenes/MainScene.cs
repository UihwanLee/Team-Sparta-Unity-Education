using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    internal class MainScene : Scene
    {
        /*
         * MainScene: 초기 상태를 확인할 수 있는 씬
         * 기본적으로 이 씬에서 보여줄 오브젝트만 관리한다.
         * 
         * 다만 모든 오브젝트는 start(), update()를 실행한다.
         * 
         * [StartScene 정보]
         * 0: StartView                 - 게임 시작 창
         * 1: StateView                 - 플레이어 스탯 정보 창
         * 2: InventoryView             - 인벤토리 창
         * 3: InventoryEquippedView     - 인벤토리 관리 창
         * 
         */

        private Player player;    // 이 Scene에서 사용할 Character

        private Action currentView;   // 현재 창 (시작창, 스탯창 등)

        public MainScene(int index) : base(index)
        {

        }

        public override void Start()
        {
            base.Start();

            // 오브젝트 초기화
            gameObjects.Clear();

            // 캐릭터 추가
            player = GameManager.Instance.GetPlayer();
            gameObjects.Add(player);

            // 오브젝트 초기화
            foreach (var gameObject in gameObjects)
            {
                gameObject.Start();
            }

            // 처음 View 설정: StarView
            currentView = MainView;
        }

        public override void Update()
        {
            base .Update();

            // 오브젝트 업데이트
            foreach(var gameObject in gameObjects)
            {
                gameObject.Update();
            }

            // View 변할 때 마다 실행
            currentView?.Invoke();
        }

        // 메뉴 열기
        private void MainView()
        {
            Console.Clear();
            UIManager.Instance.MainView();
            var choice = GetUserChoice(["1", "2"]);
            currentView = choice == "1" ? StateView : InventoryView;
        }

        // 상태 보기
        private void StateView()
        {
            Console.Clear();
            UIManager.Instance.StateView(player);
            var choice = GetUserChoice(["0"]);
            currentView =MainView;
        }

        // 인벤토리 보기
        private void InventoryView()
        {
            Console.Clear();
            UIManager.Instance.InventoryView(player.Inventroy);
            var choice = GetUserChoice(["0", "1"]);
            currentView = choice == "0" ? MainView : InventoryEquippedView;
        }

        // 인벤토리 - 장착 관리
        private void InventoryEquippedView()
        {
            Console.Clear();
            int equippedIdx = 0;
            UIManager.Instance.InventoryEquippedView(player.Inventroy);

            // 선택 가능한 장비 배열 만들기
            int vaildCount = player.Inventroy.Items.Count;
            string[] vaildItemOption = Enumerable.Range(0, vaildCount+1).Select(i => i.ToString()).ToArray();   // LINQ 문법
            var choice = GetUserChoice(vaildItemOption);

            // 나가기 설정
            if(choice=="0") { currentView = MainView; return; }

            // 인벤토리에서 idx로 검색하여 해당 아이템 장착
            equippedIdx = int.Parse(choice.ToString());
            player.Inventroy.EquippedItemByIdx(equippedIdx - 1);

            // 창 변경
            currentView = InventoryEquippedView;
        }

        // 옵션 메뉴 창만 따로 빼기
        private string GetUserChoice(string[] vaildOptions)
        {
            string choice;
            while(true) {
                Console.Write(">> ");
                choice = Console.ReadLine();
                Console.WriteLine();

                foreach (var option in vaildOptions) if (choice == option) return choice;

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
