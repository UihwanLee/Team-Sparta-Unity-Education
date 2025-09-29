//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class STEP2
//    {
//        static void Main(string[] args)
//        {
//            // Challenge (10문제)

//            // 1문제
//            Console.WriteLine("문제: 비트 &");
//            int a = 12;
//            int b = 10;

//            int result = a & b;
//            Console.WriteLine(result);

//            // AND 연산 둘 다 1일 때만 1
//            // 1100 AND 1010 -> 1000 -> 2의 3승 = 8

//            // 2문제
//            Console.WriteLine("문제: 비트 |");
//            result = a | b;
//            Console.WriteLine(result);

//            // OR 연산은 둘 중 하나라도 1이면 1
//            // 1100 OR 1010 -> 1110 -> 14;

//            // 3문제
//            Console.WriteLine("문제: 비트 ^");
//            result = a ^ b;
//            Console.WriteLine(result);

//            // XOR 연산은 두 비트가 다르면 1, 같으면 0
//            // 1100 XOR 1010 -> 0110 -> 6

//            // 4문제
//            Console.WriteLine("문제: 비트 <<");
//            int c = 11; // 1011
//            result = c << 2; // 101100 -> 32 + 8 + 4 = 44
//            Console.WriteLine(result);

//            // 5문제
//            Console.WriteLine("문제: 비트 <<");
//            c = 11; // 1011
//            result = c >> 1; // 0101 -> 4 + 1 = 5
//            Console.WriteLine(result);

//            // 6문제
//            Console.WriteLine("문제: 특정 비트 확인");
//            int d = 12; // 1100
//            int temp = (d >> 2) & 1;
//            bool isThirdBitOn = (temp == 1) ? true : false;
//            Console.WriteLine(isThirdBitOn);

//            // 1 -> 0001 -> 첫째자리 값대로 표시하면 한 자리 표현

//            // 7문제 
//            Console.WriteLine("문제: 플래그 추가");
//            int playerStatus = 0;
//            int FLAG_A = 4;
//            playerStatus |= FLAG_A;
//            Console.WriteLine(playerStatus);

//            // FLAG : 조건 상태를 나타내는 말
//            // 자릿 수 대로 1을 켜서 조건 분기 확인 (스위치 개념)

//            // 8문제 
//            Console.WriteLine("문제: 플래그 토글 ^");
//            playerStatus = 5; // 0101
//            int FLAG_B = 1; // 은신 상태
//            playerStatus ^= FLAG_B;
//            Console.WriteLine(playerStatus);

//            // 토글 연산은 스위치 전원을 On/Off하는 기능

//            // 9문제
//            Console.WriteLine("문제: 플래그 검사 &");
//            playerStatus = 5;
//            //if((playerStatus & FLAG_A) == FLAG_A)
//            if ((playerStatus & FLAG_A) != 0)
//            {
//                Console.WriteLine("플레이어가 독 상태입니다.");
//            }

//            // 10문제
//            Console.WriteLine("문제: 플래그 제거 ~&");
//            playerStatus = 7;
//            playerStatus = playerStatus &= ~FLAG_A; // (1011)
//            Console.WriteLine(playerStatus); // 0011
//        }

//        // 레이어 마스킹

//        // 복합적인 조건

//        // 하나의 여러정보
//    }
//}
