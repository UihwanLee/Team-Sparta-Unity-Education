using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Armor : Item
    {
        /*
         * Armor 클래스
         *
         * 방어구는 방어력이라는 속성을 가지고 있다.
         *
         */

        private int def;    // 방어력

        public Armor(string name, string effect, string description, int price, ItemType type, bool isEquipped, int def) : base(name, effect, description, price, type, isEquipped)
        {
            this.def = def;
        }

        public override void EquipItem(Player player)
        {
            player.EquipArmor(this);
        }

        public override void UnequipItem(Player player)
        {
            
        }

        // 프로퍼티
        public int DEF { get { return def; } }
    }
}
