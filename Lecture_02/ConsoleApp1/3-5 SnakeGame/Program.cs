//using System.Drawing;

//namespace _3_5_SnakeGame
//{
//    /*
//     * 스네이크 게임
//     * 
//     * 보드판 크기 10x10
//     * 
//     * 지렁이 크기 5칸
//     * 
//     * 먹이 랜덤 생성
//     * 
//     */

//    public class Point
//    {
//        public int X;
//        public int Y;

//        public Point(int x, int y)
//        {
//            X = x; Y = y;
//        }

//        public void UpdatePos(int x, int y)
//        {
//            X = x; Y = y;
//        }
//    }

//    class Board
//    {
//        // 보드판 크기
//        private int MAX_BOARD_SIZE = 10;

//        // 보드판에 그래픽 구현할 문자
//        private char CELL_EMPTY = '□';
//        private char CELL_FILL = '■';

//        private char[,] board;

//        // 먹이
//        private Point meat = new Point(0, 0);

//        public Board() 
//        {
//            board = new char[MAX_BOARD_SIZE, MAX_BOARD_SIZE];
//            ResetMeat();
//        }

//        public void ResetBoard()
//        {
//            // 보드 초기화
//            for (int i = 0; i < MAX_BOARD_SIZE; i++)
//            {
//                for (int j = 0; j < MAX_BOARD_SIZE; j++)
//                {
//                    // 빈 화면으로 꽉 채우기
//                    board[i, j] = CELL_EMPTY;
//                }
//            }
//        }

//        // 먹이 초기화
//        private void ResetMeat()
//        { 
//            Random rnd = new Random();
//            int x = rnd.Next(0, MAX_BOARD_SIZE);
//            int y = rnd.Next(0, MAX_BOARD_SIZE);
//            meat.UpdatePos(x, y);
//        }

//        // 지렁이 그리기
//        public void DrawBoard(List<Point> warm)
//        {
//            ResetBoard();
//            foreach (Point body in warm)
//            {
//                // 지렁이 body마다 그려줌
//                board[body.X, body.Y] = CELL_FILL;
//            }

//            // 먹이 그리기
//            board[meat.X, meat.Y] = CELL_FILL;
//        }

//        // 보드판 그리기
//        public void Display()
//        {
//            Console.Clear();

//            Console.WriteLine("스네이크 게임");
//            Console.WriteLine();

//            for (int i = 0; i < MAX_BOARD_SIZE; i++)
//            {
//                for (int j = 0; j < MAX_BOARD_SIZE; j++)
//                {
//                    Console.Write(board[i, j]);
//                }
//                Console.WriteLine();
//            }
//        }

//        // Warm body 중 먹이를 먹었는지 체크
//        public void CheckEat(Warm warm)
//        {
//            for(int i=0; i<warm.Warms.Count; i++) 
//            {
//                if (warm.Warms[0].X == meat.X && warm.Warms[0].Y == meat.Y)
//                {
//                    // 지렁이 몸 생성!
//                    warm.AddBody();

//                    // 먹이 다시 생성
//                    ResetMeat();
//                }
//            }
//        }

//        // 보드판 넘는지 체크
//        public bool CheckArrange(int x, int y)
//        {
//            if (x < 0 || x >= 10 || y < 0 || y >= 10)
//            {
//                return false; // 범위 벗어남
//            }
//            return true; // 범위 안
//        }
//    }

//    class Warm
//    {
//        // Body로 이루어진 warm 구조
//        List<Point> warm = new List<Point>();


//        public Warm() { }

//        public void Init()
//        {
//            // 지렁이는 초반에 최소 3개의 Body가 있음
//            warm.Clear();
//            warm.Add(new Point(5, 5));
//            warm.Add(new Point(5, 4));
//            warm.Add(new Point(5, 3));
//        }

//        public void UpdateBody(int p, int q)
//        {
//            // 예외처리
//            // 자기 몸과 충돌 X
//            int x = warm[0].X + p; int y = warm[0].Y + q;
//            foreach (Point body in warm)
//            {
//                if (x == body.X && y == body.Y) return;
//            }

//            int temp_x; int temp_y;
//            // 이전 Body에 Pos 갱신
//            foreach (Point body in warm)
//            {
//                temp_x = body.X; temp_y = body.Y;
//                body.UpdatePos(x, y);
//                x = temp_x; y = temp_y;
//            }
//        }

//        // 몸 생성
//        public void AddBody()
//        {
//            if (warm.Count < 2) return;

//            // 마지막 위치에 생성
//            int last_X = warm[0].X;
//            int last_Y = warm[0].Y;

//            warm.Add(new Point(last_X, last_Y));
//        }

//        // 프로퍼티
//        public List<Point> Warms { get { return warm; } }
//    }

//    internal class Program
//    {
//        // Bool 타입 변수: 상태
//        static bool isRunning = true;

//        // 보드판
//        static Board board;

//        // 지렁이
//        static Warm warm;

//        static void Main(string[] args)
//        {
//            InitGame();
//            Process();
//        }

//        static void InitGame()
//        {
//            // 변수 초기화
//            isRunning = true;

//            // 보드판 생성
//            board = new Board();

//            // 지렁이 생성
//            warm = new Warm();

//            // 초기화
//            board.ResetBoard();
//            warm.Init();
//            board.DrawBoard(warm.Warms);

//            // 보드판 보여주기
//            board.Display();
//        }

//        static void Process()
//        {
//            while(isRunning)
//            {
//                GetInput();
//            }
//            Console.WriteLine("지렁이를 모두 키우셨습니다!");  
//        }

//        static void GetInput()
//        {
//            Console.WriteLine("이동할 방향키 입력하세요!");
//            ConsoleKeyInfo key = Console.ReadKey();   // 키 하나 입력 대기
//            int p = 0; int q = 0;
//            switch(key.Key)
//            {
//                case ConsoleKey.W:
//                    p--;
//                    break;
//                case ConsoleKey.A:
//                    q--;
//                    break;
//                case ConsoleKey.S:
//                    p++;
//                    break;
//                case ConsoleKey.D:
//                    q++;
//                    break;
//                default:
//                    break;
//            }

//            if (board.CheckArrange(warm.Warms[0].X + p, warm.Warms[0].Y + q) == false)
//            {
//                Console.WriteLine("범위를 지나갔습니다!");
//                return;
//            }

//            Console.WriteLine(p + " " + q);

//            warm.UpdateBody(p, q);
//            board.CheckEat(warm);
//            board.DrawBoard(warm.Warms);
//            board.Display();

//            // 지렁이 몸이 10개 이상이면 게임 종료!
//            if(warm.Warms.Count >= 10)
//            {
//                isRunning = false;
//            }
//        }
//    }  
//}
