namespace Test9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            Console.WriteLine(stack.Pop());
            stack.Push(4);
            stack.Push(5);

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());
        }

        // 다음 코드의 출력 결과를 작성하고, 왜 그렇게 되는지 이유를 설명해주세요.

        // 2 5 4 1
        // 스택은 선입후출 -> 나중에 들어온 값이 먼저 나감
        // 1, 2, 3 들어오고 Pop 하면 3이 나가고 1, 2 남음
        // stack.Pop()은 가장 맨 위에 있는 값을 반환하므로 2를 반환함
        // 1, 4, 5
        // 마지막 들어온 순서대로 5, 4, 1 출력
    }
}
