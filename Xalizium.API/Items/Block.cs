using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API.Items
{
    public abstract class Block : GameObject
    {
        public Block() { }
        public Block(string Name = "", char Character = '@', ConsoleColor Color = ConsoleColor.Gray) { this.Name = Name; this.Character = Character; this.Color = Color; }
    }
}
