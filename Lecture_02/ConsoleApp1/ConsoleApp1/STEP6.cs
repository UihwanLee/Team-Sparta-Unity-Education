using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class STEP6
    {
        static void Main(string[] args)
        {
            // 1문제
            Console.WriteLine("문제: 1");
            int[] scores = new int[5];
            int i = 0;
            scores[0] = 100;
            scores[2] = 80;
            Console.WriteLine(scores[0] + scores[2]);
            if (scores[0] == 100)
            {
                Console.WriteLine("만점입니다!");
            }

            // 2문제
            Console.WriteLine("문제: 2");
            string[] items = new string[3] { "철검", "가죽갑옷", "HP포션" };
            string item = items[2];
            Console.WriteLine(item);
            int count = items.Length;
            Console.WriteLine(count);
            for (i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }

            // 3문제
            Console.WriteLine("문제: 3");
            string[] monsterNames = new string[3] { "고블린", "오우거", "좀비" };
            for (i = 0; i < monsterNames.Length; i++)
            {
                Console.WriteLine($"{i}번 몬스터: {monsterNames[i]}");
                Console.WriteLine($"몬스터 길이: {monsterNames[i].Length}");
            }

            // 4문제
            Console.WriteLine("문제: 4");
            int[] data = { 5, 12, 3, 8, 10 };
            int sum = 0;
            for (i = 0; i < data.Length; i++) if (data[i] > 10) Console.WriteLine(data[i]);
            for (i = 0; i < data.Length; i++) if (data[i] % 2 == 0) Console.WriteLine(data[i]);
            for (i = 0; i < data.Length; i++) sum += data[i];
            Console.WriteLine(sum);
            foreach (var num in data)
            {
                if (num > 5) Console.WriteLine(num);
            }

            // 5문제
            Console.WriteLine("문제: 5");
            List<string> inventory = new List<string>();
            inventory.Add("검");
            inventory.Add("방패");
            inventory.Add("포션");
            count = inventory.Count;
            Console.WriteLine(count);
            item = inventory[0];
            Console.WriteLine(item);
            inventory[1] = "강철 방패";
            Console.WriteLine(inventory[1]);
            inventory.Remove("포션");
            inventory.RemoveAt(0);
            Console.WriteLine(inventory.Count);
            bool hasShield = inventory.Contains("강철 방패");
            Console.WriteLine(hasShield);
            bool hasSword = inventory.Contains("검");
            Console.WriteLine(hasSword);
            inventory.Clear();
            Console.WriteLine(inventory.Count);

            inventory.Add("검");
            inventory.Add("방패");
            inventory.Add("포션");

            PrintInventory(inventory);
        }

        static void PrintInventory(List<string> inventory)
        {
            foreach (var item in inventory) Console.WriteLine(item);
        }
    }
}
