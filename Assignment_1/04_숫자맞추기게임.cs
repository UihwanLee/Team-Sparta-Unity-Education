using System;

class 숫자맞추기게임
{
    private static int numMax = 100;
    private static int answer = 0;
    private static int num = 0;

    public static void Main()
    {
        Init();
        while(true)
        {
            num = Input();
            if(Output(num)==true) break;
        }
    }

    // 01 게임 초기화: 컴퓨터가 랜덤한 값으로 숫자 정하기
    public static void Init()
    {
        Random rang = new Random();
        answer = rang.Next(1, numMax+1);
        Console.WriteLine(answer);
    }

    // 02 사용자로부터 숫자 받기
    public static int Input()
    {
        Console.Write("Enter your guess (1-" + numMax + "): ");
        return int.Parse(Console.ReadLine());
    }

    // 03 받은 숫자를 판단해 정답 체크
    public static bool Output(int num)
    {
        if(num==answer)
        {
            Console.WriteLine("Congratulations! You guessed the number.");
            return true;
        }
        else if(num>answer)
        {
            Console.WriteLine("Too high! Try again.");
        }
        else
        {
            Console.WriteLine("Too low! Try again.");
        }

        return false;
    }
}
