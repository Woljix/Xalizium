using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium.API
{
    /// <summary>
    /// The Entity Factory
    /// </summary>
    public static class Entitionary
    {
        private static Dictionary<string, Entity> _blocks = new Dictionary<string, Entity>();

        public static void Add(string Name, Entity Entity) => _blocks.Add(Name, Entity);
        public static void Delete(string Name) => _blocks.Remove(Name);

        public static Entity GetEntityByName(string Name)
        {
            Entity __block = null;

            if (_blocks.TryGetValue(Name, out __block)) return (Entity)Activator.CreateInstance(__block.GetType()); // Never really used an "Activator" before, but it seems to work just fine. (Remember to take a look at the Factory pattern)

            return null;
        }
    }
}
