using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Maps
{
    public class AdventureMap : Map
    {
        /*
        * 랜덤 모험 Map
        */

        private string monster = "(M)";

        public AdventureMap() { }

        public override void DrawMap()
        {
            base.DrawMap();

            // Map 크기 초기화
            width = 30;
            height = 10;
            map = new char[height, width];

            // 듬성 듬성 나무가 있는 걸로 연출
            for (int i = 0; i < 200; i++)
            {
                string isTree = radom.NextDouble() < 0.3 ? "|" : " ";
                bg.Add(isTree);
            }
        }

        // 랜덤 모험 Map 그리기
        public void DisplayMap(float elapsed, bool isFindMonster)
        {
            elapsedSum += elapsed;

            if (elapsedSum >= 0.1f)
            {
                elapsedSum = 0f;
                frame++;
                AdventureAnim(frame, isFindMonster);
            }
        }

        // 랜덤 모험 애니메이션 연출
        private void AdventureAnim(int frame, bool isFindMonster)
        {
            int midY = height / 2;

            // BG frame 단위 작업 : 몬스터 조우 시 배경 멈춤
            startBGFrameIdx = isFindMonster ? startBGFrameIdx : frame % bg.Count; // 리스트 다 돌면 다시 루프 진행

            // Player frame 작업
            string player = playerFrames[frame / 3 % playerFrames.Length]; // 0.3 간격으로 표시

            // Player는 항상 맵 가운데 배치
            int playerPosX = width / 2 - 1;

            // SetCursorPosition을 이용하여 덮어쓰기를 하므로 한 라인 당 출력
            string drawLine = "";
            baseLine = 1;
            endLine = height + baseLine;

            for (int line = baseLine; line < endLine; line++)
            {
                drawLine = "";

                if (line == baseLine || line == endLine - 1)
                {
                    // 맨 윗 줄과 아랫 줄은 나무 표시
                    for (int x = 0; x < width; x++)
                        drawLine += bg[(startBGFrameIdx + x) % bg.Count];
                }
                else if (line == midY)
                {
                    // 중간 줄에는 Player 표시
                    for (int x = 0; x < width; x++)
                    {
                        if (x == playerPosX)
                        {
                            drawLine += player;
                            x += 2;     // Player는 '(', 'P', ')' 3가지 char로 이루어져있으므로 2개 띄어넘기

                            // 몬스터 조우 시 몬스터 추가
                            if (isFindMonster)
                            {
                                drawLine += monster;
                                x += 3;
                            }
                        }
                        else drawLine += " ";   // 나머지는 공백
                    }
                }
                else
                {
                    drawLine = new string(' ', width);
                }

                ConsoleHelper.WriteLine(drawLine, line);
            }
        }
    }
}
