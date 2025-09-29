//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class STEP3
//    {
//        static void Main(string[] args)
//        {
//            // 1문제
//            Console.WriteLine("문제: 1");
//            Add(3, 5);
//            Add(4, 5);
//            Add(6, 5);

//            // 2문제
//            Console.WriteLine("문제: 2");
//            PrintItemPrice("철검", 1000);
//            PrintItemPrice("가죽갑옷", 500);

//            // 3문제
//            Console.WriteLine("문제: 3");
//            int result1 = Add(10, 20);
//            int result2 = Add(result1, 30); // 30 + 30;
//            Console.WriteLine(result2);

//            // 4문제
//            Console.WriteLine("문제: 4");
//            int damage = Multiply(10, 5);
//            TakeDamage(damage);

//            // 5문제
//            Console.WriteLine("문제: 5");
//            string fullName = GetFullName("John", "Doe");
//            Console.WriteLine(fullName);

//            // 6문제
//            Console.WriteLine("문제: 6");
//            GetAverage(10, 20);
//            GetAverage(5, 10);

//            // 7문제
//            Console.WriteLine("문제: 7");
//            int currentHp = 100;
//            currentHp = CalculateRemainingHp(currentHp, 30);
//            Console.WriteLine(currentHp);

//            // 8문제
//            Console.WriteLine("문제: 8");
//            IsEven(10);
//            IsEven(7);

//            // 9문제
//            Console.WriteLine("문제: 9");
//            bool isAdult1 = IsAdult(20);
//            bool isAdult2 = IsAdult(15);

//            // 10문제
//            Console.WriteLine("문제: 10");
//            CheckHp(50);
//            CheckHp(0);
//        }

//        static int Add(int a, int b)
//        {
//            return a + b;
//        }

//        static int Multiply(int a, int b)
//        {
//            return a * b;
//        }

//        static void PrintItemPrice(string itemName, int price)
//        {
//            Console.WriteLine($"{itemName}의 가격은 {price}골드입니다.");
//        }

//        static void TakeDamage(int damage)
//        {
//            Console.WriteLine($"플레이어는 [{damage}]의 데미지를 입었습니다");
//        }

//        static string GetFullName(string firstName, string lastName)
//        {
//            return string.Format("{0} {1}", firstName, lastName);
//        }

//        static float GetAverage(int a, int b)
//        {
//            return (a + b) / 2;
//        }

//        static int CalculateRemainingHp(int hp, int damage)
//        {
//            if (hp <= 0 || hp - damage <= 0) return 0;
//            return hp - damage;
//        }

//        static bool IsEven(int number)
//        {
//            return number % 2 == 0;
//        }

//        static bool IsAdult(int age)
//        {
//            return (age >= 19);
//        }

//        static void CheckHp(int hp)
//        {
//            if (IsAlive(hp))
//            {
//                Console.WriteLine("플레이어는 생존해 있습니다.");
//            }
//            else
//            {
//                Console.WriteLine("플레이어는 사망했습니다.");
//            }
//        }

//        static bool IsAlive(int hp)
//        {
//            return hp > 0;
//        }
//    }
//}
