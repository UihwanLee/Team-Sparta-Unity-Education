using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Maps;

namespace Text_RPG.Scenes
{
    public class TrainingScene : Scene
    {
        /*
         * TrainingScene: 훈련하기 씬
         * 
         * [훈련 기능]
         * - 훈련시 스태미나 15 소비
         * - 15% 확률 → "훈련이 잘 되었습니다!" 획득경험치 60 
         * - 60% 확률 → "오늘하루 열심히 훈련했습니다." 획득경험치 40
         * - 25% 확률 → "하기 싫다... 훈련이..." 획득경험치 30
         * 
         */
        public TrainingScene(int index) : base(index)
        {
        }

        private int eventIdx = 0;
        private int gainExp = 0;
        private float EventStartTime = 3f;
        private float EventEndTime = 6f;
        private int eventOption = 0;

        private float restoreDuration = 6.0f;

        private TrainingMap map = new TrainingMap();  // 훈련 Map

        public override void Init()
        {
            base.Init();

            // 맵 그리기
            map.DrawMap();

            // 캐릭터 추가
            player = GameManager.Instance.GetPlayer();
            gameObjects.Add(player);

            // bool 값 초기화
            hasExecutedList.Clear();
            hasExecutedList["TimeSet"] = false;
            hasExecutedList["TrainingView"] = false;
            hasExecutedList["isFindEvent"] = false;

            // 변수 초기화
            eventIdx = 0;
            gainExp = 0;
            EventStartTime = 3f;
            EventEndTime = 6f;
            eventOption = 0;

            // 처음 View 설정: StarView
            ChangeView(TrainingView);
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

        // 훈련 창 : 훈련 후 경험치 흭득 가능
        private void TrainingView(float elapsed)
        {
            if (!hasExecutedList["TrainingView"])
            {
                UIManager.Instance.TrainingView();
                hasExecutedList["TrainingView"] = true;

                // 이벤트 시작 타임 랜덤으로 정하기
                EventStartTime = (float)GetRadomInt(2, (int)restoreDuration - 2);
                EventEndTime = EventStartTime + 2.0f;
            }

            // 운동 애니메이션 
            map.DisplayMap(TimeManager.Instance.Elapsed, eventOption);

            if (hasExecutedList["TimeSet"]) TrainingEvent(restoreDuration);
        }

        // 랜덤 이벤트 : 일정 확률로 골드 흭득 가능
        private void TrainingEvent(float duration)
        {
            // 시간 경과 초기화 : 게임 전체 시간 경과 - 함수 호출 시간 대 시간 경과
            TimeManager.Instance.LocalElapsed = TimeManager.Instance.Elapsed - startTime;

            ConsoleHelper.WriteLine($"훈련 시간: {TimeManager.Instance.LocalElapsed:0.#} (초)", map.endLine + 2);

            // 정해진 시간이 지나면 MainScene으로 이동
            if(TimeManager.instance.LocalElapsed >= duration)
            {
                // 이벤트 종료
                GameManager.Instance.LoadScene("MainScene");
                return;
            }

            // 훈련 중 깜빡임
            string baseMessage = "훈련 중";
            ConsoleHelper.BlinkingMessageWithDot(map.endLine + 4, baseMessage);

            // 이벤트 발생
            if (TimeManager.Instance.LocalElapsed > EventStartTime && TimeManager.Instance.LocalElapsed < EventEndTime)
            {
                TrainingEventHandle();
            }
        }

        private void TrainingEventHandle()
        {
            // 랜덤 값으로 초반에 확률을 정하고 그 다음부터는 정해진 값 실행
            if (!hasExecutedList["isFindEvent"])
            {
                hasExecutedList["isFindEvent"] = true;
                eventIdx = GetRadomInt(1,100); // 1 ~ 100까지 랜덤 값

                // 이벤트에 따른 경험치 처리
                gainExp = GetTrainingEventExp(eventIdx);
                player.Exp += gainExp;
            }

            // 이벤트 텍스트 표시
            ConsoleHelper.WriteLine(GetTrainingEventText(eventIdx), map.endLine + 6);

            // 이벤트 효과 표시
            if (TimeManager.Instance.LocalElapsed > EventStartTime + 1)
            {
                ConsoleHelper.WriteLine(TextManager.GainExp(gainExp), map.endLine + 8);
            }
        }

        private string GetTrainingEventText(int value)
        {
            // 예외처리
            if (value < 0 || value > 100) return TextManager.ERROR_INDEX;

            if (value > 0 && value <= 15) return TextManager.Training_GreatSuccess;          // 훈련 대성공 이벤트
            else if (value > 15 && value <= 75) return TextManager.Training_Success;         // 훈련 성공 이벤트
            else return TextManager.Training_Fail;                                           // 훈련 실패 이벤트
        }

        // 마을 이벤트 처리 : 경험치
        private int GetTrainingEventExp(int value)
        {
            // 예외처리
            if (value < 0 || value > 100) return 0;

            if (value > 0 && value <= 15) { eventOption = 1; return 60; }            // 훈련 대성공 이벤트
            else if (value > 15 && value <= 75) { eventOption = 0; return 40; }      // 훈련 성공 이벤트
            else { eventOption = 2; return 30; }                                     // 훈련 실패 이벤트
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
