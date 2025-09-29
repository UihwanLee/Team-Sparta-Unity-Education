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

            Console.WriteLine("오브젝트 초기화");
        }

        public void Update()
        {
            
        }

        public void Render()
        {
            
        }

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
