using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public class Vertex
    {
        public int X;
        public int Y;

        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static double Dist(Vertex v, int x, int y)
        {
            return Math.Sqrt((v.X - x) * (v.X - x) + (v.Y - y) * (v.Y - y));
        }

    }
}
