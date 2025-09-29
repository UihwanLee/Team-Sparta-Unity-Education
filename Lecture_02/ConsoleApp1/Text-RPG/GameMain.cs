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
            isRunning = true;

            uiManager = new UIManager();
            scene01 = new StartScene(0, uiManager);

            currentScene = scene01;
        }

        static void Start()
        {
            currentScene.Start();
        }

        static void Update()
        {
            // 게임이 실행되는 동안 동작하는 부분
            while (isRunning)
            {
                currentScene.Update();
            }
        }
    }
}
