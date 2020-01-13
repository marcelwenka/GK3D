using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public class MathExtensions
    {
        public static Vector<double> CrossProduct(Vector<double> v1, Vector<double> v2)
        {
            return Vector<double>.Build.DenseOfArray(new double[]
            {
                v1[1] * v2[2] - v2[1] * v1[2],
                (v1[0] * v2[2] - v2[0] * v1[2]) * -1,
                v1[0] * v2[1] - v2[0] * v1[1]
            });
        }
    }
}
