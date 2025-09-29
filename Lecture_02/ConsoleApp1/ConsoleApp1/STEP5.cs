//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class STEP5
//    {
//        static void Main(string[] args)
//        {
//            // 1문제
//            Console.WriteLine("문제: 1");
//            string input = "1";
//            int choice = int.Parse(input);
//            Console.WriteLine($"{choice + 1}");

//            // 2문제
//            Console.WriteLine("문제: 2");
//            input = "abc";
//            //choice = int.Parse(input);
//            // 문자열이 정수 형식이 아니면 예외 발생

//            // 3문제
//            Console.WriteLine("문제: 3");
//            input = "abc";
//            if (int.TryParse(input, out choice) == false)
//            {
//                Console.WriteLine("숫자만 입력해야 합니다.");
//            }

//            // 4문제
//            Console.WriteLine("문제: 4");
//            input = "3";
//            if (int.TryParse(input, out choice))
//            {
//                Console.WriteLine($"입력한 숫자: {choice}");
//            }

//            // 5문제
//            Console.WriteLine("문제: 5");
//            string message = "You found a potion!";
//            if (message.Contains("potion"))
//            {
//                Console.WriteLine("포션을 발견했다!");
//            }

//            // 6문제
//            Console.WriteLine("문제: 6");
//            string description = "매우 [낡은] 검입니다.";
//            string newDescirption = description.Replace("[낡은]", "[강화된]");
//            Console.WriteLine(newDescirption);
//        }
//    }
//}
