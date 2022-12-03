using Raylib_cs;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace GlobalWar
{
    class Sprite
    {
        Texture2D texture;
        Rectangle rec;
        int frames;
        int cFrame;

        public Sprite(string path, int frameCount)
        {
            texture = Raylib.LoadTexture(path);
            frames = frameCount;
            rec = new Rectangle(0, 0, texture.width / frameCount, texture.height);
            cFrame = 1;
        }

        public void Draw(float x, float y)
        {
            if (cFrame > frames) cFrame = 1;
            Vector2 pos = new Vector2(x, y);
            rec.x = cFrame * (texture.width / frames);
            Raylib.DrawTextureRec(texture, rec, pos, Color.RAYWHITE);
            cFrame++;
        }
    }
}
