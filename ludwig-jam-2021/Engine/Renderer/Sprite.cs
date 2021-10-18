using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace ludwig_jam_2021.Engine.Renderer
{
    //Sprite class acts for running animations and loading and unloading from VRAM
    class Sprite
    {
        //Holds frame data, if single frame length of 1
        private Texture2D[] frames;

        //Constructor, takes paths and animated bool and loads textures into VRAM
        public Sprite(string[] paths, bool animated)
        {
            if (!animated)
            {
                Image image = Raylib.LoadImage(paths[0]);
                frames = new Texture2D[] {Raylib.LoadTextureFromImage(image)};
                Raylib.UnloadImage(image);
            } else
            {
                frames = new Texture2D[paths.Length];
                for (int i = 0; i < paths.Length; i++)
                {
                    Image image = Raylib.LoadImage(paths[i]);
                    frames[i] = Raylib.LoadTextureFromImage(image);
                    Raylib.UnloadImage(image);
                }
            }
        }

        //Deconstructor, makes sure to unload textures from VRAM
        ~Sprite() 
        {
            for (int i = 0; i < frames.Length; i++)
            {
                Raylib.UnloadTexture(frames[i]);
            }
        }

        //Draw method, draws to the screen
        public void Draw(int x, int y)
        {
            Raylib.DrawTexture(frames[0],x,y, Color.WHITE);
        }
    }
}
