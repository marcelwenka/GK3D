using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D.Models
{
    public class Cuboid : IModel
    {
        public List<(int, int, int)> TriangleIndexes { get; set; }

        public List<Vector<double>> Points { get; set; }

        public Matrix<double> Matrix { get; set; }

        public Color Color { get; set; }

        public List<Triangle> Triangles { get; set; }

        public Vector<double> Center { get; set; }

        public Vector<double> N(Triangle triangle)
        {
            var U = Vector<double>.Build.Dense(new double[3] { triangle.points[1].X - triangle.points[0].X, triangle.points[1].Y - triangle.points[0].Y, triangle.points[1].Z - triangle.points[0].Z});
            var V = Vector<double>.Build.Dense(new double[3] { triangle.points[2].X - triangle.points[0].X, triangle.points[2].Y - triangle.points[0].Y, triangle.points[2].Z - triangle.points[0].Z});

            return MathExtensions.CrossProduct(U, V).Normalize(2);
        }

        public Cuboid(List<Vector<double>> points, Matrix<double> matrix, Color color)
        {
            Color = color;
            Points = points;
            Matrix = matrix;

            TriangleIndexes = new List<(int, int, int)> { (0, 1, 2), (0, 2, 3), (1, 6, 2), (1, 5, 6), (0, 5, 1), (0, 4, 5), (2, 7, 3), (2, 6, 7), (3, 4, 0), (3, 7, 4), (5, 4, 7), (5, 7, 6) };
        }
    }
}                        
                         

                         
                         

                         
                         

                         
                         

                        
                        