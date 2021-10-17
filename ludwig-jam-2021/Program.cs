using System;
using Raylib_cs;

using ludwig_jam_2021.Scenes;

namespace ludwig_jam_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            // Config Flags
            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            
            // Setup the Window
            int display = Raylib.GetCurrentMonitor();
            Raylib.InitWindow(Raylib.GetMonitorHeight(display), Raylib.GetMonitorWidth(display), "Beatmap Game");

            Raylib.SetExitKey(KeyboardKey.KEY_Q);

            //Raylib.ToggleFullscreen();
            
            // Main Game Loop
            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                MainMenu.Render();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
