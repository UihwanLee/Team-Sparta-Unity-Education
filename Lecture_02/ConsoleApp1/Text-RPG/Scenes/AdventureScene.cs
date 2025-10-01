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

        private Action currentView;

        public AdventureScene(int index) : base(index)
        {
        }

        public override void Start()
        {
            base.Start();

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

            // 처음 View 설정: StarView
            currentView = AdventureView;
        }

        public override void Update()
        {
            base.Update();

            // 오브젝트 업데이트
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update();
            }

            // View 변할 때 마다 실행
            currentView?.Invoke();
        }

        private void AdventureView()
        {
            Console.Clear();
            UIManager.Instance.AdventureView();
            var choice = GetUserChoice(["1", "0"]);

            // 나가기 누르면 MainScene으로 이동
            if(choice == "0")
            {
                GameManager.Instance.LoadScene("MainScene");
                return;
            }

            currentView = RandomAdventureView;
        }

        private void RandomAdventureView()
        {

        }
    }
}
