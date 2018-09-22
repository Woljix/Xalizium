using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium.API.Managers
{
    public class EntityManager
    {
        public List<Entity> Entities { get; } = new List<Entity>();

        internal EntityManager() { }

        public Entity Find(string Name)
        {
            if (Entities.Any(x => x.Name == Name))
            {
                return Entities.Where(x => x.Name == Name).FirstOrDefault();
            }

            return null;
        }
        public Entity[] FindAll(string Name)
        {
            if (Entities.Any(x => x.Name == Name))
            {
                return Entities.FindAll(x => x.Name == Name).ToArray();
            }

            return null;
        }

        public Entity FindOnPosition(Vector2 Position)
        {
            return FindAllOnPosition(Position)[0];
        }
        public Entity[] FindAllOnPosition(Vector2 Position)
        {
            if (Entities.Any(x => Vector2.AreEqual(x.Position, Position)))
            {
                return Entities.Where(x => Vector2.AreEqual(x.Position, Position)).ToArray();
            }

            return null;
        }

        public void Add(Entity Entity)
        {
            if (string.IsNullOrEmpty(Entity.Name))
                Entity.Name = "Entity" + Entities.Count;

            Entities.Add(Entity);
        }
        public void Delete(Entity Entity)
        {
            Entities.Remove(Entity);
        }
        public void Delete(string Name)
        {
            foreach (Entity obj in Entities.Where(x => x.Name == Name))
            {
                Entities.Remove(obj);
            }
        }
    }
}
