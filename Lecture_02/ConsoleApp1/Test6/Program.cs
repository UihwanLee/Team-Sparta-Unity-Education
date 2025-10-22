namespace Test6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = { 4, 7, 2, 5, 6, 8, 3 };

            Array.Sort(intArr);

            foreach (int i in intArr)
                    Console.Write(i + " ");
        }
    }
}
