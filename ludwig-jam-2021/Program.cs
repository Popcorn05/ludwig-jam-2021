using System;
using Raylib_cs;

using ludwig_jam_2021.Scenes;

namespace ludwig_jam_2021
{
    class Program
    {
        public static SceneHandler gameSceneHandler = new SceneHandler();
        public static Font[] fonts;


        static void Main(string[] args)
        {
            // Config Flags
            Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            
            // Setup the Window
            int display = Raylib.GetCurrentMonitor();
            Raylib.InitWindow(Raylib.GetMonitorHeight(display), Raylib.GetMonitorWidth(display), "Beatmap Game");

            // Load Fonts
            fonts = new Font[1];
            fonts[0] = Raylib.LoadFont("Assets/Fonts/PixAntiqua.ttf");

            // Dev Thing
            Raylib.SetExitKey(KeyboardKey.KEY_Q);

            gameSceneHandler.ChangeScene(RenderingScenes.MainMenu);

            // Main Game Loop
            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                gameSceneHandler.RenderScene();

                Raylib.EndDrawing();
            }

            Raylib.UnloadFont(fonts[0]);

            Raylib.CloseWindow();
        }
    }
}
