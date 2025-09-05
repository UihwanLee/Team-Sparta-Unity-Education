using System;

class 숫자야구게임
{
    // 게임 변수
    private static int[] targetNumber;
    private static string userGuess;
    private static int strikes;
    private static int balls;
    private static bool guessedCorrectly;
    private static int attempts;


    public static void Main()
    {
        Init();
        while(true)
        {
            if(Input()==false) continue;
            Output();

            if(guessedCorrectly) break;
        }
    }


    // 게임 초기화
    private static void Init()
    {
        targetNumber = new int[]{9, 8, 7};
        strikes = 0;
        balls = 0;
        attempts = 1;
        guessedCorrectly = false;
    }

    // 사용자 입력
    private static bool Input()
    {
        Console.Write("Enter your guess (3 digits): ");
        userGuess = Console.ReadLine();

        // 예외처리
        // 알파벳을 입력했는지 확인
        if(string.IsNullOrEmpty(userGuess) || userGuess.Length != 3)
        {
            Console.WriteLine("똑바로 입력해주세요! 숫자 3개를 연달아서");
            return false;
        }

        // 숫자를 입력했는지 확인
        if(!char.IsDigit(userGuess[0]) || !char.IsDigit(userGuess[1]) || !char.IsDigit(userGuess[2]))
        {
            Console.WriteLine("숫자를 입력해주세요!");
            return false;
        }

        return true;
    }

    private static void Output()
    {
        // 변수 초기화
        strikes = 0;
        balls = 0;

        for(int i=0; i<userGuess.Length; i++)
        {
            for(int j=0; j<targetNumber.Length; j++)
            {
                if(targetNumber[j] == int.Parse(userGuess[i].ToString()))
                {
                    if(i==j) 
                    {
                        // 자릿수와 숫자 모두 맞는 경우
                        strikes++;
                        break;
                    }
                    else
                    {
                        // 자릿수는 맞지 않지만 숫자가 포함된 경우
                        balls++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(strikes + " Strike(s), " + balls + " Ball(s)");

        if(strikes==3)
        {
            Console.WriteLine("Congratulations! You've guessed the number in " + attempts + " attempts.");
            guessedCorrectly = true;
        }
        else
        {
            attempts++;
        }
    }
}
