using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Skill : IAttackable
    {
        public string name;
        public int damage;
        public int myCoast;

        public Skill(string name, int damage, int myCoast)
        {
            this.name = name;
            this.damage = damage;
            this.myCoast = myCoast;
        }

        public void Attack(Character target)
        {
            Console.WriteLine($"스킬 {name} 발동! {target.Name}에게 {damage} 데미지!");
        }

        public void Activate()
        {
            Console.WriteLine($"스킬 {name} 발동! 데미지 {damage}, MP소모: {myCoast}");
        }
    }
}
