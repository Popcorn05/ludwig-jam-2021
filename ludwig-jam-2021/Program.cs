using System;
using Raylib_cs;

using ludwig_jam_2021.Helpers;

namespace ludwig_jam_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            
            int display = Raylib.GetCurrentMonitor();
            Raylib.InitWindow(Raylib.GetMonitorHeight(display), Raylib.GetMonitorWidth(display), "Beatmap Game");
            Raylib.ToggleFullscreen();
            

            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                LoadingScreen.Render();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
