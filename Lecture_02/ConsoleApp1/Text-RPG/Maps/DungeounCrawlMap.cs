using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Maps
{
    public class DungeounCrawlMap : Map
    {
        /*
        * 던전 탐험 Map
        */

        private string leftWall, rightWall;
        private double value;

        public DungeounCrawlMap() { }

        public override void DrawMap()
        {
            base.DrawMap();

            // Map 크기 초기화
            width = 30;
            height = 10;
            map = new char[height, width];
            value = 0;
            leftWall = "/";
            rightWall = "\\";
        }

        // 랜덤 모험 Map 그리기
        public void DisplayMap(float elapsed)
        {
            elapsedSum += elapsed;

            if (elapsedSum >= 0.1f)
            {
                elapsedSum = 0f;
                frame++;
                AdventureAnim(frame);
            }
        }

        // 랜덤 모험 애니메이션 연출
        private void AdventureAnim(int frame)
        {
            baseLine = 1;
            endLine = height + baseLine;

            for (int line = baseLine; line < endLine; line++)
            {
                string drawLine = "";

                // frame에 따라 wall 변경 : 중간마다 벽 없애서 이동하는 연출 구현
                if(frame % 2 == 0)
                {
                    value = radom.NextDouble();
                    leftWall = (value > 0.3) ? "/" : " ";
                    rightWall = (value > 0.3) ? "\\" : " ";
                }

                if (line == baseLine || line == endLine - 1)
                {
                    // 맨 윗 줄과 아랫 줄은 벽 표시
                    for (int x = 0; x < width; x++)
                    {
                        string wall = x == 0 || x == width - 1 ? "+" : "-";
                        drawLine += wall;
                    }
                }
                else if(line > endLine/2)
                {
                    drawLine += "|";

                    // line 중간에서 벽 생성

                    int innerWidth = width - 2; // 양쪽 벽("|") 제외
                    int offsetLeft = (innerWidth / 2) - line;  // 왼쪽 시작 위치
                    int offsetRight = (innerWidth / 2) + line; // 오른쪽 끝 위치

                    for (int x = 0; x < innerWidth; x++)
                    {
                        if (x == offsetLeft) drawLine += leftWall;   
                        else if (x == offsetRight) drawLine += rightWall; 
                        else drawLine += " ";
                    }

                    drawLine += "|";
                }
                else
                {
                    drawLine += "|";
                    drawLine += new string(' ', width-2);
                    drawLine += "|";
                }

                ConsoleHelper.WriteLine(drawLine, line);
            }
        }
    }
}
