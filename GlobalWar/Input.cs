using System;
using Raylib_cs;

namespace GlobalWar
{
    public interface IInput
    {
        public static void HandleCoreInput()
        {
            var keyPress = Raylib.GetCharPressed();

            if (keyPress != 0)
                Console.WriteLine(char.ConvertFromUtf32(keyPress));

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
                Raylib.ToggleFullscreen();
        }

        public static bool OnRollOverUI(Rectangle button)
        {
            return Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button);
        }

        public static bool OnClickUI(Rectangle button)
        {
            if (Raylib.IsMouseButtonPressed(0) && OnRollOverUI(button))
            {
                return Raylib.IsMouseButtonReleased(0) && OnRollOverUI(button);
            }
            return false;
        }
    }
}