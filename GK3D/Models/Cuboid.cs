using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D.Models
{
    public class Cuboid : Model
    {
        public List<(int, int, int)> TriangleIndexes { get; set; }

        public List<Vector<double>> Points { get; set; }

        public Matrix<double> Matrix { get; set; }

        public Color Color { get; set; }

        public List<Triangle> Triangles { get; set; }

        public Cuboid(List<Vector<double>> points, Matrix<double> matrix, Color color)
        {
            Color = color;
            Points = points;
            Matrix = matrix;

            TriangleIndexes = new List<(int, int, int)> { (0, 1, 2), (0, 3, 2), (1, 2, 6), (1, 5, 6), (0, 1, 5), (0, 4, 5), (2, 3, 7), (2, 6, 7), (3, 0, 4), (3, 7, 4), (5, 4, 7), (5, 6, 7) };
        }
    }
}                        
                         

                         
                         

                         
                         

                         
                         

                        
                        