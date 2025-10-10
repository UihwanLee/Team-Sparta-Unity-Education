using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    public class InventroyScene : Scene
    {
        /*
         * InventroyScene: 인벤토리 씬
         * 
         * [인벤토리 기능]
         * - 현재 가지고 있는 아이템 확인
         * - 아이템 장착 / 해제
         * 
         */
        public InventroyScene(int index, MapManager map) : base(index, map)
        {
        }

        public override void Init()
        {
            base.Init();

            // bool 초기화
            hasExecutedList["InventoryView"] = false;
            hasExecutedList["InventoryEquippedView"] = false;
            hasExecutedList["InventorySortingView"] = false;

            // 처음 View 설정: InventoryView
            ChangeView(InventoryView);
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

        // 플레이어 인벤토리 창 : 플레이어의 인벤토리를 볼 수 있는 창. 아이템을 확인 할 수 있다.
        private void InventoryView(float elapsed)
        {
            if (!hasExecutedList["InventoryView"])
            {
                UIManager.Instance.InventoryView(player.Inventroy);
                hasExecutedList["InventoryView"] = true;
            }

            var choice = GetUserChoice(["0", "1", "2"]);

            if (choice == "0") GameManager.Instance.LoadScene("MainScene");
            else if (choice == "1") ChangeView(InventoryEquippedView);
            else ChangeView(InventorySortingView);
        }

        // 플레이어 인벤토리 관리 창 : 플레이어의 아이템을 장착/해제 할 수 있다.
        private void InventoryEquippedView(float elapsed)
        {
            if (!hasExecutedList["InventoryEquippedView"])
            {
                UIManager.Instance.InventoryEquippedView(player.Inventroy);
                hasExecutedList["InventoryEquippedView"] = true;
            }

            int equippedIdx = 0;

            // 선택 가능한 장비 배열 만들기
            int vaildCount = player.Inventroy.Items.Count;
            string[] vaildItemOption = Enumerable.Range(0, vaildCount + 1).Select(i => i.ToString()).ToArray();   // LINQ 문법
            var choice = GetUserChoice(vaildItemOption);

            // 나가기 설정
            if (choice == "0") { ChangeView(InventoryView); return; }

            // 인벤토리에서 idx로 검색하여 해당 아이템 장착
            equippedIdx = int.Parse(choice.ToString());
            player.Inventroy.EquipItemByIdx(equippedIdx - 1);

            // 창 변경
            ChangeView(InventoryEquippedView);
        }

        // 플레이어 인벤토리 정렬 창 : 인벤토리의 아이템들을 옵션에 따라 정렬할 수 있다.
        private void InventorySortingView(float elapsed)
        {
            if (!hasExecutedList["InventorySortingView"])
            {
                UIManager.Instance.InventorySortingView(player.Inventroy);
                hasExecutedList["InventorySortingView"] = true;
            }

            var choice = GetUserChoice(["0", "1", "2", "3", "4"]);

            // 나가기 설정
            if (choice == "0") { ChangeView(InventoryView); return; }

            // 옵션에 따라 아이템 정렬
            player.Inventroy.SortItemByOption(int.Parse(choice.ToString()));

            // 창 변경
            ChangeView(InventorySortingView);
        }

        public override void ChangeView(Action<float> view)
        {
            this.Start();
            base.ChangeView(view);
        }
    }
}
