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

        int isFindMonster = -1;


        public AdventureScene(int index) : base(index)
        {
        }

        public override void Init()
        {
            base.Init();

            // 오브젝트 초기화
            gameObjects.Clear();

            // 변수 초기화
            startTime = 0f;
            isFindMonster = -1;

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
            hasExecutedList["TimeSet"] = false;
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

            if(hasExecutedList["TimeSet"]) RandomEvent(10.0f);
        }

        // 랜덤 이벤트 : 일정 확률로 골드 흭득 가능
        private void RandomEvent(float duration)
        {
            // 시간 경과 초기화 : 게임 전체 시간 경과 - 함수 호출 시간 대 시간 경과
            TimeManager.Instance.LocalElapsed = TimeManager.Instance.Elapsed - startTime;

            WriteLine($"모험 시간: {TimeManager.Instance.LocalElapsed:0.#} (초)", 8);

            // duration 동안 if문 수행
            if (TimeManager.Instance.LocalElapsed < duration)
            {
                // 커서 위치 고정
                int baseLine = 10;

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
                        message = UIManager.Instance.MatchMonster();
                        int consoleWidth = Console.WindowWidth;
                        WriteLine(message, baseLine + 2);

                        if (TimeManager.Instance.LocalElapsed > 5f)
                        {
                            WriteLine(UIManager.Instance.GainGold(500), baseLine + 4);
                        }
                    }
                    else
                    {
                        // 50% 확률로 아무 일도 일어나지 않음
                        message = UIManager.Instance.NothingHappen;
                        WriteLine(message, baseLine + 2);
                    }
                }
            }
            else
            {
                // 이벤트 종료
                GameManager.Instance.LoadScene("MainScene");
            }
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
