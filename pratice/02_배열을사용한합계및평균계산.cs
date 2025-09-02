using System;
using System.Collections.Generic;
using System.Numerics;

class 평균계산
{
    private static List<int> nums = new List<int> { 10, 20, 30, 40, 50 };

    public static void Main()
    {
        Console.WriteLine("Sum: " + CaculateSum(nums).ToString());
        Console.WriteLine("Average: " + CaculateAverage(nums).ToString());
    }

    // 합 계산
    public static int CaculateSum(List<int> nums)
    {
        int sum = 0;
        foreach(int num in nums) sum += num;
        return sum;
    }

    // 평균 계산
    public static int CaculateAverage(List<int> nums)
    {
        int avg = 0;
        avg = CaculateSum(nums) / nums.Count;
        return avg;
    }
}
