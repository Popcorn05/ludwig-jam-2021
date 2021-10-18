using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ludwig_jam_2021.Engine.Objects
{
    //Abstract class because shouldn't be instanced
    abstract class GameObject
    {
        //Gameworld position
        private float x;
        private float y;

        //Render function, to be overridden in extensions
        public abstract bool Render();
    }
}
