using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    public class TownScene : Scene
    {

        /*
        * TownScene: 마을 씬
        * 
        * [마을 기능]
        * - 마을 순찰 하기 가능
        *  - 스태미너 5 소모
        *  - 10% 확률 → `"마을 아이들이 모여있다. 간식을 사줘볼까?"`  500 G 소비
        *  - 10% 확률 → `"촌장님을 만나서 심부름을 했다."`  2000 G 획득
        *  - 20% 확률 → `"길 읽은 사람을 안내해주었다."` 1000G 획득
        *  - 30% 확률 → `"마을 주민과 인사를 나눴다. 선물을 받았다."` 500 G 획득
        *  - 30% 확률 → `"아무 일도 일어나지 않았다"`
        * 
        */

        int eventIdx = -1;
        int gainGold = 0;
        private float EventStartTime = 3f;
        private float EventEndTime = 6f;

        private int eventOption = -1;
        private float patrolTownDuration = 8f;

        public TownScene(int index, MapManager map) : base(index, map)
        {
        }

        public override void Init()
        {
            base.Init();

            // 변수 초기화
            eventIdx = -1;
            gainGold = 0;
            EventStartTime = 3f;
            EventEndTime = 6f;
            eventOption = -1;

            // bool 값 초기화
            hasExecutedList.Clear();
            hasExecutedList["TimeSet"] = false;
            hasExecutedList["TownView"] = false;
            hasExecutedList["PatrolTownView"] = false;
            hasExecutedList["isFindEvent"] = false;

            // 처음 View 설정: TownView
            ChangeView(TownView);
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

        private void TownView(float elapsed)
        {
            if (!hasExecutedList["TownView"])
            {
                UIManager.Instance.TownView();
                hasExecutedList["TownView"] = true;

                // 이벤트 시작 타임 랜덤으로 정하기
                EventStartTime = (float)GetRadomInt(2, (int)patrolTownDuration - 4);
                EventEndTime = EventStartTime + 2.0f;
            }

            // 마을 순찰 애니메이션 
            map.DisplayPatrolTown(TimeManager.Instance.Elapsed, eventOption);

            if (hasExecutedList["TimeSet"]) PatrolTownView(patrolTownDuration);
        }

        private void PatrolTownView(float duration)
        {
            // 시간 경과 초기화 : 게임 전체 시간 경과 - 함수 호출 시간 대 시간 경과
            TimeManager.Instance.LocalElapsed = TimeManager.Instance.Elapsed - startTime;

            ConsoleHelper.WriteLine($"마을 순찰 시간: {TimeManager.Instance.LocalElapsed:0.#} (초)", map.endLine + 2);

            // 정해진 시간이 지나면 MainScene으로 이동
            if (TimeManager.instance.LocalElapsed >= duration)
            {
                // 이벤트 종료
                GameManager.Instance.LoadScene("MainScene");
                return;
            }

            // 순찰 중 깜빡임
            string baseMessage = "마을 순찰 중";
            ConsoleHelper.BlinkingMessageWithDot(map.endLine + 4, baseMessage);

            // 이벤트 발생
            if (TimeManager.Instance.LocalElapsed > EventStartTime && TimeManager.Instance.LocalElapsed < EventEndTime)
            {
                PatrolTownEventHandle();
            }
        }

        private void PatrolTownEventHandle()
        {
            // 랜덤 값으로 초반에 확률을 정하고 그 다음부터는 정해진 값 실행
            if (!hasExecutedList["isFindEvent"])
            {
                hasExecutedList["isFindEvent"] = true;
                eventIdx = GetRadomInt(1,100); // 1 ~ 100까지 랜덤 값

                // 이벤트에 따른 골드 처리
                gainGold = GetTownEventGold(eventIdx);
                player.Gold += gainGold;
            }

            // 이벤트 텍스트 표시
            ConsoleHelper.WriteLine(GetTownEventText(eventIdx), map.endLine + 6);

            // 이벤트 효과 표시
            if (TimeManager.Instance.LocalElapsed > EventStartTime + 1)
            {
                ConsoleHelper.WriteLine(TextManager.GainGold(gainGold), map.endLine + 8);
            }
        }

        // 마을 이벤트 처리 : 텍스트
        private string GetTownEventText(int value)
        {
            // 예외처리
            if (value < 0 || value > 100) return TextManager.ERROR_INDEX;

            if (value > 0 && value <= 10) return TextManager.PatrolTown_FindChild;           // 마을 아이들 이벤트
            else if (value > 10 && value <= 20) return TextManager.PatrolTown_FindHeadMan;   // 마을 촌장 이벤트
            else if (value > 20 && value <= 40) return TextManager.PatrolTown_FindHeadMan;   // 길 잃은 사람 이벤트
            else if (value > 40 && value <= 70) return TextManager.PatrolTown_FindHeadMan;   // 마을 사람 이벤트
            else return TextManager.NothingHappen;                                           // 노 이벤트
        }

        // 마을 이벤트 처리 : 골드
        private int GetTownEventGold(int value)
        {
            // 예외처리
            if (value < 0 || value > 100) return 0;

            if (value > 0 && value <= 10) { eventOption = 0; return -500; }          // 마을 아이들 이벤트
            else if (value > 10 && value <= 20) { eventOption = 1; return 200; }     // 마을 촌장 이벤트
            else if (value > 20 && value <= 40) { eventOption = 2; return 1000; }    // 길 잃은 사람 이벤트
            else if (value > 40 && value <= 70) { eventOption = 3; return 500; }     // 마을 사람 이벤트
            else { eventOption = -1; return 0; }                                      // 노 이벤트
        }
    }
}
