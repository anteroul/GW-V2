using System;
using System.Numerics;
using Raylib_cs;
using static GlobalWar.IInput;
using static Raylib_cs.Raylib;

namespace GlobalWar
{
    namespace Raylib_cs.Raylib
    {
        class Game
        {
            public enum GameState
            {
                MainMenu,
                Help,
                GameSetup,
                GameplayOne,
                GameplayTwo,
                GameOver,
                Victory
            }
            
            public Player Player; // holds player data

            // Window variables:
            private readonly Vector2 _screenRes;
            private bool _quit;
            // Sprites:
            private Sprite _panel;
            private Sprite _map;
            private Sprite _button;
            private Sprite _menuButton;
            // Buttons:
            private Button _playBtn;
            private Button _helpBtn;
            private Button _quitBtn;
            // Gameplay variables:
            private GameState _gameState;
            // Fonts:
            private Font _menuFont;
            // Sounds:
            private Sound _buttonPress;

            public Game(Vector2 screenRes, string title)
            {
                _quit = false;
                _gameState = GameState.MainMenu;
                _screenRes = screenRes;
                Console.WriteLine("Initializing window with a resolution of " + screenRes + "\n");
                InitWindow((int)screenRes.X, (int)screenRes.Y, title);
                SetTargetFPS(GetMonitorRefreshRate(GetCurrentMonitor()));
                InitAudioDevice();
            }

            public void RunGame()
            {
                // initialization of sprites:
                _panel = new Sprite("assets/sprites/panel1.png", 1);
                _map = new Sprite("assets/sprites/map1.png", 1);
                _button = new Sprite("assets/sprites/button7.png", 7);
                _menuButton = new Sprite("assets/sprites/menuButton1.png", 1);
                // initialization of buttons:
                _playBtn = new Button("PLAY", _menuButton, (int)_screenRes.X / 3, 100, 480, 140);
                _helpBtn = new Button("HELP", _menuButton, (int)_screenRes.X / 3, 300, 480, 140);
                _quitBtn = new Button("QUIT", _menuButton, (int)_screenRes.X / 3, 500, 480, 140);
                // fonts:
                _menuFont = LoadFont("assets/fonts/cold.otf");
                // sounds:
                _buttonPress = LoadSound("assets/sounds/button.wav");

                while (!WindowShouldClose() && !_quit)
                {
                    HandleCoreInput();
                    UpdateGame();
                    DrawGame();
                }

                // unloading:
                UnloadSound(_buttonPress);
                CloseAudioDevice();
                UnloadTexture(_menuButton.texture);
                UnloadTexture(_panel.texture);
                UnloadTexture(_map.texture);
                UnloadTexture(_button.texture);
                UnloadFont(_menuFont);
                CloseWindow();
            }

            void UpdateGame()
            {
                switch (_gameState)
                {
                    case GameState.MainMenu:
                        if (MenuButtonHit(_quitBtn)) _quit = true;
                        if (MenuButtonHit(_helpBtn)) _gameState = GameState.Help;
                        if (MenuButtonHit(_playBtn)) _gameState = GameState.GameSetup;
                        break;
                    case GameState.Help:
                        break;
                    case GameState.GameSetup:
                        break;
                    case GameState.GameOver:
                        break;
                    case GameState.GameplayOne:
                        break;
                    case GameState.GameplayTwo:
                        break;
                    case GameState.Victory:
                        break;
                }
            }

            void DrawGame()
            {
                // rendering happens here:
                BeginDrawing();
                ClearBackground(Color.DARKGRAY);
                
                _panel.Draw(0, 0, false);
                
                switch (_gameState)
                {
                    case GameState.MainMenu:
                        _playBtn.Draw(_menuFont, 6);
                        _helpBtn.Draw(_menuFont, 6);
                        _quitBtn.Draw(_menuFont, 6);
                        break;
                    case GameState.Help:
                        break;
                    case GameState.GameSetup:
                        break;
                    case GameState.GameOver:
                        break;
                    case GameState.GameplayOne:
                        break;
                    case GameState.GameplayTwo:
                        _map.Draw(0, 0, false);
                        break;
                    case GameState.Victory:
                        break;
                }
                
                DrawFPS((int)_screenRes.X / 32, (int)_screenRes.Y / 32);
                EndDrawing();
            }

            bool MenuButtonHit(Button button)
            {
                if (!OnClickUI(button.Rect)) return false;
                PlaySound(_buttonPress);
                return true;
            }
        }
    }
}
