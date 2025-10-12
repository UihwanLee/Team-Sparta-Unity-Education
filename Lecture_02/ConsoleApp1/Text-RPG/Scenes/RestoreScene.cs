using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Maps;

namespace Text_RPG.Scenes
{
    public class RestoreScene : Scene
    {
        /*
         * RestoreScene: 회복 씬
         * 
         * [회복 기능]
         * - 휴식 시 500G 소모
         * - 휴식 시 체력 100, 스태미나 20 회복
         * - 단, 최대치는 넘길 수 없다.
         * 
         */

        // 변수 초기화
        int baseLine = 10;
        string baseMessage = "";
        private float EventStartTime = 3f;
        private float EventEndTime = 6f;
        string choice = "";
        private int goldRestore = 500;

        private RestoreMap map = new RestoreMap();  // 휴식 Map

        public RestoreScene(int index) : base(index)
        {
        }

        public override void Init()
        {
            base.Init();

            // 맵 그리기
            map.DrawMap();

            // 변수 초기화
            baseLine = 10;
            baseMessage = "휴식 중";
            EventStartTime = 3f;
            EventEndTime = 6f;
            goldRestore = 500;

            // bool 값 초기화
            hasExecutedList.Clear();
            hasExecutedList["TimeSet"] = false;
            hasExecutedList["RestoreView"] = false;
            hasExecutedList["RestoringView"] = false;
            hasExecutedList["RestoreEventHandle"] = false;

            // 처음 View 설정: RestoreView
            ChangeView(RestoreView);
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

        // 휴식 페이지 - 휴식 할 지 선택
        private void RestoreView(float elapsed)
        {
            if (!hasExecutedList["RestoreView"])
            {
                UIManager.Instance.RestoreView(goldRestore, player);
                hasExecutedList["RestoreView"] = true;

                choice = GetUserChoice(["0", "1"]);

                while (true)
                {
                    if (choice == "0") { GameManager.Instance.LoadScene("MainScene"); return; }

                    // 휴식 할 Gold가 충분 한지 체크
                    if (TryRestore()) break;

                    choice = GetUserChoice(["0", "1"]);
                }
            }

            // 휴식 애니메이션 
            map.DisplayMap(TimeManager.Instance.Elapsed);

            if (hasExecutedList["TimeSet"])
            {
                StartRestore(8f);
            }
        }

        // 휴식 시도
        private bool TryRestore()
        {
            if(player.Gold < goldRestore)
            {
                return false;
            }

            return true;
        }

        // 휴식 시작
        private void StartRestore(float duration)
        {
            if (!hasExecutedList["RestoringView"])
            {
                Console.Clear();
                UIManager.Instance.RestoringView();
                hasExecutedList["RestoringView"] = true;
            }

            // 시간 경과 초기화 : 게임 전체 시간 경과 - 함수 호출 시간 대 시간 경과
            TimeManager.Instance.LocalElapsed = TimeManager.Instance.Elapsed - startTime;

            ConsoleHelper.WriteLine($"휴식 시간: {TimeManager.Instance.LocalElapsed:0.#} (초)", map.endLine + 2);

            // 정해진 시간이 지나면 MainScene로 이동
            if (TimeManager.instance.LocalElapsed >= duration)
            {
                // 휴식 종료
                GameManager.Instance.LoadScene("MainScene");
                return;
            }

            // 휴식 중 깜빡임
            ConsoleHelper.BlinkingMessageWithDot(map.endLine + 4, baseMessage);

            // 이벤트 발생
            if (TimeManager.Instance.LocalElapsed > EventStartTime && TimeManager.Instance.LocalElapsed < EventEndTime)
            {
                RestoreEventHandle();
            }
        }

        private void RestoreEventHandle()
        {
            if (!hasExecutedList["RestoreEventHandle"])
            {
                hasExecutedList["RestoreEventHandle"] = true;

                // 골드 소모
                player.Gold -= goldRestore;

                // 플레이어 회복
                player.Hp = 100;
                player.Stamina = (player.Stamina + 20 > 100) ? 100 : player.Stamina + 20;
            }

            // HP 회복 표시
            ConsoleHelper.WriteLine(TextManager.Restore_Hp(100), map.endLine + 6);

            // 스태미나 회복 표시
            if (TimeManager.Instance.LocalElapsed > EventStartTime + 1)
            {
                ConsoleHelper.WriteLine(TextManager.Restore_Stamina(20), map.endLine + 8);
            }
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
