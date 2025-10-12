using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Maps
{
    public class TrainingMap : Map
    {
        /*
        * 랜덤 모험 Map
        */

        // 운동 frame
        private int[] exerciseFrame;
        int exercisePosition;

        // 운동하는 모습 
        protected string[][] exercisingView = new string[][]
        {
            // 1. 아령을 드는 모습
            new string[]
            {
                "  |----|",
                "    |   ",
                "____|   ",
            },
            // 2. 운동 대성공
            new string[]
            {
                "  |----|",
                "    |   ",
                "_/\\_|   ",
            },
            // 3. 운동 실패
            new string[]
            {
                "   /----/",
                "         ",
                "     /   ",
                "____/    ",
            },
        };

        public TrainingMap() { }

        public override void DrawMap()
        {
            base.DrawMap();

            // Map 크기 초기화
            width = 30;
            height = 10;
            map = new char[height, width];

            // 운동 Frame 초기화
            int startY = height / 2;
            exerciseFrame = new int[] { startY+1, startY, startY-1 };
            exercisePosition = exerciseFrame[0];
        }

        // 운동 그리기
        public void DisplayMap(float elapsed, int eventOption)
        {
            elapsedSum += elapsed;

            if (elapsedSum >= 0.1f)
            {
                elapsedSum = 0f;
                frame++;
                ExercisingAnim(frame, eventOption);
            }
        }

        // 운동 애니메이션 연출
        private void ExercisingAnim(int frame, int eventOption)
        {
            // 운동 위치 X는 고정
            int exercisePosX = width / 2 - 5;

            // 아령 드는 모습을 바꿀 위치 : 대실패 시 애니메이션 멈추기
            exercisePosition = (eventOption == 2) ? exercisePosition : exerciseFrame[frame / 3 % exerciseFrame.Length];

            // SetCursorPosition을 이용하여 덮어쓰기를 하므로 한 라인 당 출력
            string drawLine = "";
            baseLine = 1;
            endLine = height + baseLine;

            InitializeMap();

            // 운동 모습 그리기 : event에 따라 모습 변환
            DrawExercise(exercisingView[eventOption], exercisePosX, exercisePosition - exercisingView[eventOption].Length / 2);

            for (int line = baseLine; line < endLine; line++)
            {
                drawLine = "";

                for (int x = 0; x < width; x++)
                    drawLine += map[line - baseLine, x];

                ConsoleHelper.WriteLine(drawLine, line);
            }
        }

        // 운동 모습 그리기
        private void DrawExercise(string[] exercise, int startX, int startY)
        {
            for (int y = 0; y < exercise.Length; y++)
            {
                for (int x = 0; x < exercise[y].Length; x++)
                {
                    // Start Position 위치 기준으로 사각형 그리기 (좌측 상단 꼭짓점에서 시작)
                    int posX = startX + x;
                    int posY = startY + y;

                    if (posX < width && posY < height)
                        map[posY, posX] = exercise[y][x];
                }
            }
        }
    }
}
