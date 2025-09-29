using static System.Formats.Asn1.AsnWriter;

namespace Text_RPG
{
    internal class GameMain
    {
        static bool isRunning;

        static Scene currentScene;
        static Scene scene01;
        static UIManager uiManager;

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

            // UI, Scene 오브젝트 생성
            uiManager = new UIManager();
            scene01 = new StartScene(0, uiManager);

            // 현재 씬 지정
            currentScene = scene01;
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
