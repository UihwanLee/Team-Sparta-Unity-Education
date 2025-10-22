namespace Test1
{
    public class Program
    {
        static int Sum(int[] arr)
        {
            int sum = 0;
            for(int i=0; i<arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        static void Main(string[] args)
        {
            int[] ints = { 3, 6, 7, 9 };
            Console.WriteLine(Sum(ints));
        }
    }
}
