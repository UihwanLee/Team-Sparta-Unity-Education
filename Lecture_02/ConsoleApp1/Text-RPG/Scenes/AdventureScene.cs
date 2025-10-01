using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    internal class AdventureScene : Scene
    {
        /*
         * AdventureScene: 모험 씬
         * 기본적으로 이 씬에서 보여줄 오브젝트만 관리한다.
         * 
         * [모험 기능]
         * - 게임 시작 화면에 **“랜덤 모험”** 을 추가합니다.
         * - 랜덤 모험시 스테미나 10을 소비합니다.
         * - 50% 확률 → `"몬스터 조우! 골드 500 획득"`
         * - 50% 확률 → `"아무 일도 일어나지 않았다"`
         * - 스태미나가 부족하다면 → **스태미나 가 부족합니다.** 출력
         * 
         */
        private Player player;

        float startTime = 0f;


        public AdventureScene(int index) : base(index)
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
            hasExecutedList["AdventureView"] = false;
            hasExecutedList["RandomAdventureView"] = false;
            hasExecutedList["RandomEvent"] = false;

            // 처음 View 설정: StarView
            ChangeView(AdventureView);
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

        private void AdventureView(float elapsed)
        {
            if(!hasExecutedList["AdventureView"])
            {
                UIManager.Instance.AdventureView(player);
                hasExecutedList["AdventureView"] = true;
            }

            var choice = GetUserChoice(["1", "0"]);

            // 나가기 누르면 MainScene으로 이동
            if (choice == "0")
            {
                GameManager.Instance.LoadScene("MainScene");
                return;
            }

            Action<float> view;
            // 현재 캐릭터의 스태미너가 부족하면 돌아감
            if (player.Stamina < 20)
            {
                Console.WriteLine("스태미나 가 부족합니다.");
                view = AdventureView;
            }
            else
            {
                Console.WriteLine("스태미나 20 소모되었습니다.");
                player.Stamina -= 20;
                view = RandomAdventureView;
            }

            // 3초 시간 경과 후 실행
            Thread.Sleep(3000);

            ChangeView(RandomAdventureView);
        }

        private void RandomAdventureView(float elapsed)
        {
            if (!hasExecutedList["RandomAdventureView"])
            {
                UIManager.Instance.RandomAdventureView();
                hasExecutedList["RandomAdventureView"] = true;
            }

            RandomEvent(10.0f);
        }

        private void RandomEvent(float duration)
        {
            if(!hasExecutedList["RandomEvent"])
            {
                startTime = TimeManager.Instance.Elapsed;
                hasExecutedList["RandomEvent"] = true;
            }

            TimeManager.Instance.LocalElapsed = TimeManager.Instance.Elapsed - startTime;

            if (TimeManager.Instance.LocalElapsed < duration)
            {
                // 모험중 깜빡임
                string baseText = "모험중";
                int dotCount = ((int)(TimeManager.Instance.LocalElapsed * 2) % 3) + 1; // 1~3점
                string message = baseText + new string('.', dotCount);
                Console.Write("\r" + message.PadRight(baseText.Length + 3));
            }
            else if (TimeManager.Instance.LocalElapsed > 3f && TimeManager.Instance.LocalElapsed < duration)
            {
                Console.Write("\r" + "곰이 나타남");
            }
            else
            {
                // 이벤트 종료
                ChangeView(AdventureView);
            }
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
