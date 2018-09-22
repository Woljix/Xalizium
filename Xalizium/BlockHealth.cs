using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium
{
    public class BlockHealth : Block
    {
        public BlockHealth() : base("Health", 'H', ConsoleColor.Red) { IsSolid = false; }

        public override void OnCollision(Entity entity)
        {
            if (entity.Health < 100)
            {
                entity.HealMe(14);
                Debug.WriteLine(entity.Name + " Health is now: " + entity.Health);
                Kill();
            }
        }
    }
}
