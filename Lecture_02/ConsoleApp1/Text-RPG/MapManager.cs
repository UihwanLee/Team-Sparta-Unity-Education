using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public class MapManager
    {
        /*
          * MapManager 스크립트
          * 
          * 각 Scene에 맞는 Map을 관리하는 클래스이다.
          * 
          * [Map 정보]
          * 1. 마을 Map
          * 2. 모험 Map
          * 3. 순찰 Map
          * 4. 던전 Map
          * 5. 휴식 Map
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


        private int townWidth = 20;
        private int townHeight = 6;
        private char[,] townMap;

        public MapManager() 
        {
            DrawMap();
        }

        // Map 생성 및 초기화
        private void DrawMap()
        {
            DrawTownMap();
        }

        // 마을 맵 초기화
        private void DrawTownMap()
        {
            townMap = new char[townHeight, townWidth];

            // 빈 여백으로 채우기
            for (int y = 0; y < townHeight; y++)
                for (int x = 0; x < townWidth; x++)
                    townMap[y, x] = ' ';

            // 벽 그리기 : 가로
            for(int x=0; x<townWidth; x++)
            {
                townMap[0, x] = (x == 0 || x == townWidth - 1) ? '+' : '-';
                townMap[townHeight-1, x] = (x==0 || x == townWidth - 1) ? '+' : '-';
            }

            // 벽 그리기 : 세로
            for(int y=0; y<townHeight; y++)
            {
                townMap[y, 0] = '|';
                townMap[y, townWidth - 1] = '|';
            }

            // 건물 그리기 : 중간 점 기준으로 나뉘어 2개 배치
            int buildingWitdh = (townWidth / 2);
            int buildingHeight = (townHeight / 2);

            DrawBuilding(buildingWitdh - 6, buildingHeight - 2);
            DrawBuilding(buildingWitdh, buildingHeight - 2);
        }

        // 건물 그리기
        private void DrawBuilding(int startX, int startY)
        {
            string[] building =
            {
                " ____ ",
                "|    |",
                "|____|",
            };

            for(int y=0; y<building.Length; y++)
            {
                for(int x=0; x < building[y].Length; x++)
                {
                    // Start Position 위치 기준으로 사각형 그리기 (좌측 상단 꼭짓점에서 시작)
                    int posX = startX + x;
                    int posY = startY + y;

                    if (posX < townWidth && posY < townHeight)
                        townMap[posY, posX] = building[y][x];
                }
            }
        }

        // 마을 맵 표시
        public void DisplayTownMap()
        {
            for(int y=0; y<townHeight;y++)
            {
                Console.Write(' ');
                for(int x=0; x<townWidth; x++)
                {
                    Console.Write(townMap[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
    }
}
