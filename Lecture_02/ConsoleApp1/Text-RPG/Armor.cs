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

        public Armor(int id, string name, string effect, string description, int price, ItemType type, int def) : base(id, name, effect, description, price, type)
        {
            this.def = def;
        }

        public override void EquipItem(Player player, bool isEquipped)
        {
            base.EquipItem(player, isEquipped);

            // 플레이어 방어구 장착
            player.EquipArmor(this, isEquipped);
        }

        // 아이템 복제
        public override Item Clone()
        {
            return new Armor(Id, name, effect, description, price, Type, def);
        }

        // 프로퍼티
        public int DEF { get { return def; } }
    }
}
