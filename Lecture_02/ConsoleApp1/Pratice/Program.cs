namespace Pratice
{
    // Genral Type
    class Stack<T>
    {
        public List<T> Shuffle(List<T> list)
        {
            Random random = new Random();

            for(int i=list.Count-1; i>=0; i--)
            {
                // 셔플은 뒤에서부터 돌아야 안정성이 높음
                int j = random.Next(0, i-1);
                (list[i], list[j]) = (list[i], list[j]); // 튜플 스왑
            }

            return list;
        }
    }

    internal class Program
    {
        // 델리게이트 사용
        delegate void MyDelegate(string message);

        static int Add(int x, int y) => (x+y);

        static void Method1(string message)
        {
            Console.WriteLine("Method1: " + message); 
        }

        static void Method2(string message)
        {
            Console.WriteLine("Method2: " + message);
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            MyDelegate myDelegate = Method1;
            myDelegate += Method2;

            // 여러 함수가 있는데 연결만 시켜서 하는거
            myDelegate("Hello");

            Func<int, int, int> addFunc = Add;
            int result = addFunc(3, 5);

            Action<string> printAction = PrintMessage;
            printAction("Hello, World");
        }

        // 어떤 행위가 이뤄질때 다른 행위가 처리가 필요한 애들을 다 예약을 걸어놓자
    }
}
