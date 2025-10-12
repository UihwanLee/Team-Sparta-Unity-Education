using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Maps
{
    public class DungeonMap : Map
    {
        /*
        * 던전 Map
        */

        public DungeonMap() { }

        public override void DrawMap()
        {
            base.DrawMap();

            // Map 크기 초기화
            width = 30;
            height = 10;
            map = new char[height, width];

            // 벽 그리기
            InitializeMap();

            // 던전 입구 그리기 : 쉬운 던전, 노말 던전, 어려운 던전
            int entranceWitdh = width / 2;
            int entranceHeight = height / 2;

            DrawDungeonEntrance(entranceWitdh - 10, entranceHeight - 3);
            DrawDungeonEntrance(entranceWitdh - 2, entranceHeight - 2);
            DrawDungeonEntrance(entranceWitdh + 6, entranceHeight - 3);
        }

        // 던전입구 그리기
        private void DrawDungeonEntrance(int startX, int startY)
        {
            string[] building = buildings[0];

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
