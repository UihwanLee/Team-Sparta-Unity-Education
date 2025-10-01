//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _3_5_BlackJackGame
//{
//    class Card
//    {
//        public string Symbol { get; }
//        public string Rank { get; }
//        public int Score { get; }

//        public Card(string symbol, string rank, int score)
//        {
//            Symbol = symbol;
//            Rank = rank;
//            Score = score;
//        }

//        public override string ToString()
//        {
//            return $"{Symbol}{Rank}";
//        }
//    }

//    class GameManager
//    {
//        private List<Card> Deck = new List<Card>();
//        private List<Card> DealerHand = new List<Card>();
//        private List<Card> PlayerHand = new List<Card>();
//        private Random random = new Random();

//        public void InitDeck()
//        {
//            Deck.Clear();
//            string[] symbols = { "♠", "♥", "♣", "■" };
//            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

//            foreach (var symbol in symbols)
//            {
//                foreach (var rank in ranks)
//                {
//                    int score = int.TryParse(rank, out int tmp) ? tmp : (rank == "A" ? 1 : 10);
//                    Deck.Add(new Card(symbol, rank, score));
//                }
//            }
//        }

//        public void ShuffleDeck()
//        {
//            for (int i = Deck.Count - 1; i > 0; i--)
//            {
//                int j = random.Next(0, i + 1);
//                (Deck[i], Deck[j]) = (Deck[j], Deck[i]);
//            }
//        }

//        public void DealInitialCards()
//        {
//            DealerHand.Clear();
//            PlayerHand.Clear();

//            DealerHand.Add(DrawCard());
//            DealerHand.Add(DrawCard());

//            PlayerHand.Add(DrawCard());
//            PlayerHand.Add(DrawCard());

//            while (GetScore(DealerHand) < 17)
//                DealerHand.Add(DrawCard());
//        }

//        public bool PlayerHit()
//        {
//            PlayerHand.Add(DrawCard());
//            return GetScore(PlayerHand) <= 21;
//        }

//        public int GetScore(List<Card> hand)
//        {
//            int sum = hand.Sum(c => c.Score);
//            int aceCount = hand.Count(c => c.Rank == "A");

//            // Ace를 11로 계산할 수 있으면 그렇게 함
//            while (aceCount > 0 && sum + 10 <= 21)
//            {
//                sum += 10;
//                aceCount--;
//            }

//            return sum;
//        }

//        public void ShowHands(bool showDealerAll)
//        {
//            Console.WriteLine("딜러 카드:");
//            DisplayHand(DealerHand, showDealerAll);

//            Console.WriteLine("플레이어 카드:");
//            DisplayHand(PlayerHand, true);
//        }

//        private void DisplayHand(List<Card> hand, bool isOpen)
//        {
//            foreach (var card in hand)
//            {
//                if (isOpen) Console.Write($"{card} ");
//                else Console.Write("? ");
//            }
//            Console.WriteLine();
//        }

//        public void ShowResult()
//        {
//            int playerScore = GetScore(PlayerHand);
//            int dealerScore = GetScore(DealerHand);

//            Console.WriteLine($"플레이어 점수: {playerScore}");
//            Console.WriteLine($"딜러 점수: {dealerScore}");

//            if (playerScore > 21) Console.WriteLine("플레이어 Bust! 딜러 승리");
//            else if (dealerScore > 21 || playerScore > dealerScore) Console.WriteLine("플레이어 승리!");
//            else if (playerScore < dealerScore) Console.WriteLine("딜러 승리!");
//            else Console.WriteLine("무승부!");
//        }

//        private Card DrawCard()
//        {
//            var card = Deck[0];
//            Deck.RemoveAt(0);
//            return card;
//        }
//    }

//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            GameManager game = new GameManager();
//            game.InitDeck();
//            game.ShuffleDeck();
//            game.DealInitialCards();

//            bool running = true;

//            while (running)
//            {
//                Console.Clear();
//                game.ShowHands(false);

//                Console.Write("Hit? (Yes/No): ");
//                string input = Console.ReadLine();

//                if (input?.ToLower() == "yes")
//                {
//                    if (!game.PlayerHit())
//                    {
//                        Console.Clear();
//                        game.ShowHands(true);
//                        Console.WriteLine("플레이어 Bust! 게임 종료");
//                        running = false;
//                    }
//                }
//                else if (input?.ToLower() == "no")
//                {
//                    Console.Clear();
//                    game.ShowHands(true);
//                    game.ShowResult();
//                    running = false;
//                }
//                else
//                {
//                    Console.WriteLine("잘못된 입력입니다.");
//                }
//            }

//            Console.WriteLine("게임 종료");
//        }
//    }
//}

