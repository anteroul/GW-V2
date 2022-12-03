using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
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
            Sprite _button;
            public Game(Vector2 screenRes, string title)
            {
                _screenRes = screenRes;
                Console.WriteLine("Initializing window with a resolution of " + screenRes + "\n");
                InitWindow((int)screenRes.X, (int)screenRes.Y, title);
                SetTargetFPS(GetMonitorRefreshRate(GetCurrentMonitor()));
            }

            public void RunGame()
            {
                LoadAssets();

                while (!WindowShouldClose())
                {
                    HandleCoreInput();
                    DrawGame();
                }
                CloseWindow();
            }

            void DrawGame()
            {
                BeginDrawing();
                ClearBackground(Color.DARKGRAY);
                DrawFPS((int)_screenRes.X / 32, (int)_screenRes.Y / 32);
                _button.Draw(GetScreenWidth() / 2, GetScreenHeight() / 2, false);
                EndDrawing();
            }

            void LoadAssets()
            {
                _button = new Sprite("assets/sprites/button7.png", 7);
            }
        }
    }
}
