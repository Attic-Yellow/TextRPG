using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG.Ui
{
    public class SceneManager
    {
        private Scene currentScene;

        public void ChangeScene(Scene newScene)
        {
            currentScene = newScene;
            currentScene.Init();
        }

        public void Update()
        {
            currentScene.Update();
        }

        public void Render()
        {
            currentScene.Render();
        }
    }

    public abstract class Scene
    {
        public abstract void Init();
        public abstract void Update();
        public abstract void Render();
    }
}
