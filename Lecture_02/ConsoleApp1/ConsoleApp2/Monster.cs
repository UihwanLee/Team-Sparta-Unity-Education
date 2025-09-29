using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Monster : Character, IAttackable
    {
        public int level;

        public Monster(string name, int hp, int level) : base(name, hp)
        {
            this.level = level;
        }

        public void Attack(Character target)
        {
            throw new NotImplementedException();
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"이름: {Name}, 레벨: {level}, HP: {Hp}");
        }

        public override void Die()
        {

        }
    }
}
