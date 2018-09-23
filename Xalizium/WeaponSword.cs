using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium
{
    public class WeaponSword : Weapon
    {
        public WeaponSword() : base("Sword") { } 

        public override void OnPrimaryFire()
        {
            base.OnPrimaryFire();
        }
    }
}
