//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class STEP1
//    {
//        static void Main(string[] args)
//        {
//            // 1문제
//            Console.WriteLine("문제: 1");
//            int level = 50;
//            int levelInt = level;
//            Console.WriteLine(levelInt);

//            // 2문제
//            // long 데이터 타입이 더 범위가 넓기 때문에
//            // 정상적으로 출력이 된다.
//            Console.WriteLine("문제: 2");
//            int gold = 200000;
//            long goldInt = gold;
//            Console.WriteLine(goldInt);

//            // 3문제
//            Console.WriteLine("문제: 3");
//            int hp = 10;
//            float hpFloat = hp;
//            Console.WriteLine(hpFloat);

//            // 4문제
//            Console.WriteLine("문제: 4");
//            float speed = 5.25f;
//            double speedDouble = speed;
//            Console.WriteLine(speedDouble);

//            // 5문제
//            Console.WriteLine("문제: 5");
//            int avergeDamage = (int)20.7f;
//            int damageInt = avergeDamage;
//            Console.WriteLine(damageInt);

//            // 6문제
//            Console.WriteLine("문제: 6");
//            double preciseExp = 123.456f;
//            int expInt = (int)preciseExp;
//            Console.WriteLine(expInt);

//            // 7문제
//            Console.WriteLine("문제: 7");
//            int itemCount = 150;
//            byte countByte = (byte)itemCount;
//            Console.WriteLine(countByte);

//            // 8문제
//            var myLevel = 10;

//            // 9문제
//            var myJob = "전사";

//            // 10문제
//            var isPlayerTurn = true;

//            // 생각하는 문제: 1
//            Console.WriteLine("생각하는 문제: 1");
//            int overflowValue = 300;

//            // byte는 0 ~ 255 / int 형은 -210. ~ 210...
//            // byte는 8bit씩 표현 
//            // 8bit -> 2의 8승 = 256
//            // 따라서 300을 256으로 나누어 주면된다.
//            // 근데 300이란 값은 256을 초과하기 때문에
//            // 300 % 256 = 44
//            byte byteValue = (byte)overflowValue;
//            Console.WriteLine(byteValue);

//            // 생각하는 문제: 2
//            Console.WriteLine("생각하는 문제: 2");
//            long hugeGold = 3000000000L;
//            int goldInt2 = (int)hugeGold;
//            Console.WriteLine(goldInt2);

//            // int 범위 -21억 ~ 21억
//            // 오버플로우 발생
//            // 쓰레기 값이 들어감

//            // 생각하는 문제: 3
//            Console.WriteLine("생각하는 문제: 3");
//            double preciseLocation = 123.456789123f;
//            float simpleLocation = (float)preciseLocation;
//            Console.WriteLine(simpleLocation);

//            // float은 유효 자리 숫자가 더 작음
//            // 따라서 일정 자리 내 반올림하여 표현

//            // 생각하는 문제: 4
//            Console.WriteLine("생각하는 문제: 4");
//            // camelCase 는 첫문자 소문자를 쓰고 대문자로 씀
//            // 1stPlayerLevel -> 첫문자에 1이 들어가면 안됨
//            // Name -> 첫 문자에 대문자가 들어가면 안됨
//            //IsMonsterDead 마찬가지 이유
//            // long 데이터 타입과 같은 이름이면 오류
//        }
//    }
//}
