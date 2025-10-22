namespace Test4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 3;

            x += x * ++y;

            Console.WriteLine(x++);

            // ++을 앞에다 쓰면 1이 먼저 더해지고
            // ++을 뒤에다 쓰면 후순위로 출력하고 더해진다
            // x += (2) * (4)

            // x = x + x * ++y
            // x = 2 + ((2) * (4))
            // x값에는 10이 들어가고
            // x++에서 10을 먼저 출력하고 이후 11이 되는것. 11은 출력안함
        }
    }
}
