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
        public double Z;

        public Vertex(int x, int y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static double Dist(Vertex v, int x, int y)
        {
            return Math.Sqrt((v.X - x) * (v.X - x) + (v.Y - y) * (v.Y - y));
        }

        public override bool Equals(object obj)
        {
            return obj is Vertex vertex
                   && X == vertex.X
                   && Y == vertex.Y
                   && Z == vertex.Z;
        }

        public override int GetHashCode()
        {
            var hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }

        public static Vertex operator -(Vertex v1, Vertex v2)
        {
            return new Vertex(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static bool operator ==(Vertex v1, Vertex v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }

        public static bool operator !=(Vertex v1, Vertex v2)
        {
            return !(v1 == v2);
        }

    }
}
