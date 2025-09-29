using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    
    internal abstract class Character
    {
        protected int hp;
        public int Hp
        {
            get { return hp; }
            protected set
            {
                if (value < 0) hp = 0;
                else hp = value;
            }
        }
        public string Name {  get; private set; }
        public Character(string name, int hp)
        {
            this.Hp = hp;
            this.Name = name;
        }

        public void Move()
        {

        }

        public abstract void Die();

        public virtual void ShowInfo()
        {
            Console.WriteLine($"이름: {Name}, HP: {Hp}");
        }
    }
}
