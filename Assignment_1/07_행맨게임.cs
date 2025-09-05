using System;

class 행맨게임
{
    // 게임 변수
    private static char[] words;
    private static string secretWord;
    private static string guessWord;
    private static int attempts;
    private static bool wordGuessed;


    public static void Main()
    {
        Init();
        while(true)
        {
            if(Input()==false) continue;
            if(Output()==true) break;
        }
    }


    // 게임 초기화
    private static void Init()
    {
        secretWord = "hangman";
        words = new char[secretWord.Length];
        for (int i = 0; i < words.Length; i++) words[i] = '*';
        guessWord = "_";
        attempts = 6;
        wordGuessed = false;
    }

    // 사용자 입력
    private static bool Input()
    {
        Console.Write("알파벳을 입력해주세요: ");
        guessWord = Console.ReadLine();

        // 알파벳을 입력했는지 확인
        if(string.IsNullOrEmpty(guessWord) || guessWord.Length != 1)
        {
            Console.WriteLine("한글자만 입력해주세요!");
            return false;
        }

        // 숫자를 입력했는지 확인
        if(char.IsDigit(guessWord[0]))
        {
            Console.WriteLine("숫자는 입력할 수 없습니다!");
            return false;
        }

        return true;
    }

    // 결과
    private static bool Output()
    {
        bool isTrue = false;

        // 정답에서 맞는 알파벳이 있는지 확인
        for(int i=0; i<secretWord.Length; i++)
        {
            if(secretWord[i].ToString() == guessWord)
            {
                // 중첩되는 알파벳 체크
                if(words[i]==secretWord[i]) continue;

                words[i] = secretWord[i]; 
                isTrue = true;

                break;
            }
        }

        // 모두 정답을 맞췄는지 확인
        wordGuessed = true;
        for(int i = 0; i < secretWord.Length; i++)
        {
            if(words[i] != secretWord[i])
            {
                wordGuessed = false;
                break;
            }
        }

        if(isTrue)
        {
            Console.WriteLine("맞췄습니다!");

            if(wordGuessed)
            {
                Console.WriteLine("정답을 맞췄습니다! 정답 : " + secretWord);
                return true;
            }
        }
        else
        {
            attempts--;
            Console.WriteLine("틀렸습니다!");

            if(attempts <= 0)
            {
                Console.WriteLine("현재 맞출 수 있는 기회: " + attempts);
                Console.WriteLine("결국 못맞췄습니다! 게임종료!");
                Console.WriteLine("정답은 " + secretWord + "였습니다!");
                return true;
            }
        }

        Console.WriteLine("현재 추측 단어: " + new string(words));
        Console.WriteLine("현재 맞출 수 있는 기회: " + attempts);

        return false;
    }
}
