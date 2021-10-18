using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

namespace ludwig_jam_2021.Scenes
{
    class Game
    {
        public static void Render()
        {
            Raylib.ClearBackground(Color.BLUE);
            Raylib.DrawText("Game Scene", 100, 100, 100, Color.RED);
        }
    }
}
