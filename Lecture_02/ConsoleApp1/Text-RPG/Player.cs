using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Player : Character
    {
        /*
         * 게임에서 플레이어 역할을 할 Player 클래스
         *
         * Character를 상속 받고 있으며 Player는 다음과 같은 특성을 가지고 있다.
         * 
         * [속성]
         * 0: job                       - 플레이어 직업
         * 1: gold                      - 플레이어 골드
         * 2: stamin                    - 플레이어 스태미나
         * 3: exp                       - 플레이어 경험치
         *
         */
        protected string job;
        protected int gold;
        protected int stamina;
        protected int exp;

        protected Inventroy inventroy;

        public Player(int level, string name, int atk, int def, int hp, string job, int gold) : base(level, name, atk, def, hp)
        {
            this.job = job;
            this.gold = gold;

            this.stamina = 100;
            this.exp = 0;
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
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
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
            Console.WriteLine($"골드 : {gold}");
            Console.WriteLine($"스태미나 : {stamina}");
            Console.WriteLine($"경험치 : {exp}");
        }

        // 변수 프로퍼티
        public Inventroy Inventroy { get { return inventroy; } }

        // HP
        public int HP
        {
            get { return hp; }
            set
            {
                if (value < 0) hp = 0;
                else hp = value;
            }
        }

        // 스태미나
        public int Stamina 
        { get { return stamina; } 
          set 
            {
                if (value < 0) stamina = 0;
                else stamina = value;
            } 
        }

        // 골드
        public int Gold
        {
            get { return gold; }
            set
            {
                if (value < 0) gold = 0;
                else gold = value;
            }
        }

        // 경험치
        public int Exp
        {
            get { return exp; }
            set
            {
                if (value < 0) exp = 0;
                else exp = value;
            }
        }
    }
}
