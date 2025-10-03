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

        public MainScene(int index) : base(index)
        {

        }

        public override void Init()
        {
            base.Init();

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

            // bool 값 초기화
            hasExecutedList.Clear();
            hasExecutedList["MainView"] = false;

            // 처음 View 설정: StarView
            ChangeView(MainView);
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
            base .Update(elapsed);

            // 오브젝트 업데이트
            foreach(var gameObject in gameObjects)
            {
                gameObject.Update(elapsed);
            }

            currentView?.Invoke(elapsed);
        }

        // 메인 메뉴 : 플레이어가 번호 지정을 통해 여러 행동을 할 수 있는 메인 창
        private void MainView(float elapsed)
        {
            if (!hasExecutedList["MainView"])
            {
                UIManager.Instance.MainView();
                hasExecutedList["MainView"] = true;
            }

            var choice = GetUserChoice(["1", "2", "3"]);

            // MainView 분기점
            switch (choice)
            {
                case "1": // 캐릭터 정보 창
                    Console.Clear();
                    ChangeView(StateView);
                    break;
                case "2": // 캐릭터 인벤토리 창
                    Console.Clear();
                    ChangeView(InventoryView);
                    break;
                case "3": // 모험 씬으로 이동
                    GameManager.Instance.LoadScene("AdventureScene");
                    break;
                default:
                    break;
            }
        }

        // 플레이어 스탯 창 : 플레이어의 스탯을 볼 수 있는 창
        private void StateView(float elapsed)
        {
            UIManager.Instance.StateView(player);
            var choice = GetUserChoice(["0"]);
            ChangeView(MainView);
        }

        // 플레이어 인벤토리 창 : 플레이어의 인벤토리를 볼 수 있는 창. 아이템을 확인 할 수 있다.
        private void InventoryView(float elapsed)
        {
            UIManager.Instance.InventoryView(player.Inventroy);
            var choice = GetUserChoice(["0", "1"]);

            if (choice == "0") ChangeView(MainView);
            else ChangeView(InventoryEquippedView);
        }

        // 플레이어 인벤토리 관리 창 : 플레이어의 아이템을 장착/해제 할 수 있다.
        private void InventoryEquippedView(float elapsed)
        {
            Console.Clear();
            int equippedIdx = 0;
            UIManager.Instance.InventoryEquippedView(player.Inventroy);

            // 선택 가능한 장비 배열 만들기
            int vaildCount = player.Inventroy.Items.Count;
            string[] vaildItemOption = Enumerable.Range(0, vaildCount+1).Select(i => i.ToString()).ToArray();   // LINQ 문법
            var choice = GetUserChoice(vaildItemOption);

            // 나가기 설정
            if(choice=="0") { ChangeView(MainView); return; }

            // 인벤토리에서 idx로 검색하여 해당 아이템 장착
            equippedIdx = int.Parse(choice.ToString());
            player.Inventroy.EquippedItemByIdx(equippedIdx - 1);

            // 창 변경
            ChangeView(InventoryEquippedView);
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
