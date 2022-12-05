using System.Numerics;
using Raylib_cs;

namespace GlobalWar
{
    public struct Button
    {
        public Rectangle Rect;
        public Sprite Graphic;
        private string _label;

        public Button(string label, Sprite s, int x, int y, int w, int h)
        {
            _label = label;
            Graphic = s;
            Rect = new Rectangle(x, y, w, h);
        }

        public void Draw(Font font, int spacing)
        {
            var textColor = IInput.OnRollOverUI(Rect) ? Color.RED : Color.WHITE;
            Vector2 pos = new Vector2((int)Rect.x + (int)Rect.width / 2 - Raylib.MeasureText(_label, (int)Rect.height) / 2, (int)Rect.y);
            
            Graphic.Draw(Rect.x, Rect.y, false);
            Raylib.DrawTextEx(font, _label, pos, (int)Rect.height, spacing, textColor);
        }
    }
}