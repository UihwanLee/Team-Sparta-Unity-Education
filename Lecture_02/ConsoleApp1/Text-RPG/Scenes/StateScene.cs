using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    public class StateScene : Scene
    {
        /*
         * StateScene: 스탯 창 씬
         * 
         * [스탯 창 기능]
         * - 현재 플레이어 정보 확인
         * 
         */
        public StateScene(int index) : base(index)
        {
        }

        public override void Init()
        {
            base.Init();

            // bool 초기화
            hasExecutedList["StateView"] = false;

            // 처음 View 설정: StateView
            ChangeView(StateView);
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

        // 플레이어 스탯 창 : 플레이어의 스탯을 볼 수 있는 창
        private void StateView(float elapsed)
        {
            if (!hasExecutedList["StateView"])
            {
                UIManager.Instance.StateView(player);
                hasExecutedList["StateView"] = true;
            }

            var choice = GetUserChoice(["0"]);

            GameManager.Instance.LoadScene("MainScene");
        }


        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
