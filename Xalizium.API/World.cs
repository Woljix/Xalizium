using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xalizium.API.Items;
using Xalizium.API.Managers;

namespace Xalizium.API
{
    public static class World
    {
        private static GameObjectManager _gom { get; set; } // Singleton
        private static EntityManager _em { get; set; } // Still Singleton
        private static Player _player { get; set; } // Singleton Once Again

        public static GameObjectManager GameObjectManager
        {
            get
            {
                if (_gom == null)
                    _gom = new GameObjectManager();

                return _gom;
            }
        }
        public static EntityManager EntityManager
        {
            get
            {
                if (_em == null)
                    _em = new EntityManager();

                return _em;
            }
        }
        public static Player Player
        {
            get
            {
                if (_player == null)
                    _player = new Player();

                return _player;
            }
        }
    }
}
