using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D.Models
{
    public interface IModel
    {
        List<(int, int, int)> TriangleIndexes { get; set; }
        List<Triangle> Triangles { get; set; }
        List<Vector<double>> Points { get; set; }
        Matrix<double> Matrix { get; set; }
        Color Color { get; set; }
        Vector<double> Center { get; set; }
    }
}
