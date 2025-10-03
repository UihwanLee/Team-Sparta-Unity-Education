using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    internal class Scene
    {
        /*
         * Scene 부모 클래스
         *
         * 각 Scene은 공통적으로 Player 객체를 가지고 있다.
         * 또한, Scene에서 다양한 view가 존재하며
         * currentView로 보여줄 창을 관리한다.
         * 
         * update 루프 내 scene이 동작하므로
         * ui 창 같은 한번만 보여줄 오브젝트는 hasExcuted 변수로 관리한다.
         *
         */
        protected int index;

        protected Player player;    // 이 Scene에서 사용할 Character

        protected Action<float> currentView;   // 현재 창 (시작창, 스탯창 등)

        protected Dictionary<string, bool> hasExecutedList = new Dictionary<string, bool>();     // 한번만 호출할 수 있게 하는 변수

        protected float startTime = 0f;   // Scene에 입장 했을 때 초기 elapsed 값

        // Scene에서 표시할 모든 오브젝트
        protected List<IGameObject> gameObjects = new List<IGameObject>();

        public Scene(int index)
        {
            this.index = index;
        }

        public virtual void Init()
        {
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

            // 초기 elapsed 초기화
            startTime = 0f;
        }

        public virtual void Start()
        {

        }

        public virtual void Update(float elapsed)
        {
            // LocalElapsed 초기화
            if (!hasExecutedList["TimeSet"])
            {
                startTime = TimeManager.Instance.Elapsed;
                TimeManager.Instance.LocalElapsed = 0f;
                hasExecutedList["TimeSet"] = true;
            }
        }

        // View 바꾸기
        public virtual void ChangeView(Action<float> view)
        {
            if (view == null) return;

            Console.Clear();
            currentView = view;
            currentView.Invoke(0f);
        }

        // 옵션 메뉴 창만 따로 빼기
        protected string GetUserChoice(string[] vaildOptions)
        {
            string choice;
            while (true)
            {
                Console.Write(">> ");
                choice = Console.ReadLine();
                Console.WriteLine();

                foreach (var option in vaildOptions) if (choice == option) return choice;

                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        // SetCurPosition 함수를 이용한 한 줄 덮어쓰기 함수
        protected void WriteLine(string message, int line)
        {
            Console.SetCursorPosition(0, line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, line);
            Console.Write(message);
        }
    }
}
