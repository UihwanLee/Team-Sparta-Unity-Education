namespace Test2
{
    internal class Program
    {
        private static void Add(int i, ref int result)
        {
            result += i;
        }

        static void Main(string[] args)
        {
            int total = 10;
            Console.WriteLine(total);
            Add(200, ref total);
            Console.WriteLine(total);
        }
    }
}
