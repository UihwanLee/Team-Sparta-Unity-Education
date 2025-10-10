using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    public class AdventureScene : Scene
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

        bool isFindMonster = false; // 몬스터 조우 bool 값
        int eventIdx = -1;
        int baseLine = 10;
        int gainGold = 0;
        string baseMessage = "";
        private float EventStartTime = 3f;
        private float EventEndTime = 6f;

        private float adventureDuration = 8.0f; // 랜덤 모험 duration

        public AdventureScene(int index, MapManager map) : base(index, map)
        {
        }

        public override void Init()
        {
            base.Init();

            // 변수 초기화
            eventIdx = -1;
            baseLine = 10;
            gainGold = 0;
            baseMessage = "모험 중";
            EventStartTime = 3f;
            EventEndTime = 6f;
            isFindMonster = false;

            // bool 값 초기화
            hasExecutedList.Clear();
            hasExecutedList["TimeSet"] = false;
            hasExecutedList["AdventureView"] = false;
            hasExecutedList["RandomAdventureView"] = false;
            hasExecutedList["RandomEvent"] = false;
            hasExecutedList["isFindEvent"] = false;

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

                // 이벤트 시작 타임 랜덤으로 정하기
                EventStartTime = (float)GetRadomInt(2, (int)adventureDuration - 4);
                EventEndTime = EventStartTime + 2.0f;
            }

            // 모험 애니메이션 
            map.DisplayAdventure(TimeManager.Instance.Elapsed, isFindMonster);

            if(hasExecutedList["TimeSet"]) RandomEvent(adventureDuration);
        }

        // 랜덤 이벤트 : 일정 확률로 골드 흭득 가능
        private void RandomEvent(float duration)
        {
            // 시간 경과 초기화 : 게임 전체 시간 경과 - 함수 호출 시간 대 시간 경과
            TimeManager.Instance.LocalElapsed = TimeManager.Instance.Elapsed - startTime;

            ConsoleHelper.WriteLine($"모험 시간: {TimeManager.Instance.LocalElapsed:0.#} (초)", 8);

            // 정해진 시간이 지나면 MainScene으로 이동
            if (TimeManager.instance.LocalElapsed >= duration)
            {
                // 이벤트 종료
                GameManager.Instance.LoadScene("MainScene");
                return;
            }

            // 모험 중 깜빡임
            baseMessage = "모험 중";
            ConsoleHelper.BlinkingMessageWithDot(baseLine, baseMessage);

            // 이벤트 발생
            if(TimeManager.Instance.LocalElapsed > EventStartTime && TimeManager.Instance.LocalElapsed < EventEndTime)
            {
                AdventureEventHandle();
            }
        }

        private void AdventureEventHandle()
        {
            // 랜덤 값으로 초반에 확률을 정하고 그 다음부터는 정해진 값 실행
            if (!hasExecutedList["isFindEvent"])
            {
                hasExecutedList["isFindEvent"] = true;
                eventIdx = GetRadomInt(1,100);

                isFindMonster = (eventIdx <= 50);

                gainGold = GetAdventureEventGold(eventIdx);
                player.Gold += gainGold;
            }

            // 이벤트 텍스트 표시
            ConsoleHelper.WriteLine(GetAdventureEventText(eventIdx), baseLine + 2);

            // 이벤트 효과 표시
            if (TimeManager.Instance.LocalElapsed > EventStartTime + 1)
            {
                ConsoleHelper.WriteLine(TextManager.GainGold(gainGold), baseLine + 4);
            }
        }

        private string GetAdventureEventText(int value)
        {
            // 예외처리
            if (value < 0 || value > 100) return TextManager.ERROR_INDEX;

            if (value > 0 && value <= 50) return TextManager.MatchMonster;               // 몬스터 조우 이벤트
            else return TextManager.NothingHappen;                                       // 몬스터 조우 실패 이벤트
        }

        private int GetAdventureEventGold(int value)
        {
            // 예외처리
            if (value < 0 || value > 100) return 0;

            if (value > 0 && value <= 50) return 500;           // 몬스터 조우 이벤트
            else return 0;                                      // 몬스터 조우 실패 이벤트
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
