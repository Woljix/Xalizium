using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API.Items
{
    public abstract class Entity : GameObject
    {
        #region DEBUG SETTINGS
        internal bool IsGodMode = false; // Can walkthrough walls (Warning going ouside of the bufferzone will crash the game)
        #endregion

        public Entity() { }
        public Entity(string Name = "", char Character = '@', ConsoleColor Color = ConsoleColor.Gray) { this.Name = Name; this.Character = Character; this.Color = Color; }

        public virtual void OnMove(Vector2 NewPosition) {  }

        /// <summary>
        /// Moves the Entity in the specified direction if there is nothing blocking it's way.
        /// </summary>
        /// <param name="Direction"></param>
        public void Move(Direction Direction)
        {
            Vector2 newpos = new Vector2();

            switch (Direction)
            {
                case Direction.North: newpos += Vector2.North; break;
                case Direction.East: newpos += Vector2.East; break;
                case Direction.South: newpos += Vector2.South; break;
                case Direction.West: newpos += Vector2.West; break;
            }

            newpos += this.Position;

            if (CanMove(newpos)) { this.LastPosition = new Vector2(Position); this.Position = new Vector2(newpos); OnMove(Position);  }
        }
        private bool CanMove(Vector2 _Position)
        {
            if (IsGodMode) return true;
            if (_Position.X < 0 || _Position.Y < 0 || _Position.X >= Console.BufferWidth - 1 || _Position.Y >= Console.BufferHeight - 1) return false;

            var gameObjects = GameObject.FindAllOnPosition(_Position);

            if (gameObjects != null && gameObjects.Length != 0)
            {
                foreach (GameObject obj in gameObjects)
                    if (obj.IsSolid) return false;
                    else obj.OnCollision(this); return true;
            }
            return true;
        }

        public override void Kill() => World.EntityManager.Delete(this);
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}
