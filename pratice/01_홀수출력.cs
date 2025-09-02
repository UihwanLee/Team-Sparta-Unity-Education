using System;

class 홀수출력
{
    private static int num = 100;

    public static void Main()
    {
        //Method1();
        //Method2();
        //Method3();
    }

    // 01 for문을 사용해 홀수를 출력해주세요.
    public static void Method1()
    {
        for(int i=1; i<=num; i++)
        {
            if(i%2==1) Console.WriteLine(i);
        }
    }

    // 02 while문을 사용해 홀수를 출력해주세요
    public static void Method2()
    {
        int i=1;
        while(i<=num)
        {
            if(i%2==1) Console.WriteLine(i);
            i++;
        }
    }

    // 03 do-while문을 사용해 홀수를 출력해주세요
    public static void Method3()
    {
        int i=1;
        do
        {
            if(i%2==1) Console.WriteLine(i);
            i++;
        }
        while(i<=num);
    }
}
