using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API;
using Xalizium.API.Items;
using Xalizium.API.Managers;

namespace TestPlugin
{
    public class BlockPlugin : Block
    {
        public BlockPlugin() : base ("BlockPlugin", 'P', ConsoleColor.DarkGreen) { IsSolid = false; }

        public override void OnCollision(Entity entity)
        {
            if (entity.GetType() == typeof(Player))
                Debug.WriteLine("PLUGINS ARE COOL!");

            Color = (ConsoleColor)RandomManager.Range(0, 14);
            Draw();
        }
    }
}
