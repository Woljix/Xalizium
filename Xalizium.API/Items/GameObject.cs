using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API.Items
{
    public abstract class GameObject
    {
        public string Name { get;  set; } = string.Empty;
        public char Character { get; set; } = '█';
        private int _Health = 100;
        public int Health
        {
            set => _Health = Mathx.Clamp(value, 0, 100);        
            get => _Health;        
        }

        public Vector2 Position { get; set; } = new Vector2();
        public Vector2 LastPosition { get; set; } = new Vector2();

        public ConsoleColor Color { get; set; } = ConsoleColor.Gray;

        public bool IsSolid { get; set; } = true;

        #region Shortcuts (Don't know if this is a good coding practice)
        /// <summary>
        /// Shortcut to making 
        /// </summary>
        /// <param name="GameObject"></param>
        public static void Create(GameObject GameObject) => World.GameObjectManager.Add(GameObject); 

        public static GameObject Find (string Name) => World.GameObjectManager.Find(Name); 
        public static GameObject[] FindAll (string Name) => World.GameObjectManager.FindAll(Name);

        public static GameObject FindOnPosition (Vector2 Position) =>World.GameObjectManager.FindOnPosition(Position); 
        public static GameObject[] FindAllOnPosition (Vector2 Position) => World.GameObjectManager.FindAllOnPosition(Position); 
        #endregion
        /// <summary>
        /// Destroys the GameObject if it is present in the GameObjectManager.
        /// </summary>
        public virtual void Kill() => World.GameObjectManager.Delete(this);

        /// <summary>
        /// Heals the GameObject the specified amount.
        /// </summary>
        /// <param name="Amount"></param>
        public void HealMe(int Amount) { Health += Amount; }
        /// <summary>
        /// Damages the GameObject the specified amount.
        /// </summary>
        /// <param name="Amount"></param>
        public void HurtMe(int Amount) { Health -= Amount; }

        /// <summary>
        /// Called When The GameObject Comes Into Life
        /// </summary>
        public virtual void OnStart() { }
        /// <summary>
        /// Called Every Tick
        /// </summary>
        public virtual void OnTick() { }

        /// <summary>
        /// Called when an Entity collides with the GameObject
        /// </summary>
        /// <param name="entity"></param>
        public virtual void OnCollision(Entity entity) { }

        /// <summary>
        /// Should Only Be Called If a GameObject Needs Redrawing For Some Reason!
        /// </summary>
        public void Draw()
        {
            if (Position.X < 0 || Position.Y < 0 || Position.X >= Console.BufferWidth - 1 || Position.Y >= Console.BufferHeight) return;

            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Character);
        }
    }
}
