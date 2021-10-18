using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

namespace ludwig_jam_2021.Helpers
{
    class FPSDisplay
    {
        public static void Render()
        {
            if(!Raylib.WindowShouldClose())
            {
                Raylib.DrawText("FPS: " + Raylib.GetFPS().ToString(), 100, 100, 30, Color.RED);
            }
        }
    }
}
