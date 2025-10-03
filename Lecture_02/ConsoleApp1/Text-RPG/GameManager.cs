using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Scenes;

namespace Text_RPG
{
    internal class GameManager
    {
        /*
          * GameManager 스크립트
          * 
          * 게임 등장하는 모든 씬을 관리하며
          * 씬들이 공유하는 객체 정보를 관리한다
          * 
          * 관리하는 게임 씬으로는 다음과 같다.
          * 
          * MainScene:          게임 시작 시 나오는 메인 씬
          * StateScene:         플레이어 스탯 창 씬
          * InventoryScene:     플레이어 인벤토리 씬
          * AdventureScene:     퀘스트/스토리 진행 공간 (혹은 던전과 별개로 “탐험 이벤트” 진행)
          * TownScene:          마을 순찰 및 골드 흭득
          * TrainingScene:      캐릭터 능력 강화, 레벨업 관련 기능
          * ShopScene:          아이템 구매/판매
          * DungeonScene:       던전 탐험이 일어나는 공간
          * RestScene:          회복, 상태 이상 제거, 하루 마무리 같은 기능
          * 
          * 공유하는 객체 정보는 다음과 같다.
          * 
          * Player:             플레이어 정보 공유
          * 
          */
        // 싱글톤 패턴
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        // 공유 객체
        private Player player;

        // 현재 씬
        private Scene currentScene;

        // 씬 저장 리스트
        private List<Scene> sceneList;

        // 씬 Dictionary
        private Dictionary<string, int> sceneDictionary = new Dictionary<string, int>()
        {
            { "MainScene", 0 }, { "StateScene", 1 }, { "InventoryScene", 2 }, { "AdventureScene", 3 },
            { "TownScene", 4 }, { "TrainingScene", 5 }, { "ShopScene", 6 }, { "DungeonScene", 7 },
            { "RestScene", 8 },
        };

        // 현재 창 (시작창, 스탯창 등)
        protected Action<float> currentView;

        // 초기 씬 생성
        public void InitGame()
        {
            // 게임 오브젝트 생성
            player = new Player(1, "이의환", 10, 10, 100, "초보자", 0);

            // 씬 생성
            sceneList = new List<Scene>();

            Scene mainScene = new MainScene(sceneDictionary["MainScene"]);
            Scene stateScene = new StateScene(sceneDictionary["StateScene"]);
            Scene inventoryScene = new InventroyScene(sceneDictionary["InventoryScene"]);
            Scene adventureScene = new AdventureScene(sceneDictionary["AdventureScene"]);
            Scene townScene = new TownScene(sceneDictionary["TownScene"]);
            
            sceneList.Add(mainScene);
            sceneList.Add(stateScene);
            sceneList.Add(inventoryScene); 
            sceneList.Add(adventureScene);
            sceneList.Add(townScene);

            // 처음 씬 지정
            currentScene = mainScene;
        }

        // 씬 이동 : idx로 탐색
        public void LoadScene(int idx)
        {
            if (idx > sceneList.Count && idx < 0) return;

            Console.Clear();
            currentScene = sceneList[idx];
            currentScene.Init();
        }

        // 씬 이동 : 이름으로 탐색
        public void LoadScene(string name)
        {
            // Dictionary에 씬 이름이 존재하는지 확인
            if (sceneDictionary.Keys.Contains(name)==false) return;

            Console.Clear();
            currentScene = sceneList[sceneDictionary[name]];
            currentScene.Init();
        }

        // 프러퍼티
        public Scene CurrentScene { get { return currentScene; } }
        public Player GetPlayer() { return player; }
    }
}
