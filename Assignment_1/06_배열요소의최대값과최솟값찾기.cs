using System;

class 최대값과최소값
{
    private static int[] numbers = { 10, 20, 30, 40, 50 };
    private static int max = 0;
    private static int min = int.MaxValue;

    public static void Main()
    {
        Output(numbers);
    }

    public static void Output(int[] numbers)
    {
        // 최댓값 최솟값 찾기
        for(int i=0; i<numbers.Length; i++)
        {
            max = (max < numbers[i]) ? numbers[i] : max;
            min = (min > numbers[i]) ? numbers[i] : min;
        }

        Console.WriteLine("최댓값: " + max);
        Console.WriteLine("최솟값: " + min);
    }
}
