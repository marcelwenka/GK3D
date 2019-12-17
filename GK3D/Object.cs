using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public class Object
    {
        public ProjectionMatrix projectionMatrix;
        public Matrix<double> viewMatrix;
        public Matrix<double> modelMatrix;
        public List<Triangle> triangles;

        public Object(double heightWidthRatio)
        {
            projectionMatrix = new ProjectionMatrix(heightWidthRatio);
        }
    }
}
