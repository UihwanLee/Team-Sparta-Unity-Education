using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Character : IGameObject
    {
        protected int level;
        protected string name;
        protected string job;
        protected int atk;
        protected int def;
        protected int hp;
        protected int gold;

        protected Inventroy inventroy;

        public Character(int level, string name, string job, int atk, int def, int hp, int gold)
        {
            this.level = level;
            this.name = name;
            this.job = job;
            this.atk = atk;
            this.def = def;
            this.hp = hp;
            this.gold = gold;
        }

        public void Start()
        {
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
        public void Update()
        {
            
        }

        // 랜더
        public void Render()
        {
            
        }

        // 캐릭터 정보 보여주기
        public void ShowInfo()
        {
            string levelTxt = (level < 10) ? $"0{level}" : $"{level}";
            Console.WriteLine($"Lv. {levelTxt}");
            Console.WriteLine($"Chad : ({job})");
            Console.WriteLine($"공격력 : {atk}");
            Console.WriteLine($"방어력 : {def}");
            Console.WriteLine($"체력 : {hp}");
            Console.WriteLine($"Gold : {gold}");
        }

        // 변수 프로퍼티
        public int Hp { get { return hp; } set { if (value < 0) hp = 0; else { hp = value; } } }

        public Inventroy Inventroy { get { return inventroy; } }
    }
}
