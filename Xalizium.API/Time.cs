using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API
{
    public static class Time
    {
        // TODO: Make usable? I dunno, seems kinda pointless as a console app tbh.
        internal static double _deltaTime = 0;

        public static double DeltaTime
        {
            internal set { _deltaTime = value; }
            get { return _deltaTime; }
        }
    }
}
