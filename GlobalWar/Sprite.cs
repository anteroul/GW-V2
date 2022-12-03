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
            cFrame = 0;
        }

        ~Sprite()
        {
            Raylib.UnloadTexture(texture);
        }

        public void Draw(float x, float y, bool looping)
        {
            if (looping)
            {
                if (cFrame > frames) cFrame = 0;
            }
            else
            {
                if (cFrame > frames) cFrame = frames;
            }

            Vector2 pos = new Vector2(x, y);
            rec.x = cFrame * (texture.width / frames);
            Raylib.DrawTextureRec(texture, rec, pos, Color.RAYWHITE);

            cFrame++;
        }
    }
}
