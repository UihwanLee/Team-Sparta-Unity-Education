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

            // bool 값 초기화
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

            var choice = GetUserChoice(["1", "2", "3", "4", "5"]);

            // MainView 분기점
            switch (choice)
            {
                case "1": // 캐릭터 정보 창
                    GameManager.Instance.LoadScene("StateScene");
                    break;
                case "2": // 캐릭터 인벤토리 창
                    GameManager.Instance.LoadScene("InventoryScene");
                    break;
                case "3": // 모험 씬으로 이동
                    CheckStamina(20, "AdventureScene");
                    break;
                case "4": // 마을 씬으로 이동
                    CheckStamina(5, "TownScene");
                    break;
                case "5": // 훈련 씬으로 이동
                    CheckStamina(15, "TrainingScene");
                    break;
                default:
                    break;
            }
        }

        // 스태미나 체크 후 해당 씬 로드
        private void CheckStamina(int stanima, string loadScene)
        {
            string scene;
            if (player.Stamina < stanima)
            {
                // 현재 캐릭터의 스태미너가 부족하면 돌아감
                Console.WriteLine(UIManager.Instance.NoStamina);
                Console.WriteLine();
                Console.WriteLine(UIManager.Instance.Entering);
                scene = "MainScene";
            }
            else
            {
                // 현재 캐릭터의 스태미너가 충분하면 스태미나 소모
                Console.WriteLine(UIManager.Instance.UseStamin(5));
                Console.WriteLine();
                Console.WriteLine(UIManager.Instance.Entering);
                player.Stamina -= stanima;
                scene = loadScene;
            }

            // 3초 시간 경과 후 창 바꿈
            Thread.Sleep(3000);
            GameManager.Instance.LoadScene(scene);
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
