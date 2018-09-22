using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API.Items
{
    public abstract class Weapon : Item
    {
        public Weapon(string Name) { this.Equippable = true; this.Name = Name; }

        public virtual void OnPrimaryFire() { }
        public virtual void OnSecondaryFire() { }
    }
}
