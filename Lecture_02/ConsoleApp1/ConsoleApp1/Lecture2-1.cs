using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // 틱택톡 게임
    /*
     * 0: 아무 상태 X
     * 1: 플레이어 1 상태
     * 2: 플레이어 2 상태
     * 
     * 이 프로젝트에서는 번갈아가면서 진행
     */
    internal class Lecture2_1
    {
        static int current_player = 1;
        static char player_1 = 'O';
        static char player_2 = 'X';
        static List<int> input_pos = new List<int>();

        static int user_i = 0;
        static int user_j = 0;

        static bool player1_win = false;
        static bool player2_win = false;

        static bool isGamePlaying = true;

        static char[,] board = new char[3, 3]
            {
                {' ', ' ', ' '},
                {' ', ' ', ' '},
                {' ', ' ', ' '},
            };

        static void Main(string[] args)
        {
            InitBoard();
            while (isGamePlaying)
            {
                Input();
                Process();
                Result();
            }
            Console.WriteLine("게임종료!");
        }

        // 입력 받기
        static void Input()
        {
            ShowBoard();
            input_pos.Clear();
            int curr_player = (current_player == 1) ? 1 : 2;
            Console.WriteLine("현재 플레이어: player {0}", curr_player);
            Console.Write("표시할 행/열을 입력하세요((0,0) ~ (2,2): ");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            for(int i=0; i<numbers.Length; i++)
            {
                // 정수형인지 체크, 2개 입력했는지 체크
                if(int.TryParse(numbers[i], out int value)==false || i>=2)
                {
                    Console.WriteLine("[ERROR] 행 열을 제대로 입력해주세요!");
                    Input();
                }

                int num = int.Parse(numbers[i]);

                // 자릿수 범위 체크
                if (num < 0 || num > 2)
                {
                    Console.WriteLine("[ERROR] 행 열을 제대로 입력해주세요!");
                    Input();
                }

                input_pos.Add(int.Parse(numbers[i]));
            }

            if (CheckBoard(input_pos[0], input_pos[1]) == false)
            {
                Console.WriteLine("[ERROR] 이미 존재하는 자리입니다!");
                Input();
            }

            user_i = input_pos[0];
            user_j = input_pos[1];
        }

        // 예외처리: 입력한 자리에 이미 있는지 체크
        static bool CheckBoard(int i, int j)
        {
            return board[i, j] == ' ';
        }

        static void Process()
        {
            if(current_player == 1)
            {
                board[user_i, user_j] = player_1;
                if (Matched(player_1))
                {
                    player1_win = true;
                    return;
                }
            }
            else if(current_player == -1)
            {
                board[user_i, user_j] = player_2;
                if (Matched(player_2))
                {
                    player2_win = true;
                    return;
                }
            }
        }

        static bool Matched(char player)
        {
            // 일자 체크: 가로
            if(MatchedLineOption1(0, player) || 
                MatchedLineOption1(1, player) || 
                MatchedLineOption1(2, player))
            {
                return true;
            }
            // 일자 체크: 세로
            if (MatchedLineOption2(0, player) ||
                MatchedLineOption2(1, player) ||
                MatchedLineOption2(2, player))
            {
                return true;
            }
            // 대각선 체크
            if (MatchedLineOption3(player))
            {
                return true;
            }

            return false;
        }

        static bool MatchedLineOption1(int Line, char player)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, Line] != player) return false;
            }

            return true;
        }

        static bool MatchedLineOption2(int Line, char player)
        {
            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (board[Line, i] != player) return false;
            }

            return true;
        }

        static bool MatchedLineOption3(char player)
        {
            if (board[0,0] == player && board[1,1]==player && board[2,2]==player) return true;
            if (board[2, 0] == player && board[1, 1] == player && board[0, 2] == player) return true;

            return false;
        }

        static void ShowBoard()
        {
            for(int i=0; i<board.GetLength(0); i++)
            {
                for(int j=0; j<board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                    if (i <= 2) Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        static void InitBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void Result()
        {
            if(player1_win)
            {
                isGamePlaying = false;
                ShowBoard();
                Console.WriteLine("첫번째 플레이어 승리!");
            }
            else if (player2_win)
            {
                isGamePlaying = false;
                ShowBoard();
                Console.WriteLine("두번째 플레이어 승리!");
            }

            // 게임이 안끝났으면 플레이어 바꾸기
            current_player *= -1;
        }
    }
}
