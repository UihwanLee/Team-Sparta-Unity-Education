using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Maps
{
    public class Map
    {
        /*
          * Map 스크립트
          * 
          * 각 Scene에 맞는 Map을 관리하는 클래스이다.
          * 
          * [Map 정보]
          * 1. 마을 Map
          * 2. 모험 Map
          * 3. 순찰 Map
          * 4. 훈련 Map
          * 5. 던전 Map
          * 6. 휴식 Map
          * 
          * 마을 Map 형태
          * ---------------
          * |   _    _    |
          * |  | |  | |   |
          * |             |
          * ---------------
          * 
          * 모험, 순찰, 휴식 Map 형태
          * ----------------
          * 
          *      (P)
          *      
          * ----------------
          * 
          * Player가 오른쪽으로 이동하고 --- 배치만 바뀌는 형태
          * 
          */

        // Map 크기
        protected int width;
        protected int height;
        protected char[,] map;
        protected List<string> bg = new List<string>();

        // 애니메이션 연출을 위한 변수
        protected int startBGFrameIdx = 0;
        protected float elapsedSum = 0;

        // 애니메이션 시 Player frame
        protected string[] playerFrames = { "(P)", "(p)" };
        protected int frame = 0;

        // ConsoleHelper Line
        public int baseLine = 0;
        public int endLine = 0;

        protected Random radom = new Random();

        // 건물 유형
        protected string[][] buildings = new string[][]
        {
            new string[]
            {
                " ___ ",
                "|   |",
                "|___|",
            },
            new string[]
            {
                " ____ ",
                "|    |",
                "|____|",
            },
        };

        public Map() {}

        // 맵 그리기
        public virtual void DrawMap()
        {

        }

        // 맵 표시
        public virtual void DisplayMap()
        {
            int height = map.GetLength(0);
            int width = map.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                Console.Write(' ');
                for (int x = 0; x < width; x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Map 초기화
        public void InitializeMap()
        {
            int height = map.GetLength(0);
            int width = map.GetLength(1);

            // 빈 여백으로 채우기
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    map[y, x] = ' ';

            // 벽 그리기 : 세로
            for (int y = 0; y < height; y++)
            {
                map[y, 0] = '|';
                map[y, width - 1] = '|';
            }

            // 벽 그리기 : 가로
            for (int x = 0; x < width; x++)
            {
                map[0, x] = (x == 0 || x == width - 1) ? '+' : '-';
                map[height - 1, x] = (x == 0 || x == width - 1) ? '+' : '-';
            }
        }
    }
}
