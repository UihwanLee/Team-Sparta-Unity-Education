//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class STEP4
//    {
//        static void Main(string[] args)
//        {
//            int i = 0;

//            // 1문제
//            Console.WriteLine("문제: 1");
//            for (i = 0; i < 10; i++) Console.WriteLine(i);

//            // 2문제
//            Console.WriteLine("문제: 2");
//            for (i = 0; i < 5; i++) PrintLine();

//            // 3문제
//            Console.WriteLine("문제: 3");
//            for (i = 10; i > 0; i--) Console.WriteLine(i);

//            // 4문제
//            Console.WriteLine("문제: 4");
//            for (i = 0; i <= 10; i += 2) Console.WriteLine(i);

//            // 5문제
//            Console.WriteLine("문제: 5");
//            int sum = 0;
//            for (i = 0; i < 10; i++) sum += i;
//            Console.WriteLine(sum);

//            // 6문제
//            Console.WriteLine("문제: 6");
//            GreetRepeat(3);

//            // 7문제
//            Console.WriteLine("문제: 7");
//            for (i = 1; i <= 20; i++)
//            {
//                if (i % 3 == 0) Console.WriteLine(i);
//            }

//            // 8문제
//            Console.WriteLine("문제: 8");
//            i = 1;
//            while (i <= 10)
//            {
//                Console.WriteLine(i);
//                i++;
//            }

//            // 9문제
//            Console.WriteLine("문제: 9");
//            i = 10;
//            while (i >= 1)
//            {
//                Console.WriteLine(i);
//                i--;
//            }

//            // 10문제
//            Console.WriteLine("문제: 10");
//            sum = 0;
//            i = 1;
//            while (i <= 10)
//            {
//                sum += i;
//                i++;
//            }

//            // 11문제
//            Console.WriteLine("문제: 11");
//            i = 1;
//            while (i <= 20)
//            {
//                if (i % 2 == 0) Console.WriteLine(i);
//                i++;
//            }

//            // 12문제
//            Console.WriteLine("문제: 12");
//            string password = "1234";
//            string input = "";

//            //while(password != input)
//            //{
//            //    Console.Write("비밀번호를 입력하세요: ");
//            //    input = Console.ReadLine();
//            //}

//            Console.WriteLine("로그인 성공!");

//            // 13문제
//            Console.WriteLine("문제: 13");
//            //while(true)
//            //{
//            //    Console.Write("숫자를 입력하세요 (0 = 종료): ");
//            //    int number = int.Parse(Console.ReadLine());
//            //    if(number == 0)
//            //    {
//            //        Console.WriteLine("종료합니다.");
//            //        break;
//            //    }
//            //    if (number % 2 == 0) Console.WriteLine("짝수");
//            //    else Console.WriteLine("홀수");
//            //}

//            // 14문제
//            Console.WriteLine("문제: 14");
//            for (i = 1; i <= 100; i++)
//            {
//                if (i == 5) { break; }
//                Console.WriteLine(i);
//            }

//            // 15문제
//            Console.WriteLine("문제: 15");
//            for (i = 1; i <= 10; i++)
//            {
//                if (i % 2 != 0)
//                {
//                    continue;
//                }
//                Console.WriteLine(i);
//            }

//            // 16문제
//            Console.WriteLine("문제: 16");
//            i = 1;
//            while (true)
//            {
//                Console.WriteLine(i);
//                i++;
//                if (i > 5) break;
//            }

//            // 17문제
//            Console.WriteLine("문제: 17");
//            //while (true)
//            //{
//            //    Console.Write("명령어 입력 ('exit' 입력 시 종료): ");
//            //    input = Console.ReadLine();
//            //    if (input == "exit") { break; }
//            //}

//            // 18문제
//            Console.WriteLine("문제: 18");
//            i = 0;
//            while (i < 20)
//            {
//                i++;
//                if (i % 3 != 0) continue;
//                Console.WriteLine(i);
//            }

//            // 19문제
//            Console.WriteLine("문제: 19");
//            for (i = 1; i <= 100; i++)
//            {
//                if (i % 7 == 0)
//                {
//                    Console.WriteLine(i);
//                    break;
//                }
//            }

