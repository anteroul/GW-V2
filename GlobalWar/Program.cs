using System;
using System.Numerics;

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

                Game game = new Game(_screenRes, GameTitle);
                game.RunGame();
            }
        }
    }
}