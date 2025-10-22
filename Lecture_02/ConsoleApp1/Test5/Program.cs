namespace Test5
{
    internal class Program
    {
        public static string IsEvenOrOdd(int num)
        {
            return (num % 2 == 0) ? "짝수입니다" : "홀수입니다";
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("숫자를 입력하세요.");
                string answer = Console.ReadLine();

                bool isSuccess = int.TryParse(answer, out int result);

                // TODO : 입력받은 정수가 홀수인지 짝수인지 구분하는 코드 작성하기

                if(isSuccess)
                {
                    Console.WriteLine(IsEvenOrOdd(result));
                }
                else
                {
                    break;
                }
            }
        }
    }
}
