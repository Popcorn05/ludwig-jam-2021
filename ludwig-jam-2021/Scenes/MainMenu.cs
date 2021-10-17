using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

using Raylib_cs;

struct Button
{
    public String text;
    public Color background;
    public Func<int> onClick;

    public Button(String text, Color background, Func<int> onClick)
    {
        this.text = text;
        this.background = background;
        this.onClick = onClick;
    }
}

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

            // Title Text
            int titleTextSize = screenWidth/30;
            String titleText = "Game Name";
            int titleTextWidth = Raylib.MeasureText(titleText, titleTextSize);

            Raylib.DrawText(titleText, screenWidth / 2 - titleTextWidth/2, 300, titleTextSize, Color.RED);
        }

        public static int Quit()
        {
            return 0;
        }
    }
}
