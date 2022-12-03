using System;
using System.Numerics;
using Raylib_cs;
using static GlobalWar.IInput;
using static Raylib_cs.Raylib;

namespace GlobalWar
{
    namespace Raylib_cs.Raylib
    {
        static class Program
        {
            static Vector2 _screenRes = new Vector2(1280, 720);
            const string GameTitle = "Global Conflict: Armageddon";

            static void Main(string[] args)
            {
                Console.WriteLine("args:" + args);
                Console.WriteLine("64-bit application: " + Environment.Is64BitProcess);
                Console.WriteLine("Platform: " + Environment.OSVersion);
                Console.WriteLine("CPU core count: " + Environment.ProcessorCount);
                Console.WriteLine("Initializing window with a resolution of " + _screenRes + "\n");

                InitWindow((int)_screenRes.X, (int)_screenRes.Y, GameTitle);
                SetTargetFPS(GetMonitorRefreshRate(GetCurrentMonitor()));

                while (!WindowShouldClose())
                {
                    HandleCoreInput();
                    DrawGame();
                }
                CloseWindow();
            }

            static void DrawGame()
            {
                BeginDrawing();
                ClearBackground(Color.DARKGRAY);
                DrawFPS((int)_screenRes.X / 32, (int)_screenRes.Y / 32);
                EndDrawing();
            }
        }
    }
}