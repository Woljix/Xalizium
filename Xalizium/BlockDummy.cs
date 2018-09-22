using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;
using Xalizium.API.Managers;

namespace Xalizium
{
    public class BlockDummy : Block
    {
        public BlockDummy() { this.Name = "Dummy"; this.Character = '█'; }

        public override void OnTick()
        {
            //Color = (ConsoleColor)RandomManager.Range(0, 14);

            //Draw();
        }
    }
}
