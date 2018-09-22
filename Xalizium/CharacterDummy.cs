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
    public class CharacterDummy : Entity
    {
        //private Random rdm;

        public CharacterDummy() : base(Character: 'T', Color: ConsoleColor.Blue) { this.IsSolid = false;  }

        // Top Notch AI - 2 x Intel Xeon 5GHz required
        public override void OnTick()
        {
            int num = RandomManager.Range(0, 4);

            Direction dir = (Direction)num;

            Move(dir);

            Color = (ConsoleColor)RandomManager.Range(0, 14);
        }

        public override void OnCollision(Entity entity)
        {
            Debug.WriteLine(entity.Name + " touched me!");
        }
    }
}