//            // 20문제
//            Console.WriteLine("문제: 20");
//            //while(true)
//            //{
//            //    Console.Write("비밀번호 (1234): ");
//            //    input = Console.ReadLine();
//            //    if (input == "1234") { Console.WriteLine("로그인 성공!"); break; }
//            //    else { Console.WriteLine("비밀번호 오류!"); }
//            //}

//            // 21문제
//            Console.WriteLine("문제: 21");
//            bool isGameRunning = true;
//            string choice = "";
//            //while (isGameRunning)
//            //{
//            //    Console.WriteLine("1.공격 2.방어 0.종료");
//            //    Console.Write("입력: ");
//            //    choice = Console.ReadLine();

//            //    switch(choice)
//            //    {
//            //        case "0":
//            //            isGameRunning = false;
//            //            break;
//            //        case "1":
//            //            Console.WriteLine("공격!");
//            //            break;
//            //        case "2":
//            //            Console.WriteLine("방어!");
//            //            break;
//            //        default:
//            //            Console.WriteLine("잘못된 입력");
//            //            break;
//            //    }
//            //}

//            // 22문제
//            Console.WriteLine("문제: 22");
//            string id = "my_id";
//            string pw = "1234";
//            string inputId = "";
//            string inputPw = "";

//            //while (true)
//            //{
//            //    Console.Write("아이디: "); 
//            //    inputId = Console.ReadLine();
//            //    Console.Write("비밀번호: "); 
//            //    inputPw = Console.ReadLine();

//            //    if(inputId == id && inputPw == pw)
//            //    {
//            //        Console.WriteLine("로그인 성공!");
//            //        break;
//            //    }
//            //    else
//            //    {
//            //        Console.WriteLine("아이디/비밀번호 오류. 재시도.");
//            //    }
//            //}

//            // 23문제
//            Console.WriteLine("문제: 23");
//            sum = 0;
//            //while (true)
//            //{
//            //    Console.Write("더할 숫자 입력(0=종료): ");
//            //    int.TryParse(Console.ReadLine(), out int num);
//            //    if (num == 0) break;
//            //    else if(num > 0)
//            //    {
//            //        sum += num;
//            //        Console.WriteLine(sum);
//            //    }
//            //    else
//            //    {
//            //        Console.WriteLine("음수는 계산하지 않습니다.");
//            //    }
//            //}

//            // 24문제
//            Console.WriteLine("문제: 24");
//            sum = 0;
//            for (i = 1; i <= 100; i++)
//            {
//                if (i % 3 == 0 || i % 5 == 0) sum += i;
//            }
//            Console.WriteLine(sum);

//            // 25문제
//            Console.WriteLine("문제: 25");
//            int j = 0;
//            for (i = 1; i <= 3; i++)
//            {
//                for (j = 1; j <= 2; j++)
//                {
//                    Console.WriteLine($"i: {i}, j: {j}");
//                }
//            }
//            // i부터 실행되고 그 안속에서 j가 실행됨

//            // 26문제
//            Console.WriteLine("문제: 26");
//            for (i = 0; i < 5; i++)
//            {
//                for (j = 0; j <= 5; j++)
//                {
//                    Console.Write("*");
//                }
//                Console.WriteLine();
//            }


//            // 27문제
//            Console.WriteLine("문제: 27");
//            for (i = 1; i <= 9; i++)
//            {
//                Console.WriteLine($"2 * {i} = {2 * i}");
//            }

//            // 28문제
//            Console.WriteLine("문제: 28");
//            for (i = 1; i <= 3; i++)
//            {
//                for (j = 1; j <= 2; j++)
//                {
//                    Console.WriteLine($"i: {i}, j: {j}");
//                }
//            }

//            // 29문제
//            Console.WriteLine("문제: 29");
//            sum = 0;
//            for (i = 1; ; i++)
//            {
//                sum += i;
//                if (sum > 2000) break;
//            }

//            // 30문제
//            Console.WriteLine("문제: 30");
//            i = 1;
//            do
//            {
//                Console.WriteLine(i);
//                i++;
//            }
//            while (i <= 5);


//            static void PrintLine()
//            {
//                Console.WriteLine("====================");
//            }

//            static void GreetRepeat(int count)
//            {
//                for (int i = 0; i < count; i++)
//                {
//                    Console.WriteLine("안녕하세요!");
//                }
//            }
//        }
//    }
//}
