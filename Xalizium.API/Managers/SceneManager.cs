using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API.Managers
{
    // TODO: Fix

    // WIP

    public static class SceneManager
    {
        public static Scene CurrentScene { get; private set; } = null;

        //internal SceneManager() { }

        public static void LoadScene(Scene Scene) { CurrentScene = Scene; }
    }

    public class Scene
    {

    }
}
