using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium.API.Managers
{
    public class GameObjectManager
    {
        //private List<GameObject> InitGameObjects = new List<GameObject>();
        public List<GameObject> GameObjects { get; } = new List<GameObject>();

        internal GameObjectManager() { }

        //public void Initialize(GameObject gameObject)
        //{
        //    InitGameObjects.Add(gameObject);
        //}

        public GameObject Find(string Name)
        {
            if (GameObjects.Any(x => x.Name == Name))
            {
                return GameObjects.Where(x => x.Name == Name).FirstOrDefault();
            }

            return null;
        }
        public GameObject[] FindAll(string Name)
        {
            if (GameObjects.Any(x => x.Name == Name))
            {
                return GameObjects.Where(x => x.Name == Name).ToArray();
            }

            return null;
        }

        public GameObject FindOnPosition(Vector2 Position)
        {
            return FindAllOnPosition(Position)[0];
        }
        public GameObject[] FindAllOnPosition(Vector2 Position)
        {
            if (GameObjects.Any(x => Vector2.AreEqual(x.Position, Position)))
            {
                return GameObjects.Where(x => Vector2.AreEqual(x.Position, Position)).ToArray();
            }

            return null;
        }

        public void Add(GameObject GameObject)
        {
            if (string.IsNullOrEmpty(GameObject.Name))
                GameObject.Name = "GameObject" + GameObjects.Count;

            GameObjects.Add(GameObject);
            GameObject.OnStart();
        }
        public void Delete(GameObject GameObject)
        {
            // Really bad workaround but hell.
            Vector2 pos = GameObject.Position;
            GameObjects.Remove(GameObject);
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(' ');

        }
        public void Delete(string Name)
        {
            foreach(GameObject obj in GameObjects.Where(x => x.Name == Name))
            {
                Vector2 pos = obj.Position;
                GameObjects.Remove(obj);
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write(' ');
            }
        }

        public void AddText(string Text, Vector2 Position)
        {
            // More of a test function
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.WriteLine(Text);
        }
    }
}
