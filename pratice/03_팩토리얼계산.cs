using System;

class 팩토리얼계산
{
    private static int num = 100;

    public static void Main()
    {
        Input();
        Output();
    }

    public static void Input()
    {
        Console.Write("Enter a number : ");
        num = int.Parse(Console.ReadLine());
    }

    public static void Output()
    {
        int result = 1;
        for(int i=num; i>0; i--)
        {
            result *= i;
        }
        Console.Write("Factorial of " + num + " is " + result);
    }
}
