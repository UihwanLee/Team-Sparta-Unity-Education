using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Maps
{
    public class PatrolTownMap : Map
    {
        /*
        * 마을 순찰 Map
        */

        // Player가 Patrol하는 방향
        // Player는 작은 사각형 영역 안에서 루프를 돌며 돌아다님

        private int moveDirection = 1;          // 1: 오른쪽, 2: 아래, 3: 왼쪽, 4: 위

        private int patrolRectWidth = 15;        // 움직이는 영역 Width
        private int patrolRectHeight = 7;       // 움직이는 영역 Height

        private int playerPatrolPosX = 0;       // Player Patrol X 위치
        private int playerPatrolPosY = 0;       // Player Patrol Y 위치

        private string[] patrolEvent = { "(CH)", "(HD)", "(P1)", "(VL)" };

        public PatrolTownMap() { }

        public override void DrawMap()
        {
            base.DrawMap();

            // Map 크기 초기화
            width = 30;
            height = 10;
            map = new char[height, width];
        }

        // 마을 순찰 그리기
        public void DisplayMap(float elapsed, int eventOption)
        {
            elapsedSum += elapsed;

            if (elapsedSum >= 0.5f)
            {
                elapsedSum = 0f;
                frame++;
                PatrolTownAnim(frame, eventOption);
            }
        }

        private void PatrolTownAnim(int frame, int eventOption)
        {
            int midX = width / 2;
            int midY = height / 2;

            // Player frame 작업
            string player = playerFrames[frame / 3 % playerFrames.Length]; // 0.3 간격으로 표시

            // Player Patrol : Event 조우 시 Patrol 멈춤
            if (eventOption == -1) SetPlayerPatrol(player);

            // SetCursorPosition을 이용하여 덮어쓰기를 하므로 한 라인 당 출력
            string drawLine = "";
            baseLine = 1;
            endLine = height + baseLine;

            for (int line = baseLine; line < endLine; line++)
            {
                drawLine = "";

                if (line == baseLine || line == endLine - 1)
                {
                    // 맨 윗 줄과 아랫 줄은 벽 표시
                    for (int x = 0; x < width; x++)
                    {
                        string wall = x == 0 || x == width - 1 ? "+" : "-";
                        drawLine += wall;
                    }
                }
                else
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Player 중앙 배치
                        int startX = (width - patrolRectWidth) / 2;
                        int startY = (height - patrolRectHeight) / 2;

                        int playerPosX = playerPatrolPosX + startX;
                        int playerPosY = playerPatrolPosY + startY;

                        if (x == 0 || x == width - 1)
                        {
                            // 양쪽 사이드에 벽 추가
                            drawLine += "|";
                        }
                        else if (x == playerPosX && line - baseLine == playerPosY)
                        {
                            // Player Patrol 위치면 Player 추가
                            drawLine += player;
                            x += 2;

                            // Event 시 Event string 값 추가
                            if (eventOption != -1)
                            {
                                drawLine += patrolEvent[eventOption];
                                x += patrolEvent[eventOption].Length;
                            }

                            continue;
                        }
                        else
                        {
                            drawLine += " ";
                        }
                    }
                }

                ConsoleHelper.WriteLine(drawLine, line);
            }
        }

        private void SetPlayerPatrol(string player)
        {
            switch (moveDirection)
            {
                case 1: // 오른쪽 이동
                    playerPatrolPosX++;
                    if (playerPatrolPosX >= patrolRectWidth - player.Length - 1)
                        moveDirection = 2;
                    break;
                case 2: // 아래 이동
                    playerPatrolPosY++;
                    if (playerPatrolPosY >= patrolRectHeight - 2)
                        moveDirection = 3;
                    break;
                case 3: // 왼쪽 이동
                    playerPatrolPosX--;
                    if (playerPatrolPosX <= 1) moveDirection = 4;
                    break;
                case 4: // 위로 이동
                    playerPatrolPosY--;
                    if (playerPatrolPosY <= 1) moveDirection = 1;
                    break;
            }
        }
    }
}
