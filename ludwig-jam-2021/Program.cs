using System;
using Raylib_cs;
using ludwig_jam_2021.Scenes;
using ludwig_jam_2021.Engine.Objects;

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
            Raylib.InitWindow(1920, 1080, "Beatmap Game");
            //Raylib.ToggleFullscreen();
            
            // Setup Audio
            Raylib.InitAudioDevice();

            // Load Fonts
            fonts = new Font[1];
            fonts[0] = Raylib.LoadFont("Assets/Fonts/ComicSans.ttf");

            // Setup the scene handler
            gameSceneHandler.ChangeScene(RenderingScenes.MainMenu);

            // Dev Thing
            Raylib.SetExitKey(KeyboardKey.KEY_Q);


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
