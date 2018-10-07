using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xalizium.API
{
    /// <summary>
    /// Xalizium's Custom Math class, because fuck you.
    /// </summary>
    public static class Mathx
    {
        // TODO: Beautify. But it works so, whatever.
        public static int Clamp(int Value, int MinValue, int MaxValue)
        {
            if (Value >= MaxValue) Value = MaxValue;
            else if (Value <= MinValue) Value = MinValue;
            return Value;
        }
    }
}
