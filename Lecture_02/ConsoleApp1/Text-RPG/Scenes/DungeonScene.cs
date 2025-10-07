using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    internal class DungeonScene : Scene
    {
        /*
         * DungeonScene: 던전 씬
         * 
         * [던전 기능]
         * - 던전은 3가지 난이도가 존재
         * - 각 던전은 권장 방어력이 존재 
         *   - 방어력보다 낮을 경우: 40% 확률 실패 / 보상 없음 체력 절반 까임
         * - 각 던전은 공격력으로 보상 결정
         *   - 쉬운 던전 - 1000G, 50Exp
         *   - 일반 던전 - 1700G, 100Exp
         *   - 어려운 던전 - 2500G, 200Exp
         * - 공격력 ~ 공격력 * 2의 % 만큼 추가 보상 흭득 가능
         *   - 공격력 10 -> 보상 (10% ~ 20%) 추가 보상
         * 
         */
        public DungeonScene(int index) : base(index)
        {
        }

        public override void Init()
        {
            base.Init();

            // 변수 초기화

            // bool 값 초기화
            hasExecutedList.Clear();
            hasExecutedList["TimeSet"] = false;
            hasExecutedList["DungeonView"] = false;

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
                UIManager.Instance.DungeonView();
                hasExecutedList["DungeonView"] = true;
            }

            var choice = GetUserChoice(["0", "1", "2", "3"]);

            switch(choice)
            {
                case "0":
                    GameManager.Instance.LoadScene("MainScene");
                    break;
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }


        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
