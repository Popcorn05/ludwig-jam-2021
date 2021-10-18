using System;
using Raylib_cs;
using ludwig_jam_2021.Engine.Objects;

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

            Platform test = new Platform(50f, 50f);

            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Raylib.DrawText("Hello World", 12, 12, 20, Color.WHITE);
                test.Render();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
