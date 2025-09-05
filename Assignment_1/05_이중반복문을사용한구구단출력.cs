using System;

class 구구단출력
{
    public static void Main()
    {
        Output1();
        Output2();
    }

    // 세로로 출력
    public static void Output1()
    {
        Console.WriteLine("구구단 세로로 출력");
        // 2부터 9까지 구구단 출력
        for(int i=1; i<=9; i++)
        {
            // 1부터 9까지 곱한 결과를 출력
            for(int j=2; j<=9; j++)
            {
                Console.Write(j + " x " + i + " = " + i*j + " ");
            }
            Console.WriteLine("\n");
        }
    }

    // 가로로 출력
    public static void Output2()
    {
        Console.WriteLine("구구단 가로로 출력");
        // 2부터 9까지 구구단 출력
        for(int i=2; i<=9; i++)
        {
            // 1부터 9까지 곱한 결과를 출력
            for(int j=1; j<=9; j++)
            {
                Console.Write(i + " x " + j + " = " + i*j + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
