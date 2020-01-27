using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public class Vertex
    {
        public double worldX;
        public double worldY;
        public double worldZ;

        public int projectionX;
        public int projectionY;
        public double projectionZ;

        public Vector<double> N = null;

        public Vertex Clone()
        {
            return new Vertex()
            {
                worldX = worldX,
                worldY = worldY,
                worldZ = worldZ,
                projectionX = projectionX,
                projectionY = projectionY,
                projectionZ = projectionZ,
                N = N?.Clone()
            };
        }
    }
}
