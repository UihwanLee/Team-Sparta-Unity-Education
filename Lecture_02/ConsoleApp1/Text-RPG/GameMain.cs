using Text_RPG.Scenes;
using static System.Formats.Asn1.AsnWriter;

namespace Text_RPG
{
    /*
     * Text_RPG Main 스크립트
     * 
     * 게임 시작 시 Main을 담당하고 있으며
     * 다양한 Manager 클래스들을 가지고 있다.
     * 
     * SceneManager:    게임 Scene을 관리할 클래스
     * UIManager:       게임 UI를 관리할 클래스
     * 
     */
    internal class GameMain
    {
        static bool isRunning;              // 게임 종료/실행 변수r
      
        static Scene currentScene;          // 현재 실행되고 있는 Scene

        static void Main(string[] args)
        {
            Init();
            Start();
            Update();
        }

        static void Init()
        {
            // 게임 실행
            isRunning = true;

            // 현재 씬 지정
            SceneManager.Instance.InitScene();
            currentScene = SceneManager.Instance.LoadScene("MainScene");
        }

        static void Start()
        {
            // 현재 씬 Start()
            currentScene.Start();
        }

        static void Update()
        {
            // 게임이 실행되는 동안 동작하는 부분
            while (isRunning)
            {
                // 현재 씬 Update()
                currentScene.Update();
            }
        }
    }
}
