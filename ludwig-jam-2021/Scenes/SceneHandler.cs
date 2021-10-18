using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ludwig_jam_2021.Scenes
{
    public enum RenderingScenes
    {
        Loading,
        MainMenu,
        Game
    };

    class SceneHandler
    {
        private RenderingScenes scene;
        public SceneHandler()
        {
            this.scene = RenderingScenes.MainMenu; 
        }

        public void ChangeScene(RenderingScenes scene)
        {
            this.scene = scene;

            // Run OnOpen Functions
            if(this.scene == RenderingScenes.MainMenu)
            {
                MainMenu.OnOpen();
            }
        }
    
        public void RenderScene()
        {
            if(this.scene == RenderingScenes.Game)
            {
                Game.Render();
            } else if(this.scene == RenderingScenes.Loading)
            {
                Loading.Render();
            } else if(this.scene == RenderingScenes.MainMenu)
            {
                MainMenu.Render();
            }
        }
    }
}
