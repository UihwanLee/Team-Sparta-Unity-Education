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
        protected int atk;
        protected int def;
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
    }
}
