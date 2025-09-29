//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class Lecture2
//    {
//        // 숫자 맞추기 게임 5개 중에 3개만 맞춰도 성공하도록 변경
//        static void Main(string[] args)
//        {
//            // 숫자 맞추기 게임
//            Random random = new Random(); // 랜덤 객체
//            int[] numbers = new int[5]; // 숫자 저장할 배열

//            for (int i = 0; i < numbers.Length; i++)
//            {
//                numbers[i] = random.Next(1, 10); // 1~9까지 저장
//            }

//            // 시도 수
//            int count_try = 0;
//            List<int> guesses = new List<int>();
//            while (true)
//            {
//                // 사용자가 맞추려는 리스트 초기화
//                guesses.Clear();

//                Input(guesses);
//                bool isOver = Process(guesses, numbers);
//                if (isOver) break;
//            }
//        }

//        static bool Input(List<int> guesses)
//        {
//            int count = 0;
//            while (count < 5)
//            {
//                Console.WriteLine($"{count}번째 숫자를 입력해 주세요(1~9)");
//                string num = Console.ReadLine();
//                if (int.TryParse(num, out int temp) == false)
//                {
//                    Console.WriteLine("숫자를 입력해주세요!");
//                    continue;
//                }

//                // 중복 체크
//                if (guesses.Contains(int.Parse(num)))
//                {
//                    Console.WriteLine("숫자가 중복됩니다.!");
//                    continue;
//                }

//                guesses.Add(int.Parse(num));
//                count++;
//            }

//            return true;
//        }

//        static bool Process(List<int> guesses, int[] numbers)
//        {
//            int correct = 0;
//            for (int i = 0; i < guesses.Count; i++)
//            {
//                for (int j = 0; j < numbers.Length; j++)
//                {
//                    if (guesses[i] == numbers[j])
//                    {
//                        correct++;
//                        break;
//                    }
//                }
//            }

//            if (correct >= 3)
//            {
//                Console.WriteLine("모두 맞춤!");
//                return true;
//            }
//            else
//            {
//                Console.WriteLine("좀 더 맞추자!");
//                return false;
//            }
//        }
//    }
//}
