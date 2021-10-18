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
        public static void Render()
        {
            // Screen Size
            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();

            // Rendering
            Raylib.ClearBackground(Color.WHITE);

            MainMenu.RenderUI();
        }

        public static void RenderUI()
        {
            // Screen Size
            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();

            // Text
            String TitleText = "Game Name";
            int TitleFont = screenWidth / 20;
            int TitleTextSize = Raylib.MeasureText(TitleText, TitleFont);
            Raylib.DrawText("Game Name", screenWidth / 2 - TitleTextSize / 2, screenHeight / 4, TitleFont, Color.RED);

            // Buttons
            Button PlayButton = new Button(screenWidth / 2, screenHeight / 2);
            PlayButton.SetPadding(200, 100);
            PlayButton.SetText("Play", 100);
            PlayButton.SetBackground(Color.RED);
            PlayButton.SetOnHover(Hover);

            PlayButton.RenderCenter();

            Button QuitButton = new Button(screenWidth / 2, screenHeight / 2 + PlayButton.GetHeight() + 100);
            // Styling
            QuitButton.SetPadding(100, 50);
            QuitButton.SetText("Quit", 40);
            QuitButton.SetBackground(Color.RED);
            QuitButton.SetTextHeight(40);
            // Events
            QuitButton.SetOnHover(Hover);
            QuitButton.SetOnClick(Quit);

            QuitButton.RenderCenter();

        }

        private static void Hover(Button button)
        {
            button.SetBackground(Color.BLUE);
        }

        public static void Quit(Button button)
        {
            Environment.Exit(0);
        }
    }
}
