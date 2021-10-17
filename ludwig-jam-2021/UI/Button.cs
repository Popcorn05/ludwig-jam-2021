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
        private int x;
        private int y;

        private int padding_x;
        private int padding_y;

        private string text;
        private int text_size;
        private int text_height;

        private Color color_bg;

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

        public void SetText(String text_content, int font_size)
        {
            this.text = text_content;
            this.text_size = font_size;
        }

        public void SetTextHeight(int height)
        {
            this.text_height = height;
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
                int textWidth = Raylib.MeasureText(text, text_size);

                // Check Hover
                this.Hover(false);

                // Draw
                Raylib.DrawRectangle(x, y, textWidth + this.padding_x, this.text_height + this.padding_y, color_bg);
                Raylib.DrawText(text, x + this.padding_x / 2, y + this.padding_y / 2, text_size, Color.WHITE);
            }
        }

        public void RenderCenter()
        {
            if (!Raylib.WindowShouldClose()) // Make sure that we still have access to raylib tech
            {
                // Text Width
                int textWidth = Raylib.MeasureText(text, text_size);

                // Modified Origin
                int center_x = x - (textWidth / 2) - (this.padding_x / 2);
                int center_y = y - (this.text_height / 2) - (this.padding_y / 2);

                // Check Hover
                this.Hover(true);

                // Draw
                Raylib.DrawRectangle(center_x, center_y, textWidth + this.padding_x, this.text_height + this.padding_y, color_bg);
                Raylib.DrawText(text, center_x + this.padding_x / 2, center_y + this.padding_y / 2, text_size, Color.WHITE);
            }
        }

        private bool Hover(bool centered)
        {
            int x;
            int y;
            int x_end;
            int y_end;

            int textWidth = Raylib.MeasureText(text, text_size);

            if (centered == true)
            {
                x = this.x - (textWidth / 2) - (this.padding_x / 2);
                y = this.y - (this.text_height) - (this.padding_y / 2);

                x_end = x + textWidth + this.padding_x;
                y_end = y + this.text_height + this.padding_y;
            } else
            {
                x = this.x;
                y = this.y;

                x_end = x + textWidth + this.padding_x;
                y_end = y + this.text_height + this.padding_y;
            }

            Vector2 mousePosition = Raylib.GetMousePosition();
            if(mousePosition.X > x && mousePosition.X < x_end)
            {
                if (mousePosition.Y > y && mousePosition.Y < y_end)
                {
                    // Check Hover
                    if (this.onHover != null)
                    {
                        this.onHover(this);
                    }

                    // Check Click
                    if(Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        if(this.onClick != null)
                        {
                            this.onClick(this);
                        }
                    }
                    return true;
                }
            }
            return false;
        }

    }
}
