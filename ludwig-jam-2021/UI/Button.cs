using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

using Raylib_cs;

namespace ludwig_jam_2021.UI
{

    class Button
    {
        const int TEXT_SPACING = 1;

        private int x;
        private int y;

        private int padding_x;
        private int padding_y;

        private string text;
        private int text_size;
        private int text_height;

        private Color color_bg;

        private Font font;

        // Events
        private Action<Button> onClick;

        private Action<Button> onHover;

        public Button(int x, int y)
        {
            this.x = x;
            this.y = y;

            this.text = "";
            this.text_size = 0;
            this.text_height = 100;
            this.padding_x = 0;
            this.padding_y = 0;
        }

        public int GetHeight()
        {
            return 100 + padding_y;
        }

        public void SetText(String text_content, int font_size, Font font)
        {
            this.text = text_content;
            this.text_size = font_size;
            this.font = font;
        }

        public void SetPadding(int x, int y)
        {
            this.padding_x = x;
            this.padding_y = y;
        }

        public void SetBackground(Color bg_color)
        {
            this.color_bg = bg_color;
        }

        public void SetOnHover(Action<Button> action)
        {
            this.onHover = action;
        }
        public void SetOnClick(Action<Button> action)
        {
            this.onClick = action;
        }

        public void Render()
        {
            if (!Raylib.WindowShouldClose()) // Make sure that we still have access to raylib tech
            {
                // Text Width
                Vector2 textSizing = Raylib.MeasureTextEx(this.font, text, text_size, TEXT_SPACING);
                int textWidth = (int)Math.Round(textSizing.X);
                int textHeight = (int)Math.Round(textSizing.Y);

                // Check Hover
                //this.Hover(false);

                // Draw
                Raylib.DrawRectangle(x, y, textWidth + this.padding_x, textHeight + this.padding_y, color_bg);
                Raylib.DrawTextEx(this.font, this.text, new Vector2(x + this.padding_x / 2, y + this.padding_y / 2), this.text_size, TEXT_SPACING, Color.WHITE);

            }
        }

        public void RenderCenter()
        {
            if (!Raylib.WindowShouldClose()) // Make sure that we still have access to raylib tech
            {
                // Text Width
                Vector2 textSizing = Raylib.MeasureTextEx(this.font, this.text, this.text_size, TEXT_SPACING);
                int textWidth = (int)Math.Round(textSizing.X);
                int textHeight = (int)Math.Round(textSizing.Y);

                // Modified Origin
                int center_x = x - (this.padding_x / 2) - (textWidth / 2);
                int center_y = y - (this.padding_y / 2) - (textHeight / 2);

                Rectangle rect = new Rectangle(center_x, center_y, this.padding_x + textWidth, this.padding_y + textHeight);

                // Check Hover
                this.Hover(rect);

                // Draw
                Raylib.DrawRectangleRec(rect, color_bg);
                Raylib.DrawTextEx(this.font, this.text, new Vector2(center_x + this.padding_x / 2, center_y + this.padding_y / 2), this.text_size, TEXT_SPACING, Color.WHITE);
            }
        }

        private bool Hover(Rectangle rect)
        {

            if(Raylib.CheckCollisionPointRec(new Vector2(Raylib.GetMouseX(), Raylib.GetMouseY()), rect)) {
                // Check Hover
                if (this.onHover != null)
                {
                    this.onHover(this);
                }

                // Check Click
                if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    if (this.onClick != null)
                    {
                        this.onClick(this);
                    }
                }
                return true;
            }
            return false;
        }

    }
}
