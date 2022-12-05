using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using static GlobalWar.IInput;
using static Raylib_cs.Raylib;

namespace GlobalWar
{
    namespace Raylib_cs.Raylib
    {
        class Game
        {
            Vector2 _screenRes;
            Sprite _map;
            Sprite _button;
            Player _player;

            public Game(Vector2 screenRes, string title)
            {
                _screenRes = screenRes;
                Console.WriteLine("Initializing window with a resolution of " + screenRes + "\n");
                InitWindow((int)screenRes.X, (int)screenRes.Y, title);
                SetTargetFPS(GetMonitorRefreshRate(GetCurrentMonitor()));
            }

            public void RunGame()
            {
                _map = new Sprite("assets/sprites/map1.png", 1);
                _button = new Sprite("assets/sprites/button7.png", 7);

                while (!WindowShouldClose())
                {
                    HandleCoreInput();
                    DrawGame();
                }

                UnloadTexture(_map.texture);
                UnloadTexture(_button.texture);
                CloseWindow();
            }

            void DrawGame()
            {
                BeginDrawing();
                ClearBackground(Color.DARKGRAY);
                _map.Draw(0, 0, false);
                //_button.Draw(GetScreenWidth() / 2, GetScreenHeight() / 2, false);
                DrawFPS((int)_screenRes.X / 32, (int)_screenRes.Y / 32);
                EndDrawing();
            }
        }
    }
}
