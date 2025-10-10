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

        // 마을 Map
        private int townWidth = 20;
        private int townHeight = 6;
        private char[,] townMap;

        // 던전 입장 Map
        private int dungeonWidth = 30;
        private int dungeonHeight = 10;
        private char[,] dungeonMap;

        // background : 모험, 마을 순찰
        private int adventureWidth = 20;
        private int adventureHeight = 6;
        private List<string> adventureBG = new List<string>();
        private List<string> patrolTownBG = new List<string>();

        // 애니메이션 연출을 위한 elapsed 합계
        private float elapsedSum = 0;

        // 애니메이션 시 Player frame
        private string[] playerFrames = { "(P)", "(p)" };
        private int frame = 0;

        // 건물 유형
        string[][] buildings = new string[][]
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

        public MapManager() 
        {
            DrawMap();
        }

        // Map 생성 및 초기화
        private void DrawMap()
        {
            DrawTownMap();
            DrawDungeon();
            DrawAdventureBG();
        }

        // 마을 맵 초기화
        private void DrawTownMap()
        {
            townMap = new char[townHeight, townWidth];

            InitializeMap(townMap);

            // 건물 그리기 : 중간 점 기준으로 나뉘어 2개 배치
            int buildingWitdh = (townWidth / 2);
            int buildingHeight = (townHeight / 2);

            DrawBuilding(buildingWitdh - 6, buildingHeight - 2);
            DrawBuilding(buildingWitdh, buildingHeight - 2);
        }

        // 건물 그리기
        private void DrawBuilding(int startX, int startY)
        {
            string[] building = buildings[1];

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

        // 마을 맵 그리기
        public void DisplayTown()
        {
            DisplayMap(townMap);
        }

        // 던전 입장 Map 초기화
        private void DrawDungeon()
        {
            dungeonMap = new char[dungeonHeight, dungeonWidth];

            InitializeMap(dungeonMap);

            // 던전 입구 그리기 : 쉬운 던전, 노말 던전, 어려운 던전
            int entranceWitdh = (dungeonWidth / 2);
            int entranceHeight = (dungeonHeight / 2);

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

                    if (posX < dungeonWidth && posY < dungeonHeight)
                        dungeonMap[posY, posX] = building[y][x];
                }
            }
        }

        // 던전 맵 그리기
        public void DisplayDungeon()
        {
            DisplayMap(dungeonMap);
        }

        // Map 초기화
        public void InitializeMap(char[,] map)
        {
            int height = map.GetLength(0);
            int width = map.GetLength(1);

            // 빈 여백으로 채우기
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    map[y, x] = ' ';

            // 벽 그리기 : 가로
            for (int x = 0; x < width; x++)
            {
                map[0, x] = (x == 0 || x == width - 1) ? '+' : '-';
                map[height - 1, x] = (x == 0 || x == width - 1) ? '+' : '-';
            }

            // 벽 그리기 : 세로
            for (int y = 0; y < height; y++)
            {
                map[y, 0] = '|';
                map[y, width - 1] = '|';
            }
        }

        // 맵 표시
        public void DisplayMap(char[,] map)
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

        /////////////////////////////////////////////////////////////////////

        // 랜덤 모험 background 초기화
        private void DrawAdventureBG()
        {
            Random rnd = new Random();

            // 듬성 듬성 나무가 있는 걸로 연출
            for(int i=0; i<200; i++)
            {
                string isTree = (rnd.NextDouble() < 0.3) ? "|" : " ";
                adventureBG.Add(isTree);
            }
        }

        // 랜덤 모험 애니메이션 연출
        public void DisplayAdventure(float elapsed)
        {
            elapsedSum += elapsed;

            if(elapsedSum >= 0.1f)
            {
                elapsedSum = 0f;
                frame++;
                AdventureAnim(frame);
            }
        }

        private void AdventureAnim(int frame)
        {
            int midY = adventureHeight / 2;

            // 애니메이션 연출을 위한 frame 단위 작업
            int startBGIdx = frame % adventureBG.Count; // 리스트 다 돌면 다시 루프 진행
            string player = playerFrames[(frame / 3) % playerFrames.Length]; // 0.3 간격으로 표시

            // Player는 항상 맵 가운데 배치
            int playerPosX = adventureWidth / 2 - 1;

            // SetCursorPosition을 이용하여 덮어쓰기를 하므로 한 라인 당 출력
            string drawLine = "";
            int baseLine = 1;
            int endLine = adventureHeight + baseLine;

            for (int line= baseLine; line < endLine; line++)
            {
                drawLine = "";

                if(line == midY - 2 || line == midY + 2)
                {
                    // 맨 윗 줄과 아랫 줄은 나무 표시
                    for (int x = 0; x < adventureWidth; x++)
                        drawLine += adventureBG[(startBGIdx + x) % adventureBG.Count];
                }
                else if(line == midY)
                {
                    // 중간 줄에는 Player 표시
                    for(int x=0; x< adventureWidth; x++)
                    {
                        if (x == playerPosX)
                        {
                            drawLine += player;
                            x += 2;     // Player는 '(', 'P', ')' 3가지 char로 이루어져있으므로 2개 띄어넘기
                        }
                        else drawLine += " ";   // 나머지는 공백
                    }
                }
                else
                {
                    drawLine = new string(' ', adventureWidth);
                }

                ConsoleHelper.WriteLine(drawLine, line);
            }
        }
    }
}
