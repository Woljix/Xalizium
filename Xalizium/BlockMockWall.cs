using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API;
using Xalizium.API.Items;

namespace Xalizium
{
    public class BlockMockWall : Block
    {
        public BlockMockWall() : base("MockWall", '█') { this.IsSolid = false; }

        public override void OnCollision(Entity entity) => Kill(); // OOF
    }
}
