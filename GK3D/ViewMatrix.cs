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
        private Vector<double> cameraPosition;
        private Vector<double> cameraTarget;
        private Vector<double> upVector;

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

        public ViewMatrix(Vector<double> _cameraPosition, Vector<double> _cameraTarget, Vector<double> _upVector)
        {
            cameraPosition = _cameraPosition;
            cameraTarget = _cameraTarget;
            upVector = _upVector.Normalize(2);

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
