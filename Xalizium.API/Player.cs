using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium.API
{
    public class Player : Entity
    {
        public Player() : base(Name: "Woljix", Color: ConsoleColor.Red) { IsSolid = true; }

        public void Update(ConsoleKey c)
        {
            switch (c)
            {
                case ConsoleKey.UpArrow: case ConsoleKey.W: Move(Direction.North); break;
                case ConsoleKey.DownArrow: case ConsoleKey.S: Move(Direction.South); break;
                case ConsoleKey.LeftArrow: case ConsoleKey.A: Move(Direction.West); break;
                case ConsoleKey.RightArrow: case ConsoleKey.D: Move(Direction.East); break;
                //case ConsoleKey.Spacebar:
                //    Block_FloorDummy floor = new Block_FloorDummy();
                //    floor.Name = "Test";
                //    floor.Color = ConsoleColor.Magenta;
                //    floor.Position = this.Position;
                //    World.GameObjectManager.Add(floor);
                //    break;

                case ConsoleKey.E:
                    GameObject[] go = World.GameObjectManager.FindAll("Test");
                    if (go == null)
                        return;

                    if (go.Length != 0)
                    {
                        foreach (GameObject g in go)
                            World.GameObjectManager.Delete(g);
                    }
                    break;
            }
        }

        public override void OnMove(Vector2 NewPosition)
        {
           // Console.Title = NewPosition.ToString();
        }
    }
}
