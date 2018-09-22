using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API.Managers
{
    public static class RandomManager
    {
        private static Random _rdm; // Singleton

        private static Random Random
        {
            get
            {
                if (_rdm == null)
                    _rdm = new Random();

                return _rdm;
            }
        }

        public static int Range(int start, int end)
        {
            return Random.Next(start, end);
        }

        public static int Next()
        {
            return Random.Next();
        }
    }
}
