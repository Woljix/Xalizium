using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium.API.Managers
{
    public class ItemManager
    {
        private List<Item> Items = new List<Item>();

        internal ItemManager () { }

        public void Add(Item Item) => Items.Add(Item);
    }
}
