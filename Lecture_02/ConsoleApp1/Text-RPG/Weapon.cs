using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Weapon : Item
    {
        /*
         * Weapon 클래스
         *
         * 무기는 공격력이라는 속성을 가지고 있다.
         *
         */

        private int atk;    // 공격력

        public Weapon(int id, string name, string effect, string description, int price, ItemType type, int atk) : base(id, name, effect, description, price, type)
        {
            this.atk = atk;
        }

        public override void EquipItem(Player player, bool isEquipped)
        {
            base.EquipItem(player, isEquipped);

            // 플레이어 무기 장착
            player.EquipWeapon(this, isEquipped);
        }

        // 아이템 복제
        public override Item Clone()
        {
            return new Weapon(Id, name, effect, description, price, Type, atk);
        }

        // 프로퍼티
        public int ATK { get { return atk; } }
    }
}
