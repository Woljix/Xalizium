using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium
{
    public class BlockFloorDummy : Block
    {
        public BlockFloorDummy () : base()
        {
            Character = 'O';
            Color = ConsoleColor.Red;
            this.IsSolid = false;
        }

        public override void OnCollision(Entity entity)
        {
            entity.HurtMe(26);
            Debug.WriteLine(entity.Name + " " + entity.Health);
            entity.Color = ConsoleColor.DarkGreen;
        }
    }
}
