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
        private Vector<double> cameraPosition = DefaultCameraPosition;
        private Vector<double> cameraTarget = Vector<double>.Build.Dense(new double[3] { 0, 0, 0 });
        private Vector<double> upVector = Vector<double>.Build.Dense(new double[3] { 0, 0, 1 });

        public static readonly Vector<double> DefaultCameraPosition = Vector<double>.Build.Dense(new double[3] { 5, 0, -2 });

        public Vector<double> CameraPosition
        {
            get
            {
                return cameraPosition;
            }
            set
            {
                cameraPosition = value;
                CalculateMatrix();
            }
        }
        public Vector<double> CameraTarget
        {
            get
            {
                return cameraTarget;
            }
            set
            {
                cameraTarget = value;
                CalculateMatrix();
            }
        }
        public Vector<double> UpVector
        {
            get
            {
                return upVector;
            }
            set
            {
                upVector = value;
                CalculateMatrix();
            }
        }

        public Matrix<double> Matrix { get; private set; }

        public ViewMatrix()
        {
            CalculateMatrix();
        }

        private void CalculateMatrix()
        {

            var zAxis = (cameraPosition - cameraTarget).Normalize(2);
            var xAxis = MathExtensions.CrossProduct(upVector, zAxis).Normalize(2);
            var yAxis = MathExtensions.CrossProduct(zAxis, xAxis);


            Matrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { xAxis[0], xAxis[1], xAxis[2], -xAxis * cameraPosition },
                    { yAxis[0], yAxis[1], yAxis[2], -yAxis * cameraPosition },
                    { zAxis[0], zAxis[1], zAxis[2], -zAxis * cameraPosition },
                    {        0,        0,        0,                       1 }
                }
            );
        }
    }
}
