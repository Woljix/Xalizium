using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API;
using Xalizium.API.Items;

namespace TestPlugin
{
    public class Program : Plugin
    {
        public override void Initialize()
        {
            //File.WriteAllText("Test.txt", "HELLO FROM THE PLUGIN!");
            BlockPlugin block = new BlockPlugin();
            block.Position = new Vector2(2, 2);
            GameObject.Create(block);
           // World.GameObjectManager.Add(block);
        }
    }
}
