using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ludwig_jam_2021.Engine.Renderer;

namespace ludwig_jam_2021.Engine.Objects
{
    //Abstract class because shouldn't be instanced, only extended
    abstract class GameObject
    {
        //Gameworld position
        public abstract float x { get; set; }
        public abstract float y { get; set; }

        //Sprite information
        public abstract Sprite sprite { get; set; }

        //Update function
        public abstract void Update();

        //Render function
        public abstract void Render();
    }
}
