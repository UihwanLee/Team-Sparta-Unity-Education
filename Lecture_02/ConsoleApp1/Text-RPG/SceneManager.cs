using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Scenes;

/*
  * SceneManager 스크립트
  * 
  * 게임 등장하는 모든 씬을 관리하며
  * 관리하는 게임 씬으로는 다음과 같다.
  * 
  * MainScene:          게임 시작 시 나오는 메인 씬
  * AdventureScene:     퀘스트/스토리 진행 공간 (혹은 던전과 별개로 “탐험 이벤트” 진행)
  * TownScene:          마을 순찰 및 골드 흭득
  * TrainingScene:      캐릭터 능력 강화, 레벨업 관련 기능
  * ShopScene:          아이템 구매/판매
  * DungeonScene:       던전 탐험이 일어나는 공간
  * RestScene:          회복, 상태 이상 제거, 하루 마무리 같은 기능
  * 
  */
namespace Text_RPG
{
    internal class SceneManager
    {
        // 싱글톤 패턴
        private static SceneManager instance;

        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SceneManager();
                }
                return instance;
            }
        }

        // 현재 씬
        private Scene currentScene;

        // 씬 저장 리스트
        private List<Scene> sceneList;

        // 씬 Dictionary
        private Dictionary<string, int> sceneDictionary = new Dictionary<string, int>()
        {
            { "MainScene", 0 }, { "AdventureScene", 1 },
        };

        // 초기 씬 생성
        public void InitScene()
        {
            sceneList = new List<Scene>();

            Scene mainScene = new MainScene(sceneDictionary["MainScene"]);
            
            sceneList.Add(mainScene);
        }

        // 씬 이동 : idx로 탐색
        public Scene LoadScene(int idx)
        {
            if (idx > sceneList.Count && idx < 0) return null;

            currentScene = sceneList[idx];
            return currentScene;
        }

        // 씬 이동 : 이름으로 탐색
        public Scene LoadScene(string name)
        {
            // Dictionary에 씬 이름이 존재하는지 확인
            if (sceneDictionary.Keys.Contains(name)==false) return null;

            currentScene = sceneList[sceneDictionary[name]];
            return currentScene;
        }
    }
}
