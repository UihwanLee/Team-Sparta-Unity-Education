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

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            while (true)
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

            Console.Clear();

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

            Console.Clear();

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
                    ShowInventoryEquipped();
                    break;
                default:
                    break;
            }
        }

        // 인벤토리 - 장착 관리
        private void ShowInventoryEquipped()
        {
            if (character == null) OpenMenu();

            Console.Clear();

            bool isEquipped = false;

            uiManager.ShowInventoryEquipped(character.Inventroy);

            string input;

            while (true)
            {
                Console.Write(">> ");
                input = Console.ReadLine();
                Console.WriteLine();
                if (input == "0") break;
                if(int.TryParse(input, out int tmp))
                {
                    if(int.Parse(input) > 0 ||  int.Parse(input) < character.Inventroy.Items.Count)
                    {
                        // 현재 리스트에 내에 있는 숫자를 골랐을 때
                        isEquipped = true;
                        break;
                    }
                }
                
                // 인벤토리 
                Console.WriteLine("잘못된 입력입니다");
            }

            if (input == "0")
            {
                Console.Clear();
                OpenMenu();
            }
            
            if(isEquipped)
            {
                // 인벤토리에서 idx로 검색하여 해당 아이템 장착
                character.Inventroy.EquippedItemByIdx(int.Parse(input)-1, true);
            }
        }
    }
}
