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
            private Sprite[] _leaders;
            // Buttons:
            private Button _playBtn;
            private Button _helpBtn;
            private Button _quitBtn;
            private Button _backBtn;
            private LeaderButton[] _leaderBtn;
            // Gameplay variables:
            private GameState _gameState;
            private Opponent[] _opponents;
            private int _leaderIndex;
            // Fonts:
            private Font _menuFont;
            // Sounds:
            private Sound _buttonPress;

            public Game(Vector2 screenRes, string title)
            {
                _quit = false;
                _gameState = GameState.MainMenu;
                _screenRes = screenRes;
                _leaders = new Sprite[13];
                _leaderBtn = new LeaderButton[13];
                _opponents = new Opponent[5];
                _leaderIndex = 0;
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

                _leaders[0] = new Sprite("assets/sprites/leaders/erdogan1.png", 1);
                _leaders[1] = new Sprite("assets/sprites/leaders/herzog1.png", 1);
                _leaders[2] = new Sprite("assets/sprites/leaders/biden1.png", 1);
                _leaders[3] = new Sprite("assets/sprites/leaders/boris1.png", 1);
                _leaders[4] = new Sprite("assets/sprites/leaders/assad1.png", 1);
                _leaders[5] = new Sprite("assets/sprites/leaders/kimjong1.png", 1);
                _leaders[6] = new Sprite("assets/sprites/leaders/kishida1.png", 1);
                _leaders[7] = new Sprite("assets/sprites/leaders/macron1.png", 1);
                _leaders[8] = new Sprite("assets/sprites/leaders/sanna1.png", 1);
                _leaders[9] = new Sprite("assets/sprites/leaders/xi1.png", 1);
                _leaders[10] = new Sprite("assets/sprites/leaders/zelensky1.png", 1);
                _leaders[11] = new Sprite("assets/sprites/leaders/putin1.png", 1);
                _leaders[12] = new Sprite("assets/sprites/leaders/raisi1.png", 1);
                
                
                // initialization of buttons:

                for (var i = 0; i < 13; i++)
                {
                    _leaderBtn[i] = new LeaderButton(i, _leaders[i], GetScreenWidth() / 13 * i.GetHashCode(),
                        GetScreenHeight() / 2, _leaders[i].texture.width, _leaders[i].texture.height);
                }
                
                _playBtn = new Button("PLAY", _menuButton, (int)_screenRes.X / 2, 400, 120, 32);
                _helpBtn = new Button("HELP", _menuButton, (int)_screenRes.X / 2, 500, 120, 32);
                _quitBtn = new Button("QUIT", _menuButton, (int)_screenRes.X / 2, 600, 120, 32);
                _backBtn = new Button("BACK", _menuButton, (int)_screenRes.X / 2, 600, 120, 32);
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
                foreach (var i in _leaders)
                {
                    UnloadTexture(i.texture);
                }
                
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
                        if (MenuButtonHit(_backBtn)) _gameState = GameState.MainMenu;
                        break;
                    case GameState.GameSetup:
                        foreach (var i in _leaderBtn)
                        {
                            if (_leaderIndex < 4)
                                _leaderIndex = i.SetEnemy(_opponents[_leaderIndex], _leaderIndex, _buttonPress);
                        }
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
                        _backBtn.Draw(_menuFont, 6);
                        break;
                    case GameState.GameSetup:
                        
                        foreach (var i in _leaderBtn)
                        {
                            if (i.IsVisible())
                            {
                                i.Btn.Draw(_menuFont, 1);
                            }
                            if (OnRollOverUI(i.Btn.Rect))
                            {
                                DrawText(i.GetLeaderName(),
                                    GetScreenWidth() / 2 - MeasureText(i.GetLeaderName(), 32) / 2,
                                    GetScreenHeight() / 5 * 4, 32, Color.RED);
                            }
                        }

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
