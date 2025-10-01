using System.Diagnostics;
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
     * GameManager:    게임 Scene을 관리할 클래스
     * UIManager:       게임 UI를 관리할 클래스
     * 
     */
    internal class GameMain
    {
        static bool isRunning;              // 게임 종료/실행 변수r
      
        static Scene currentScene;          // 현재 실행되고 있는 Scene

        static float elapsed;

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

            // 게임 매니저 초기화
            GameManager.Instance.InitGame();
        }

        static void Start()
        {
            // 현재 씬 Start()
            GameManager.Instance.CurrentScene.Start();
        }

        static void Update()
        {
            // 시간 경과 확인 할 수 있는 DataTime 구조체 생성
            DateTime prevTime = DateTime.Now;

            // 게임이 실행되는 동안 동작하는 부분
            while (isRunning)
            {
                // DeltaTime 계산 후 elapsed 반환
                DateTime now = DateTime.Now;
                TimeSpan delta = now - prevTime;
                prevTime = now;

                elapsed = (float)delta.TotalSeconds;

                // 현재 씬 Update()
                GameManager.Instance.CurrentScene.Update(elapsed);
            }
        }
    }
}
