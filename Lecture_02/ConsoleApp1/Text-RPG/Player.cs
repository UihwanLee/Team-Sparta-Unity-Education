using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Player : Character
    {
        protected string job;
        protected int gold;

        protected Inventroy inventroy;

        public Player(int level, string name, int atk, int def, int hp, string job, int gold) : base(level, name, atk, def, hp)
        {
            this.job = job;
            this.gold = gold;
        }

        public override void Start()
        {
            base.Start();

            // 캐릭터 초기 생성 시 자신만의 인벤토리를 생성한다.
            inventroy = new Inventroy();

            inventroy.Add(new Item("무쇠갑옷", "방어력+5",
                "무쇠로 만들어져 튼튼한 갑옷입니다.", 10000, ItemType.Weapon, true));
            inventroy.Add(new Item("낡은 검", "공격력+2",
                "쉽게 볼 수 있는 낡은 검 입니다.", 20000, ItemType.Weapon, false));
            inventroy.Add(new Item("연습용 창", "공격력+3",
                "검보다는 그대로 창이 다루기 쉽죠.", 20000, ItemType.Weapon, false));

        }

        // 업데이트
        public override void Update()
        {
            base.Update();
        }

        // 랜더
        public override void Render()
        {
            base.Render();
        }

        // 캐릭터 정보 보여주기
        public override void ShowInfo()
        {
            base.ShowInfo();

            string levelTxt = (level < 10) ? $"0{level}" : $"{level}";
            Console.WriteLine($"Lv. {levelTxt}");
            Console.WriteLine($"Chad : ({job})");
            Console.WriteLine($"공격력 : {atk}");
            Console.WriteLine($"방어력 : {def}");
            Console.WriteLine($"체력 : {hp}");
            Console.WriteLine($"Gold : {gold}");
        }

        // 변수 프로퍼티
        public Inventroy Inventroy { get { return inventroy; } }
    }
}
