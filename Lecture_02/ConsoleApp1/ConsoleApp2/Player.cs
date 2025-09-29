using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    public enum PlayerState { Idle, Walk, Run, Attack, Die }

    internal class Player : Character, IAttackable
    {
        public int atk;
        public PlayerState CurrentState { get; set; }

        public Player(string name, int hp) : base(name, hp)
        {
        }

        public void Attack(Character target)
        {
            Console.WriteLine($"{target.Name}에게 {atk} 데미지!");
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            Console.WriteLine($"{Name}이(가) {damage} 데미지를 입음. 남은 HP: {Hp}");
        }

        public void CheckState()
        {
            switch (CurrentState)
            {
                case PlayerState.Idle:
                    Console.WriteLine("대기 중");
                    break;
                case PlayerState.Walk:
                    Console.WriteLine("걷는 중");
                    break;
                default:
                    break;
            }
        }

        public override void Die()
        {

        }

        public virtual void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"{atk} 추가");
        }
    }
}
