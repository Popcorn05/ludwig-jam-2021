using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using Raylib_cs;

using ludwig_jam_2021.UI;

namespace ludwig_jam_2021.Scenes
{

    class MainMenu
    {
        public static Music MainMenuMusic = Raylib.LoadMusicStream("Assets/Sound/MainMenu.mp3");

        // Run only once, before the gameloop
        public static void OnOpen()
        {
            Raylib.PlayMusicStream(MainMenuMusic);
            Raylib.SetMusicVolume(MainMenuMusic, 0.2f);
        }

        public static void Render()
        {
            // Screen Size
            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();

            // Rendering
            Raylib.ClearBackground(Color.WHITE);

            // FPS Rendering
            Helpers.FPSDisplay.Render();

            // Music
            Raylib.UpdateMusicStream(MainMenuMusic);

            MainMenu.RenderUI();
        }

        public static void RenderUI()
        {
            // Screen Size
            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();

            // Text
            String TitleText = "Beatmap Game";
            int TitleFont = screenWidth / 20;
            int TitleTextSize = Raylib.MeasureText(TitleText, TitleFont);
            Raylib.DrawText(TitleText, screenWidth / 2 - TitleTextSize / 2, screenHeight / 5, TitleFont, Color.RED);

            // Buttons
            Button PlayButton = new Button(screenWidth / 2, screenHeight / 2);
            PlayButton.SetPadding(screenWidth/20, screenWidth/40);
            PlayButton.SetText("Play", 100, Program.fonts[0]);
            PlayButton.SetBackground(Color.RED);
            PlayButton.SetOnHover(Hover);
            PlayButton.SetOnClick(Play);

            PlayButton.RenderCenter();

            Button QuitButton = new Button(screenWidth / 2, screenHeight / 2 + PlayButton.GetHeight() + 100);
            // Styling
            QuitButton.SetPadding(screenWidth/40, screenWidth/80);
            QuitButton.SetText("Quit", 50, Program.fonts[0]);
            QuitButton.SetBackground(Color.RED);

            // Events
            QuitButton.SetOnHover(Hover);
            QuitButton.SetOnClick(Quit);

            QuitButton.RenderCenter();

        }

        private static void Hover(Button button)
        {
            button.SetBackground(Color.BLUE);
        }

        public static void Play(Button button)
        {
            Program.gameSceneHandler.ChangeScene(RenderingScenes.Game);   
        }

        public static void Quit(Button button)
        {
            Environment.Exit(0);
        }
    }
}
