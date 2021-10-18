using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using ludwig_jam_2021.Engine.Renderer;

namespace ludwig_jam_2021.Engine.Objects
{
    class Platform : GameObject
    {
        public override Sprite sprite { get; set; }
        public override float x { get; set; }
        public override float y { get; set; }

        //Constructor
        public Platform(float x, float y)
        {
            this.x = x;
            this.y = y;
            sprite = new Sprite(new string[] { "Assets/Art/platform.png" }, false);
        }
        public override void Update()
        {
            Console.WriteLine("Platform Updated");
        }

        public override void Render()
        {
            sprite.Draw(Convert.ToInt32(Math.Round(x)), Convert.ToInt32(Math.Round(y)));
            Console.WriteLine("Platform Rendered");
        }
    }
}
