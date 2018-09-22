using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API.Items
{
    public abstract class Item
    {
        public string Name { get; internal set; } = string.Empty;
        public bool Equippable { get; internal set; } = false;
    }
}
