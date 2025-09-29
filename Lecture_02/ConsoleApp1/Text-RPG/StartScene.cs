using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class StartScene : Scene
    {
        /*
         * StartScene: 초기 상태를 확인할 수 있는 씬
         * 기본적으로 이 씬에서 보여줄 오브젝트만 관리한다.
         * 
         * 다만 모든 오브젝트는 start(), update()를 실행한다.
         * 
         */
        private Character character;
        List<IGameObject> gameObjects = new List<IGameObject>();

        public StartScene(int index, UIManager uIManager) : base(index, uIManager)
        {

        }

        public override void Start()
        {
            base.Start();

            // 오브젝트 초기화
            gameObjects.Clear();

            // 캐릭터 추가
            character = new Character(1, "이의환", "초보자", 10, 10, 100, 0);
            gameObjects.Add(character);

            // 오브젝트 초기화
            foreach (var gameObject in gameObjects)
            {
                gameObject.Start();
            }

            // 튜토리얼 띄우기
            OpenMenu();
        }

        public override void Update()
        {
            base .Update();

            // 오브젝트 업데이트
            foreach(var gameObject in gameObjects)
            {
                gameObject.Update();
            }
        }

        // 메뉴 열기
        private void OpenMenu()
        {
            Console.Clear();
            uiManager.OpenMenu();
            string input;

            while(true)
            {
                Console.Write(">> ");
                input = Console.ReadLine();
                Console.WriteLine();
                if (input == "1" || input == "2") break;
                Console.WriteLine("잘못된 입력입니다");
            }

            switch (input)
            {
                case "1":
                    ShowState();
                    break;
                case "2":
                    ShowInventory();
                    break;
                default:
                    break;
            }
        }

        // 상태 보기
        private void ShowState()
        {
            if (character == null) OpenMenu();

            uiManager.ShowState(character);
            string input;

            while (true)
            {
                Console.Write(">> ");
                input = Console.ReadLine();
                Console.WriteLine();
                if (input == "0") break;
                Console.WriteLine("잘못된 입력입니다");
            }

            switch (input)
            {
                case "0":
                    OpenMenu();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    break;

            }
        }

        // 인벤토리 보기
        private void ShowInventory()
        {
            if (character == null) OpenMenu();

            uiManager.ShowInventory(character.Inventroy);
            string input;

            while (true)
            {
                Console.Write(">> ");
                input = Console.ReadLine();
                Console.WriteLine();
                if (input == "1" || input == "0") break;
                Console.WriteLine("잘못된 입력입니다");
            }


            switch (input)
            {
                case "0":
                    OpenMenu();
                    break;
                case "1":
                    break;
                default:
                    break;
            }
        }
    }
}
