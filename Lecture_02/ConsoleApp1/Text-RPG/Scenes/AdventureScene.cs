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
        int isFindMonster = -1;


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
            hasExecutedList["IsFindMonster"] = false;

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

        // 모험 창 : 랜덤 모험 기능 수행 가능
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
            if (player.Stamina < 20)
            {
                // 현재 캐릭터의 스태미너가 부족하면 돌아감
                Console.WriteLine("스태미나 가 부족합니다.");
                view = AdventureView;
            }
            else
            {
                // 현재 캐릭터의 스태미너가 충분하면 스태미나 20 소모
                Console.WriteLine("스태미나 20 소모되었습니다.");
                player.Stamina -= 20;
                view = RandomAdventureView;
            }

            // 3초 시간 경과 후 창 바꿈
            Thread.Sleep(3000);
            ChangeView(RandomAdventureView);
        }

        // 랜덤 모험 창 : 모험 중인 UI 띄우기
        private void RandomAdventureView(float elapsed)
        {
            if (!hasExecutedList["RandomAdventureView"])
            {
                UIManager.Instance.RandomAdventureView();
                hasExecutedList["RandomAdventureView"] = true;
            }

            RandomEvent(10.0f);
        }

        // 랜덤 이벤트 : 일정 확률로 골드 흭득 가능
        private void RandomEvent(float duration)
        {
            if(!hasExecutedList["RandomEvent"])
            {
                isFindMonster = -1;
                TimeManager.Instance.InitLocalElapsed();
                startTime = TimeManager.Instance.Elapsed;
                hasExecutedList["RandomEvent"] = true;
            }

            // 시간 경과 초기화 : 게임 전체 시간 경과 - 함수 호출 시간 대 시간 경과
            TimeManager.Instance.LocalElapsed = TimeManager.Instance.Elapsed - startTime;

            // duration 동안 if문 수행
            if(TimeManager.Instance.LocalElapsed < duration)
            {
                // 커서 위치 고정
                int baseLine = 8;

                // 모험 중 깜빡임
                string baseText = "모험중";
                int dotCount = ((int)(TimeManager.Instance.LocalElapsed * 2) % 3) + 1; // 1~3점
                string message = baseText + new string('.', dotCount);
                WriteLine(message, baseLine);

                // (4~6) 랜덤 이벤트 발생
                if (TimeManager.Instance.LocalElapsed > 4f && TimeManager.Instance.LocalElapsed < 6f)
                {
                    // 랜덤 값으로 초반에 확률을 정하고 그 다음부터는 정해진 값 실행
                    if (!hasExecutedList["IsFindMonster"])
                    {
                        Random random = new Random();
                        isFindMonster = random.Next(0, 2);

                        if(isFindMonster==1) player.Gold += 500;
                        hasExecutedList["IsFindMonster"] = true;
                    }

                    if (isFindMonster == 1)
                    {
                        // 50% 확률로 몬스터 조우 후 500G 흭득
                        message = "몬스터 조우! 골드 500G 흭득!";
                        int consoleWidth = Console.WindowWidth;
                        WriteLine(message, baseLine + 2);
                    }
                    else
                    {
                        // 50% 확률로 아무 일도 일어나지 않음
                        message = "아무 일도 일어나지 않았다";
                        WriteLine(message, baseLine + 2);
                    }
                }
            }
            else
            {
                // 이벤트 종료
                ChangeView(AdventureView);
            }
        }

        // SetCurPosition 함수를 이용한 한 줄 덮어쓰기 함수
        private void WriteLine(string message, int line)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, line);
            Console.Write(message);
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
