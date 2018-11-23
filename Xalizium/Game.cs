using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xalizium.API;
using Xalizium.API.Items;
using Xalizium.Managers;

namespace Xalizium
{
    /* 
     * THE DEMIGOD CLASS
     * 
     * IT CONTROLS EVERONE AND EVERYTHING
     * 
     * THE HEART AND SOUL OF THE GAME ENGINE.
     * 
     * -Woljix
     */
    public class Game : IDisposable
    {
        public Game()
        {
            Blockionary.Add("BlockDummy", new BlockDummy());
            Blockionary.Add("BlockFloorDummy", new BlockFloorDummy());
            Blockionary.Add("BlockHealth", new BlockHealth());
            Blockionary.Add("BlockMockWall", new BlockMockWall());

            Entitionary.Add("CharacterDummy", new CharacterDummy());        

            //Debug.WriteLine(Blockionary._blocks.Count);

            PluginManager.LoadAllTheFiles();

            // NOTE: Maybe use this for initializing GameObjects & Items for later use.

            LoadMap("Map1.txt");

            //Map.LoadMap("Map2.json");

            //MapFile.MakeCurrentMapIntoFile("Map2.json");
        }

        public void Run()
        {
            Console.Clear();

            Console.BufferHeight = 30;
            Console.BufferWidth = 120;

            DrawWorld(); // Should only be needed to call once. As my system will redraw the one's that have been drawn over by entities etc.

           // World.GameObjectManager.AddText("Hello World", new Vector2(35, 23)); // Test

            while (true)
            {
                Console.CursorVisible = false;
                DrawEntities();
                ConsoleKey c = Console.ReadKey(true).Key;
                UpdateEverything(c);
            }
        }

        public void DrawWorld()
        {
            World.GameObjectManager.GameObjects.ForEach(x => x.Draw());
        }
        public void DrawEntities()
        {
            foreach (Entity entity in World.EntityManager.Entities)
            {
                if (World.GameObjectManager.GameObjects.Exists(x => Vector2.AreEqual(x.Position, entity.LastPosition)))
                {
                    World.GameObjectManager.GameObjects.FindAll(x => Vector2.AreEqual(x.Position, entity.LastPosition)).ForEach(x => x.Draw());
                }
                else
                {
                    Console.SetCursorPosition(entity.LastPosition.X, entity.LastPosition.Y);
                    Console.Write(' ');
                }

                entity.Draw();
            }

            //TODO: Should probably make this alot more compact and/ or change the system.
            if (World.GameObjectManager.GameObjects.Exists(x => Vector2.AreEqual(x.Position, World.Player.LastPosition)))
            {
                World.GameObjectManager.GameObjects.FindAll(x => Vector2.AreEqual(x.Position, World.Player.LastPosition)).ForEach(x => x.Draw());
            }
            else
            {
                Console.SetCursorPosition(World.Player.LastPosition.X, World.Player.LastPosition.Y);
                Console.Write(' ');
            }

            World.Player.Draw();    
        }

        public void UpdateEverything(ConsoleKey key)
        {
            World.GameObjectManager.GameObjects.ForEach(x => x.OnTick());
            World.EntityManager.Entities.ForEach(x => x.OnTick());
            // Update AI characters first.
            World.Player.Update(key);
        }

        public void LoadMap(string Filename)
        {
            // Very Hardcoded ATM, i'll fix this later when i feel like it.

            if (File.Exists(Filename))
            {
                string[] file = File.ReadAllLines(Filename);

                for (int y = 0; y < file.Length; y++)
                {
                    for (int x = 0; x < file[y].Length; x++)
                    {
                        Block block = null;
                        Entity entity = null;

                        char c = file[y][x];
                        switch (c)
                        {
                            case 'X': block = (Block)Blockionary.GetBlockByName("BlockDummy"); break;
                            case 'Z': block = (Block)Blockionary.GetBlockByName("BlockMockWall"); break;
                            case '#': World.Player.Position = new Vector2(x, y); break;
                            case 'O': block = (Block)Blockionary.GetBlockByName("BlockFloorDummy"); break;
                            case 'T': entity = new CharacterDummy(); break;
                            case 'H': block = (Block)Blockionary.GetBlockByName("BlockHealth"); break;
                        }

                        if (block != null)
                        {
                            block.Position = new Vector2(x, y);
                            GameObject.Create(block);
                        }

                        if (entity != null)
                        {
                            entity.Position = new Vector2(x, y);
                            World.EntityManager.Add(entity);
                        }
                    }
                }
            }
        }

        public void Dispose() { } // Don't Have To Dispose of Anything ATM
    }
}
