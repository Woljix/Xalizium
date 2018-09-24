﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium.API
{
    /// <summary>
    /// The Block Factory
    /// </summary>
    public static class Blockionary
    {
        private static Dictionary<string, Block> _blocks = new Dictionary<string, Block>();

        public static void Add(string Name, Block Block) => _blocks.Add(Name, Block);
        public static void Delete(string Name) => _blocks.Remove(Name);

        public static Block GetBlockByName(string Name)
        {
            Block __block = null;

            if (_blocks.TryGetValue(Name, out __block)) return (Block)Activator.CreateInstance(__block.GetType()); // Never really used an "Activator" before, but it seems to work just fine. (Remember to take a look at the Factory pattern)

            return null;
        }
    }
}
