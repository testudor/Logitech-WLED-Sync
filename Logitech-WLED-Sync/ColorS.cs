using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logitech_WLED_Sync
{
    struct ColorS
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte Br { get; set; }

        public int R_100
        {
            get { return ((int)R).Remap(0, 255, 0, Br_100); }            
        }
        public int G_100
        {
            get { return ((int)G).Remap(0, 255, 0, Br_100); }
        }
        public int B_100
        {
            get { return ((int)B).Remap(0, 255, 0, Br_100); }
        }
        public int Br_100
        {
            get { return ((int)Br).Remap(0, 255, 0, 100); }
        }

        public static bool operator ==(ColorS a, ColorS b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ColorS a, ColorS b)
        {
            return !a.Equals(b);
        }

        public ColorS(byte r, byte g, byte b, byte br)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.Br = br;
        }

        public static ColorS Lerp(ColorS a, ColorS b, float t)
        {
            t = t.Clamp(0f, 1f);

            return new ColorS((byte)((double)a.R + (double)((int)b.R - (int)a.R) * (double)t), (byte)((double)a.G + (double)((int)b.G - (int)a.G) * (double)t), (byte)((double)a.B + (double)((int)b.B - (int)a.B) * (double)t), (byte)((double)a.Br + (double)((int)b.Br - (int)a.Br) * (double)t));
        }

        public override bool Equals(object obj)
        {
            return obj is ColorS s &&
                   R == s.R &&
                   G == s.G &&
                   B == s.B &&
                   Br == s.Br;
        }

        public override int GetHashCode()
        {
            var hashCode = -5185419;
            hashCode = hashCode * -1521134295 + R.GetHashCode();
            hashCode = hashCode * -1521134295 + G.GetHashCode();
            hashCode = hashCode * -1521134295 + B.GetHashCode();
            hashCode = hashCode * -1521134295 + Br.GetHashCode();
            return hashCode;
        }
    }
}
