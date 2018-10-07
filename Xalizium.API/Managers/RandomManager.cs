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
        private static Random Random { get => _rdm ?? (_rdm = new Random()); } // Holy Shit, this works? OMG

        public static int Range(int start, int end) => Random.Next(start, end);
        public static int Next()  => Random.Next();
    }
}
