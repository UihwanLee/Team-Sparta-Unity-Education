using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    internal class Scene
    {
        protected int index;

        protected Player player;    // 이 Scene에서 사용할 Character

        protected Action<float> currentView;   // 현재 창 (시작창, 스탯창 등)

        protected bool hasExecuted = false;       // 한번만 호출할 수 있게 하는 변수

        // Scene에서 표시할 모든 오브젝트
        protected List<IGameObject> gameObjects = new List<IGameObject>();

        public Scene(int index)
        {
            this.index = index;
        }

        public virtual void Start()
        {

        }

        public virtual void Update(float elapsed)
        {

        }

        // View 바꾸기
        protected void ChangeView(Action<float> view)
        {
            if (view == null) return;

            Console.Clear();
            hasExecuted = false;
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

        // 프로퍼티
        public bool HasExecuted { get { return hasExecuted; } set { hasExecuted = value; } }
    }
}
