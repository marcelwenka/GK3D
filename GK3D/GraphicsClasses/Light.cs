using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public class Light
    {
        public Vector<double> position;
        public Color color;
        public LightType type;
        public Vector<double> direction;
    }
}
