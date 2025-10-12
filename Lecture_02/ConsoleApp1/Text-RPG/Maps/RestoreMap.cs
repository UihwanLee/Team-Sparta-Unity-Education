using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Maps
{
    public class RestoreMap : Map
    {
        /*
        * Restore Map
        */

        // 휴식 frame
        private string[] restoreFrame;
        int restorePosition;

        // 휴식하는 모습 
        protected string[][] restoringView = new string[][]
        {
            // 1. 휴식 1
            new string[]
            {
                "    ( )    ",
                "   --|--   ",
                "     |     ",
                "    / \\    "
            },
            // 2. 휴식 2
            new string[]
            {
                "    ( ) z  ",
                "   --|--   ",
                "     |     ",
                "    / \\    "
            },
            // 3. 휴식 3
            new string[]
            {
                "    ( ) zZ ",
                "   --|--   ",
                "     |     ",
                "    / \\    "
            },
            // 4. 휴식 4
            new string[]
            {
                "    ( ) zZZ",
                "   --|--   ",
                "     |     ",
                "    / \\    "
            },
        };

        public RestoreMap() { }

        public override void DrawMap()
        {
            base.DrawMap();

            // Map 크기 초기화
            width = 20;
            height = 6;
            map = new char[height, width];

            // 운동 Frame 초기화
            int startY = height / 2;
            restoreFrame = restoringView[0];
        }

        // 운동 그리기
        public void DisplayMap(float elapsed)
        {
            elapsedSum += elapsed;

            if (elapsedSum >= 0.1f)
            {
                elapsedSum = 0f;
                frame++;
                ExercisingAnim(frame);
            }
        }

        // 운동 애니메이션 연출
        private void ExercisingAnim(int frame)
        {
            // 휴식 위치 고정
            int restorePosX = width / 2 - 5;
            int restorePosY = height / 2 - 2;

            // SetCursorPosition을 이용하여 덮어쓰기를 하므로 한 라인 당 출력
            string drawLine = "";
            baseLine = 1;
            endLine = height + baseLine;

            InitializeMap();

            // 휴식 Frame 변경
            restoreFrame = restoringView[frame / 3 % restoringView.Length];

            // 휴식 모습 그리기 : event에 따라 모습 변환
            DrawRestoring(restoreFrame, restorePosX, restorePosY);

            for (int line = baseLine; line < endLine; line++)
            {
                drawLine = "";

                for (int x = 0; x < width; x++)
                    drawLine += map[line - baseLine, x];

                ConsoleHelper.WriteLine(drawLine, line);
            }
        }

        // 휴식 모습 그리기
        private void DrawRestoring(string[] restoring, int startX, int startY)
        {
            for (int y = 0; y < restoring.Length; y++)
            {
                for (int x = 0; x < restoring[y].Length; x++)
                {
                    int posX = startX + x;
                    int posY = startY + y;

                    if (posX < width && posY < height)
                        map[posY, posX] = restoring[y][x];
                }
            }
        }
    }
}
