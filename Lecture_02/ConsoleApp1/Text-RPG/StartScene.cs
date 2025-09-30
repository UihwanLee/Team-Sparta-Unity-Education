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

        private delegate void uiHandler();

        private Action<int, int> Event;

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

        //public void RunGame(int _option)
        //{
        //    switch(_option)
        //    {
        //        case 0:
        //            uiHandler = OpenMenu;
        //            break;

        //    }
        //}

        // 메뉴 열기
        private void OpenMenu()
        {
            Console.Clear();
            uiManager.OpenMenu();

            var choice = GetUserChoice(["1", "2"]);

            switch (choice)
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

            var choice = GetUserChoice(["0"]);

            switch (choice)
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

            var choice = GetUserChoice(["0", "1"]);

            switch (choice)
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
            int equippedIdx = 0;

            uiManager.ShowInventoryEquipped(character.Inventroy);

            // 선택 가능한 장비 배열 만들기
            int vaildCount = character.Inventroy.Items.Count;
            string[] vaildItemOption = Enumerable.Range(0, vaildCount+1).Select(i => i.ToString()).ToArray();   // LINQ 문법

            var choice = GetUserChoice(vaildItemOption);

            switch(choice)
            {
                case "0":
                    OpenMenu();
                    break;
                default:
                    {
                        equippedIdx = int.Parse(choice.ToString());
                        isEquipped = true;
                        break;
                    }
            }
            
            if(isEquipped)
            {
                // 인벤토리에서 idx로 검색하여 해당 아이템 장착
                character.Inventroy.EquippedItemByIdx(equippedIdx-1);
            }

            ShowInventoryEquipped();
        }

        // 옵션 메뉴 창만 따로 빼기
        private string GetUserChoice(string[] vaildOptions)
        {
            string choice;
            while(true) {
                Console.Write(">> ");
                choice = Console.ReadLine();
                Console.WriteLine();

                foreach (var option in vaildOptions) if (choice == option) return choice;

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
