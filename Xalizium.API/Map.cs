using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;

namespace Xalizium.API
{
    public static class Map
    {
        public static void LoadMap(string Filename)
        {
            if (File.Exists(Filename))
            {
                MapFile mf = JsonConvert.DeserializeObject<MapFile>(File.ReadAllText(Filename));

                if (!string.IsNullOrEmpty(mf.Title)) Debug.WriteLine("Loading Map: " + mf.Title);

                World.Player.Position = mf.PlayerSpawnPoint;

                foreach (MapGameObject mgo in mf.MapGameObjects)
                {
                    switch (mgo.Type)
                    {
                        case GameObjectType.Block:
                            var blck = Blockionary.GetBlockByName(mgo.Name);
                            blck.Position = mgo.Position;
                            GameObject.Create(blck);
                            break;
                        case GameObjectType.Entity:
                            var enty = Entitionary.GetEntityByName(mgo.Name);
                            enty.Position = mgo.Position;
                            World.EntityManager.Add(enty);
                            break;
                    }                
                }
            }
        }
    }

    public class MapFile
    {
        public string Title { get; set; } = string.Empty;

        public Vector2 PlayerSpawnPoint { get; set; } = new Vector2();

        public List<MapGameObject> MapGameObjects { get; set; } = new List<MapGameObject>();

        public static void MakeCurrentMapIntoFile(string Filename)
        {
            MapFile mf = new MapFile();

            List<GameObject> go = new List<GameObject>();

            go.AddRange(World.GameObjectManager.GameObjects);
            go.AddRange(World.EntityManager.Entities);

            foreach (GameObject test in go)
            {
                MapGameObject mgo = new MapGameObject();

                mgo.Name = test.GetType().Name;
                mgo.Position = test.Position;

                string _type = test.GetType().Name;

                if (_type.Contains("Block"))
                    mgo.Type = GameObjectType.Block;
                else if (_type.Contains("Character"))
                    mgo.Type = GameObjectType.Entity;
                else
                    mgo.Type = GameObjectType.Block;

                mf.MapGameObjects.Add(mgo);
            }

            File.WriteAllText(Filename, JsonConvert.SerializeObject(mf, Formatting.Indented));
        }
    }

    public class MapGameObject
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public GameObjectType Type { get; set; }
    }

    public enum GameObjectType
    {
        Block,
        Entity,
    }
}
