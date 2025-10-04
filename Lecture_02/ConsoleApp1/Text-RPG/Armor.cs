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

        public override void EquipItem(Player player, bool isEquipped)
        {
            base.EquipItem(player, isEquipped);

            // 플레이어 방어구 장착
            player.EquipArmor(this, isEquipped);
        }

        // 프로퍼티
        public int DEF { get { return def; } }
    }
}
