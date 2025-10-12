using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Maps
{
    public class TownMap : Map
    {
        /*
        * 마을 Map 형태
        * ---------------
        * |   _    _    |
        * |  | |  | |   |
        * |             |
        * ---------------
        * 
        */

        public TownMap() { }

        public override void DrawMap()
        {
            base.DrawMap();

            // Map 크기 초기화
            width = 20;
            height = 6;
            map = new char[height, width];

            // 벽 그리기
            InitializeMap();

            // 건물 그리기 : 중간 점 기준으로 나뉘어 2개 배치
            int buildingWitdh = width / 2;
            int buildingHeight = height / 2;

            DrawBuilding(buildingWitdh - 6, buildingHeight - 2);
            DrawBuilding(buildingWitdh, buildingHeight - 2);
        }

        // 건물 그리기
        private void DrawBuilding(int startX, int startY)
        {
            string[] building = buildings[1];

            for (int y = 0; y < building.Length; y++)
            {
                for (int x = 0; x < building[y].Length; x++)
                {
                    // Start Position 위치 기준으로 사각형 그리기 (좌측 상단 꼭짓점에서 시작)
                    int posX = startX + x;
                    int posY = startY + y;

                    if (posX < width && posY < height)
                        map[posY, posX] = building[y][x];
                }
            }
        }
    }
}
