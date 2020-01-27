using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public class ProjectionMatrix
    {
        public double _n = 1;
        public double _f = 100;
        public double _fov = 0.55 * Math.PI;
        private double _e;
        public double _a;

        public double f
        {
            get
            {
                return _f;
            }
            set
            {
                _f = value;
                Matrix[2, 2] = -(_f + _n) / (_f - _n);
                Matrix[2, 3] = -2 * _f * _n / (_f - _n);
            }
        }

        public double n
        {
            get
            {
                return _n;
            }
            set
            {
                _n = value;
                Matrix[2, 2] = -(_f + _n) / (_f - _n);
                Matrix[2, 3] = -2 * _f * _n / (_f - _n);
            }
        }

        public double a
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
                Matrix[1, 1] = _e / _a;
            }
        }

        public double fov
        {
            get
            {
                return _fov;
            }
            set
            {
                _fov = value;
                _e = 1 / Math.Tan(_fov / 2);
                Matrix[0, 0] = _e;
                Matrix[1, 1] = _e / _a;

            }
        }

        public Matrix<double> Matrix { get; private set; }

        public ProjectionMatrix(double heightWidthRatio)
        {
            _a = heightWidthRatio;
            _e = 1 / Math.Tan(_fov / 2);

            Matrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { _e, 0, 0, 0 },
                    { 0, _e/_a, 0, 0 },
                    { 0, 0, -(_f+_n)/(_f-_n), -2*_f*_n/(_f-_n) },
                    { 0, 0, -1, 0 }
                }
            );
        }
    }
}
