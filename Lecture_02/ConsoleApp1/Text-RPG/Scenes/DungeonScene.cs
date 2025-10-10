using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    public class DungeonScene : Scene
    {
        /*
         * DungeonScene: 던전 씬
         * 
         * [던전 기능]
         * - 던전은 3가지 난이도가 존재
         * - 각 던전은 권장 방어력이 존재 
         *   - 방어력보다 낮을 경우: 40% 확률 실패 / 보상 없음 체력 절반 까임
         *   - 클리어 시 체력 감소 : (기본 체력 감소량(20~35) - (내 방어력 - 권장 방어력)
         * - 각 던전은 공격력으로 보상 결정
         *   - 쉬운 던전 - 1000G, 50Exp
         *   - 일반 던전 - 1700G, 100Exp
         *   - 어려운 던전 - 2500G, 200Exp
         * - 공격력 ~ 공격력 * 2의 % 만큼 추가 보상 흭득 가능
         *   - 공격력 10 -> 보상 (10% ~ 20%) 추가 보상
         * 
         */

        // 변수 초기화
        int baseLine = 10;
        int gainGold = 0;
        string baseMessage = "";
        private float EventStartTime = 3f;
        private float EventEndTime = 6f;
        string choice = "";

        // 던전
        Dungeon current_dungeon;
        Dungeon dungeon_easy;
        Dungeon dungeon_normal;
        Dungeon dungeon_hard;

        public DungeonScene(int index, MapManager map) : base(index, map)
        {
        }

        public override void Init()
        {
            base.Init();

            // 변수 초기화
            baseLine = 10;
            gainGold = 0;
            baseMessage = "던전 탐험 중";
            EventStartTime = 3f;
            EventEndTime = 6f;

            // bool 값 초기화
            hasExecutedList.Clear();
            hasExecutedList["TimeSet"] = false;
            hasExecutedList["DungeonView"] = false;
            hasExecutedList["DungeonTravelView"] = false;
            hasExecutedList["DungeonClearView"] = false;

            // 던전 변수
            dungeon_easy = new Dungeon("쉬운 던전", 1, 5, 6f, 1000, 50);
            dungeon_normal = new Dungeon("일반 던전", 2, 11, 8f, 1700, 100);
            dungeon_hard = new Dungeon("어려운 던전", 3, 17, 10f, 2500, 200);

            // 처음 View 설정: DungeonView
            ChangeView(DungeonView);
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

        // 던전 페이지 - 던전 난이도 선택
        private void DungeonView(float elapsed)
        {
            if (!hasExecutedList["DungeonView"])
            {
                UIManager.Instance.DungeonView(map);
                hasExecutedList["DungeonView"] = true;

                choice = GetUserChoice(["0", "1", "2", "3"]);

                while (true)
                {
                    // 선택한 난이도에 따라 던전 실행
                    switch (choice)
                    {
                        case "0":
                            GameManager.Instance.LoadScene("MainScene");
                            return;
                        case "1":
                            current_dungeon = dungeon_easy;
                            break;
                        case "2":
                            current_dungeon = dungeon_normal;
                            break;
                        case "3":
                            current_dungeon = dungeon_hard;
                            break;
                        default:
                            break;
                    }

                    // 던전 입장 시도: 플레이어의 체력이 충분한지 체크
                    if (current_dungeon.TryEnter() == true) break;

                    choice = GetUserChoice(["0", "1", "2", "3"]);
                }
            }

            if (hasExecutedList["TimeSet"])
            {
                StartDungeon(current_dungeon);
            }
        }

        // 던전 시작
        private void StartDungeon(Dungeon dungeon)
        {
            if (!hasExecutedList["DungeonTravelView"])
            {
                Console.Clear();
                UIManager.Instance.DungeonTravelView();
                hasExecutedList["DungeonTravelView"] = true;
            }

            // 시간 경과 초기화 : 게임 전체 시간 경과 - 함수 호출 시간 대 시간 경과
            TimeManager.Instance.LocalElapsed = TimeManager.Instance.Elapsed - startTime;

            ConsoleHelper.WriteLine($"던전 탐험 시간: {TimeManager.Instance.LocalElapsed:0.#} (초)", 8);

            // 정해진 시간이 지나면 던전 클리어 View로 이동
            if (TimeManager.instance.LocalElapsed >= dungeon.duration)
            {
                // 던전 탐험 종료
                ChangeView(DungeonClearView);
                return;
            }

            // 던전 탐험 중 깜빡임
            ConsoleHelper.BlinkingMessageWithDot(baseLine, baseMessage);
        }

        // 던전 클리어
        private void DungeonClearView(float elapsed)
        {
            if (!hasExecutedList["DungeonClearView"])
            {
                hasExecutedList["DungeonClearView"] = true;

                UIManager.Instance.DungeonClearView(player, current_dungeon);

                // 던전 정산
                current_dungeon.Clear(player);

                UIManager.Instance.DisplayOption(["0. 나가기"]);
            }

            choice = GetUserChoice(["0"]);

            GameManager.Instance.LoadScene("MainScene");
        }



        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
