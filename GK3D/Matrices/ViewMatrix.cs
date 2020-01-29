using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public class ViewMatrix
    {
        public Vector<double> CameraPosition = DefaultCameraPosition;
        public Vector<double> CameraTarget = Vector<double>.Build.Dense(new double[3] { 0, 0, 0 });
        private readonly Vector<double> upVector = Vector<double>.Build.Dense(new double[3] { 0, 0, 1 });

        public static Vector<double> DefaultCameraPosition = Vector<double>.Build.Dense(new double[3] { 5, 0, -2 });

        public Matrix<double> Matrix { get; private set; }

        public ViewMatrix()
        {
            ReCalculateMatrix();
        }

        public void ReCalculateMatrix()
        {

            var zAxis = (CameraPosition - CameraTarget).Normalize(2);
            var xAxis = MathExtensions.CrossProduct(upVector, zAxis).Normalize(2);
            var yAxis = MathExtensions.CrossProduct(zAxis, xAxis);


            Matrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { xAxis[0], xAxis[1], xAxis[2], -xAxis * CameraPosition },
                    { yAxis[0], yAxis[1], yAxis[2], -yAxis * CameraPosition },
                    { zAxis[0], zAxis[1], zAxis[2], -zAxis * CameraPosition },
                    {        0,        0,        0,                       1 }
                }
            );
        }
    }
}
