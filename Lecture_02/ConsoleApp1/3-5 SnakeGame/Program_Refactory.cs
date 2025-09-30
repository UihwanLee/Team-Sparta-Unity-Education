using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    // 좌표를 나타내는 구조체
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x; Y = y;
        }

        public void Update(int x, int y)
        {
            X = x; Y = y;
        }
    }

    class Board
    {
        private const int BOARD_SIZE = 10;
        private const char CELL_EMPTY = '□';
        private const char CELL_WARM = '■';
        private const char CELL_MEAT = '★';

        private char[,] grid;
        private Position meat;

        private static Random rnd = new Random();

        public Board()
        {
            grid = new char[BOARD_SIZE, BOARD_SIZE];
            ResetMeat();
        }

        // 보드 초기화
        private void ClearBoard()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
                for (int j = 0; j < BOARD_SIZE; j++)
                    grid[i, j] = CELL_EMPTY;
        }

        // 먹이 새 위치 생성
        private void ResetMeat()
        {
            int x = rnd.Next(0, BOARD_SIZE);
            int y = rnd.Next(0, BOARD_SIZE);
            meat = new Position(x, y);
        }

        // 보드에 지렁이 + 먹이 반영
        public void Draw(Warm warm)
        {
            ClearBoard();

            foreach (var body in warm.Bodies)
                grid[body.X, body.Y] = CELL_WARM;

            grid[meat.X, meat.Y] = CELL_MEAT;
        }

        // 보드 출력
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("=== 스네이크 게임 ===\n");

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                    Console.Write(grid[i, j]);
                Console.WriteLine();
            }
        }

        // 먹이를 먹었는지 확인
        public bool CheckEat(Warm warm)
        {
            if (warm.Head.X == meat.X && warm.Head.Y == meat.Y)
            {
                warm.Grow();
                ResetMeat();
                return true;
            }
            return false;
        }

        // 보드 범위 체크
        public bool IsInside(int x, int y)
            => x >= 0 && x < BOARD_SIZE && y >= 0 && y < BOARD_SIZE;
    }

    class Warm
    {
        private List<Position> bodies = new List<Position>();
        public IEnumerable<Position> Bodies => bodies;
        public Position Head => bodies[0];

        public void Init()
        {
            bodies.Clear();
            bodies.Add(new Position(5, 5));
            bodies.Add(new Position(5, 4));
            bodies.Add(new Position(5, 3));
        }

        // 이동 (머리 → 새 위치, 몸 → 앞 칸 따라감)
        public bool Move(int dx, int dy)
        {
            int newX = Head.X + dx;
            int newY = Head.Y + dy;

            // 자기 몸 충돌 확인
            if (bodies.Any(b => b.X == newX && b.Y == newY))
                return false;

            int prevX = newX, prevY = newY;
            for (int i = 0; i < bodies.Count; i++)
            {
                int tempX = bodies[i].X, tempY = bodies[i].Y;
                bodies[i].Update(prevX, prevY);
                prevX = tempX; prevY = tempY;
            }
            return true;
        }

        public void Grow()
        {
            // 마지막 몸 좌표 복사해서 추가
            var last = bodies[^1];
            bodies.Add(new Position(last.X, last.Y));
        }
    }

    internal class Program
    {
        private static bool isRunning = true;
        private static Board board;
        private static Warm warm;

        private const int TARGET_SIZE = 10;  // static const이므로 모든 static 메서드에서 접근 가능

        static void Main(string[] args)
        {
            InitGame();
            Run();
            Console.WriteLine("게임 종료! 지렁이가 충분히 성장했습니다!");
        }

        static void InitGame()
        {
            board = new Board();
            warm = new Warm();
            warm.Init();

            board.Draw(warm);
            board.Display();
        }

        static void Run()
        {
            while (isRunning)
            {
                HandleInput();
            }
        }

        static void HandleInput()
        {
            Console.WriteLine("이동 (WASD): ");
            var key = Console.ReadKey(true).Key;

            int dx = 0, dy = 0;
            switch (key)
            {
                case ConsoleKey.W: dx = -1; break;
                case ConsoleKey.S: dx = 1; break;
                case ConsoleKey.A: dy = -1; break;
                case ConsoleKey.D: dy = 1; break;
                default: return;
            }

            int nextX = warm.Head.X + dx;
            int nextY = warm.Head.Y + dy;

            // 범위 체크
            if (!board.IsInside(nextX, nextY))
            {
                Console.WriteLine("범위를 벗어났습니다! 게임 종료!");
                return;
            }

            // 이동 시 자기 몸 충돌 체크
            if (!warm.Move(dx, dy))
            {
                Console.WriteLine("자기 몸에 부딪혔습니다! 게임 종료!");
                return;
            }

            board.CheckEat(warm);
            board.Draw(warm);
            board.Display();
        }
    }
}