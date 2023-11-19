using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Ui;
using TextRPG.Util;

namespace TextRPG.GameEngine
{
    public class Engine
    {
        private InputHandler _inputHandler;


        public bool IsRunning { get; private set; }

        public Engine()
        {
            _inputHandler = new InputHandler();
            IsRunning = true;
        }

        public void Start()
        {
            Init();
            GameLoop();
        }

        private void Init()
        {
            // 초기화 로직
            // 예: 게임 환경 설정, 필요한 리소스 로드 등
            GameStartUI.StartMenuDisplay(_inputHandler);
        }

        private void GameLoop()
        {
            while (IsRunning)
            {
                Update();
                Render();
            }
        }

        private void Update()
        {
            // 업데이트 로직
            // 예: 플레이어 입력 처리, 게임 상태 업데이트 등
        }

        private void Render()
        {
            // 렌더링 로직
            // 예: 사용자 인터페이스 갱신, 게임 화면 출력 등
        }

        public void Exit()
        {
            IsRunning = false;
        }
    }
}
