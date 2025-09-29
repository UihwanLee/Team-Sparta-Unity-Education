using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Inventroy
    {
        public List<Item> items = new List<Item>();

        public Inventroy() 
        {
            items.Clear();
        }

        public void Add(Item item)
        {
            items.Add(item);
        }

        public void Remove(Item item)
        {
            items.Remove(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public void DisplayInfo()
        {
            Console.WriteLine("[아이템 목록]");
            for(int i=0; i<items.Count; i++)
            {
                Console.Write($"- {i} : ");
                items[i].DisplayInfo();
            }
        }
    }
}
