namespace _3_5_BlackJackGame
{
    /*
     * 21점에 가까우면 승리 초과하면 실패
     * 딜러가 17점이 넘으면 바로 종료
     */
    class Card
    {
        public string simbol;
        public string rank;
        public int score;

        public Card(string simbol, string rank, int score)
        {
            this.simbol = simbol;
            this.rank = rank;
            this.score = score;
        }
    }
    
    class GameManager
    {
        // 카드 리스트
        private List<Card> deck = new List<Card>();

        // 딜러 카드
        private List<Card> dealerCard = new List<Card>();

        // 플레이어 카드
        private List<Card> playerCard = new List<Card>();

        public GameManager() { }

        public void InitDeck()
        {
            string[] simbols = { "♠", "♥", "♣", "■" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach(var simbol in simbols)
            {
                foreach(var rank in ranks)
                {
                    // 카드 심볼 및 점수 변환
                    int score = int.TryParse(rank, out int tmp) ? tmp : (rank == "A" ? 1 : 10);
                    deck.Add(new Card(simbol, rank, score));
                }
            }
        }

        public void ShuffleDeck()
        {
            Random random = new Random();
            for(int i=deck.Count-1; i>0; i--)
            {
                int j = random.Next(0, i+1);

                var temp = deck[j];
                deck[j] = deck[i];
                deck[i] = temp;
            }
        }

        // 히트 시 카드 한장 뽑기
        public bool Hit()
        {
            playerCard.Add(DrawCard());

            if (GetScore(playerCard) > 21) return false;

            return true;
        }

        // 스코어 구하기
        public int GetScore(List<Card> cards)
        {
            int sum = 0;

            foreach(var card in cards)
            {
                sum += card.score;
            }

            return sum;
        }

        // 결과 확인
        public void Result()
        {
            int playerScore = GetScore(playerCard);
            int dealerScore = GetScore(dealerCard);

            if (dealerScore > 21 || playerScore > dealerScore)
                Console.WriteLine("플레이어 승리!");
            else if (playerScore < dealerScore)
                Console.WriteLine("딜러 승리!");
            else
                Console.WriteLine("무승부!");
        }

        // 카드 배분
        public void SettingCard()
        {
            // 딜러 2장 뽑기
            dealerCard.Clear();
            dealerCard.Add(DrawCard());
            dealerCard.Add(DrawCard());

            // 플레이어 2장 뽑기
            playerCard.Clear();
            playerCard.Add(DrawCard());
            playerCard.Add(DrawCard());

            // 딜러 차례
            while (GetScore(dealerCard) < 17)
            {
                dealerCard.Add(DrawCard());
            }

        }

        // Deck에서 카드 뽑기
        public Card DrawCard()
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            return card;
        }

        // 자신의 카드 보기
        public void DisplayPlayerCard()
        {
            Console.WriteLine("현재 내 카드 정보");
            for(int i=0; i<3; i++)
            {
                for (int j = 0; j < playerCard.Count; j++)
                {
                    if(i==0) Console.Write($"   {playerCard[j].simbol}   |");
                    if(i==1) Console.Write($"   {playerCard[j].rank}   |");
                    if (i == 2) Console.Write($"   {playerCard[j].score}   |");
                }
                Console.WriteLine();
            }
        }

        // 딜러 카드 표시
        public void DisplayDealerCard(bool isOpen)
        {
            Console.WriteLine("딜러 카드 정보");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < dealerCard.Count; j++)
                {
                    string rank = (isOpen) ? dealerCard[j].rank : "?";
                    int score = (isOpen) ? dealerCard[j].score : 0;
                    if (i == 0) Console.Write($"   {dealerCard[j].simbol}   |");
                    if (i == 1) Console.Write($"   {rank}   |");
                    if (i == 2) Console.Write($"   {score}   |");
                }
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static GameManager gameManager;

        static bool isRunning;

        static void Main(string[] args)
        {
            Init();
            Process();
            Console.WriteLine("게임 종료");
        }

        static void Init()
        {
            isRunning = true;
            gameManager = new GameManager();
            gameManager.InitDeck();
        }

        static void Process()
        {
            Console.Clear();
            gameManager.ShuffleDeck();
            gameManager.SettingCard();
            gameManager.DisplayDealerCard(false);
            gameManager.DisplayPlayerCard();
            while (isRunning)
            {
                Console.WriteLine();
                Console.Write("hit? (Yes or No): ");

                string input = Console.ReadLine();

                switch(input)
                {
                    case "Yes":
                        Console.Clear();
                        {
                            if (gameManager.Hit() == false)
                            {
                                isRunning = false;
                                gameManager.DisplayDealerCard(false);
                                gameManager.DisplayPlayerCard();
                                Console.WriteLine("21점이 넘었습니다! 게임 종료");
                                break;
                            }
                        }
                        gameManager.DisplayDealerCard(false);
                        gameManager.DisplayPlayerCard();
                        Console.WriteLine("카드를 뽑았습니다!");
                        break;
                    case "No":
                        Console.Clear();
                        gameManager.DisplayDealerCard(true);
                        gameManager.DisplayPlayerCard();
                        {
                            gameManager.Result();
                            isRunning = false;
                            break;
                        }
                        break;
                    default:
                        Console.WriteLine("입력이 잘못되었습니다.");
                        break;
                }
            }
        }


    }
}
