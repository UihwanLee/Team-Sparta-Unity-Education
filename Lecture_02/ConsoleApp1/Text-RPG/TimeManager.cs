using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class TimeManager
    {
        /*
          * TImeManager 스크립트
          * 
          * 게임에서 시간 관련된 변수를 제어하는 스크립트이다.
          * 
          * 경과 시간과 DeltaTime을 관리한다.
          * 
          */
        public static TimeManager instance;

        public static TimeManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new TimeManager();
                }
                return instance;
            }
        }

        private DateTime startTime;
        private DateTime lastTime;

        private float elapsed = 0f;             // 시간 경과 시간 (전체 시간)
        private float deltaTime = 0f;           // 시간 deltaTime
        private float localElapsed = 0f;        // 전체가 아닌 부분 경과 시간 변수

        public void InitTime()
        {
            // 시간 경과 확인 할 수 있는 DataTime 구조체 생성
            startTime = DateTime.Now;
            lastTime = startTime; // 이전 프레임 시간
        }

        public void InitLocalElapsed()
        {
            // 로컬 경과 시간 초기화
            localElapsed = 0f;
        }

        public void UpdateTime()
        {
            DateTime now = DateTime.Now;

            // DeltaTime 계산
            TimeSpan deltaSpan = now - lastTime;
            float deltaTime = (float)deltaSpan.TotalSeconds;

            // DeltaTime 계산 후 elapsed 반환
            TimeSpan timeSpan = DateTime.Now - startTime;

            // 초 단위(float 형태로)
            float elapsed = (float)timeSpan.TotalSeconds;

            lastTime = now;

            // 업데이트
            this.deltaTime = deltaTime;
            this.elapsed = elapsed;
        }

        // 프로퍼티
        public float DeltaTime { get { return deltaTime; } }
        public float Elapsed { get { return elapsed; } }
        public float LocalElapsed { get { return localElapsed; } set { localElapsed = value; } }
    }
}
