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
         * Player는 장비를 무기와 방어구 각 한 개씩만 장착할 수 있다.
         * 
         * Armor : 1
         * Weapon : 1
         *
         */
        protected string job;
        protected int gold;
        protected int stamina;
        protected int exp;

        protected Inventroy inventroy;

        // 장착 중인 무기와 방어구
        private int origin_atk, origin_def;
        private Weapon weapon;
        private Armor armor;

        public Player(int level, string name, int atk, int def, int hp, string job, int gold) : base(level, name, atk, def, hp)
        {
            this.job = job;
            this.gold = gold;

            this.stamina = 100;
            this.exp = 0;
            
            // 생성 시 기본 스탯을 저장
            origin_atk = atk;
            origin_def = def;

            // 캐릭터 초기 생성 시 자신만의 인벤토리를 생성한다.
            inventroy = new Inventroy();

            // 기본 장비 추가
            inventroy.Add(ItemDatabase.GetArmor("무쇠갑옷"));
            inventroy.Add(ItemDatabase.GetWeapon("낡은 검"));
            inventroy.Add(ItemDatabase.GetWeapon("연습용 창"));
        }

        public override void Start()
        {
            base.Start();
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

        // 아이템 장착 - 무기
        public void EquipWeapon(Weapon weapon, bool isEquipped)
        {
            if (weapon == null) return;

            // 기존 무기가 있다면 해제
            if(this.weapon != null)
            {
                this.weapon.isEquipped = false;
            }

            this.weapon = (isEquipped) ? weapon : null;

            // 무기 속성에 따라 스탯 증가
            this.atk = (isEquipped) ? origin_atk + weapon.ATK : origin_atk;
        }

        // 아이템 장착 - 방어구
        public void EquipArmor(Armor armor, bool isEquipped)
        {
            if (armor == null) return;

            // 기존 방어구가 있다면 해제
            if (this.armor != null)
            {
                this.armor.isEquipped = false;
            }

            this.armor = (isEquipped) ? armor : null;

            // 방어구 속성에 따라 스탯 증가
            this.def = (isEquipped) ? origin_def + armor.DEF : origin_def;
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
