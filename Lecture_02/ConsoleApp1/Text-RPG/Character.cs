using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public class Character : IGameObject
    {
        /*
         * Character 부모 클래스
         *
         * Character은 다음과 같은 공통 속성을 가지고 있다.
         * 
         * [속성]
         * 0: level                     - 캐릭터 레벨
         * 1: name                      - 캐릭터 이름
         * 2: atk                       - 캐릭터 공격력
         * 3: def                       - 캐릭터 방어력
         * 4: hp                        - 캐릭터 체력
         *
         */
        protected int level;
        protected string name;
        protected float atk;
        protected float def;
        protected int hp;

        public Character(int level, string name, int atk, int def, int hp)
        {
            this.level = level;
            this.name = name;
            this.atk = atk;
            this.def = def;
            this.hp = hp;
        }

        public virtual void Start()
        {

        }

        // 업데이트
        public virtual void Update(float elapsed)
        {
            
        }

        // 랜더
        public virtual void Render()
        {
            
        }

        // 캐릭터 정보 보여주기
        public virtual void ShowInfo()
        {
        }

        // 변수 프로퍼티
        public int Hp { get { return hp; } set { if (value < 0) hp = 0; else { hp = value; } } }
        public float Atk { get { return atk; } set { if (value < 0) atk = 0; else { atk = value; } } }
        public float Def { get { return def; } set { if (value < 0) def = 0; else { def = value; } } }
    }
}
