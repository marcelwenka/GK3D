using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    class ProjectionMatrix
    {
        public double n = 1;
        public double f = 100;
        public double fov = 33.333;
        public double a;
        public double e;

        public Matrix<double> Matrix;

        public ProjectionMatrix(double heightWidthRatio)
        {
            a = heightWidthRatio;
            e = 1 / Math.Tan(fov / 2);

            Matrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { e, 0, 0, 0 },
                    { 0, e/a, 0, 0 },
                    { 0, 0, -(f+n)/(f-n), -2*f*n/(f-n) },
                    { 0, 0, -1, 0 }
                }
            );
        }
    }
}
