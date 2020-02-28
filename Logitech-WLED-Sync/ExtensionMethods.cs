using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logitech_WLED_Sync
{
    public static class ExtensionMethods
    {
        public static int Remap(this int value, int from1, int to1, int from2, int to2)
        {
            return (int)((float)(value - from1) / (to1 - from1) * (to2 - from2) + from2);
        }

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
    }

}
