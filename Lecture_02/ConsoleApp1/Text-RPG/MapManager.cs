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

        // background : 모험
        private int adventureWidth = 30;
        private int adventureHeight = 10;
        private List<string> adventureBG = new List<string>();

        private string monster = "(M)";

        // background : 마을 순찰
        private int patrolTownWidth = 30;
        private int patrolTownHeight = 10;
        private List<string> patrolTownBG = new List<string>();

        // Player가 Patrol하는 방향
        // Player는 작은 사각형 영역 안에서 루프를 돌며 돌아다님

        private int moveDirection = 1;          // 1: 오른쪽, 2: 아래, 3: 왼쪽, 4: 위

        private int patrolRectWidth = 15;        // 움직이는 영역 Width
        private int patrolRectHeight = 7;       // 움직이는 영역 Height

        private int playerPatrolPosX = 0;       // Player Patrol X 위치
        private int playerPatrolPosY = 0;       // Player Patrol Y 위치

        private string[] patrolEvent = { "(CH)", "(HD)", "(P1)", "(VL)" };

        // 애니메이션 연출을 위한 변수
        private int startBGFrameIdx = 0;
        private float elapsedSum = 0;

        // 애니메이션 시 Player frame
        private string[] playerFrames = { "(P)", "(p)" };
        private int frame = 0;

        // ConsoleHelper Line
        public int baseLine = 0;
        public int endLine = 0;

        Random radom = new Random();

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
            // 듬성 듬성 나무가 있는 걸로 연출
            for(int i=0; i<200; i++)
            {
                string isTree = (radom.NextDouble() < 0.3) ? "|" : " ";
                adventureBG.Add(isTree);
            }
        }

        // 랜덤 모험 Map 그리기
        public void DisplayAdventure(float elapsed, bool isFindMonster)
        {
            elapsedSum += elapsed;

            if(elapsedSum >= 0.1f)
            {
                elapsedSum = 0f;
                frame++;
                AdventureAnim(frame, isFindMonster);
            }
        }

        // 랜덤 모험 애니메이션 연출
        private void AdventureAnim(int frame, bool isFindMonster)
        {
            int midY = adventureHeight / 2;

            // BG frame 단위 작업 : 몬스터 조우 시 배경 멈춤
            startBGFrameIdx = (isFindMonster) ? startBGFrameIdx : frame % adventureBG.Count; // 리스트 다 돌면 다시 루프 진행

            // Player frame 작업
            string player = playerFrames[(frame / 3) % playerFrames.Length]; // 0.3 간격으로 표시

            // Player는 항상 맵 가운데 배치
            int playerPosX = adventureWidth / 2 - 1;

            // SetCursorPosition을 이용하여 덮어쓰기를 하므로 한 라인 당 출력
            string drawLine = "";
            baseLine = 1;
            endLine = adventureHeight + baseLine;

            for (int line= baseLine; line < endLine; line++)
            {
                drawLine = "";

                if(line == baseLine || line == endLine - 1)
                {
                    // 맨 윗 줄과 아랫 줄은 나무 표시
                    for (int x = 0; x < adventureWidth; x++)
                        drawLine += adventureBG[(startBGFrameIdx + x) % adventureBG.Count];
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
                    drawLine = new string(' ', adventureWidth);
                }

                ConsoleHelper.WriteLine(drawLine, line);
            }
        }

        /////////////////////////////////////////////////////////////////////

        // 마을 순찰 그리기
        public void DisplayPatrolTown(float elapsed, int eventOption)
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
            int midX = patrolTownWidth / 2;
            int midY = patrolTownHeight / 2;

            // Player frame 작업
            string player = playerFrames[(frame / 3) % playerFrames.Length]; // 0.3 간격으로 표시

            // Player Patrol : Event 조우 시 Patrol 멈춤
            if(eventOption==-1) SetPlayerPatrol(player);

            // SetCursorPosition을 이용하여 덮어쓰기를 하므로 한 라인 당 출력
            string drawLine = "";
            baseLine = 1;
            endLine = patrolTownHeight + baseLine;

            for (int line = baseLine; line < endLine; line++)
            {
                drawLine = "";

                if (line == baseLine || line == endLine - 1)
                {
                    // 맨 윗 줄과 아랫 줄은 벽 표시
                    for (int x = 0; x < patrolTownWidth; x++)
                    {
                        string wall = (x==0 || x==patrolTownWidth-1) ? "+" : "-";
                        drawLine += wall;
                    }
                }
                else
                {
                    for (int x = 0; x < patrolTownWidth; x++)
                    {
                        // Player 중앙 배치
                        int startX = (patrolTownWidth - patrolRectWidth) / 2;
                        int startY = (patrolTownHeight - patrolRectHeight) / 2;

                        int playerPosX = playerPatrolPosX + startX;
                        int playerPosY = playerPatrolPosY + startY;

                        if (x==0 || x==patrolTownWidth - 1)
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
                            if(eventOption!=-1)
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
