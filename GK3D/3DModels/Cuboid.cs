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

        public Vector<double> N(Triangle triangle)
        {
            var U = Vector<double>.Build.Dense(new double[3] { triangle.points[1].worldX - triangle.points[0].worldX, triangle.points[1].worldY - triangle.points[0].worldY, triangle.points[1].worldZ - triangle.points[0].worldZ });
            var V = Vector<double>.Build.Dense(new double[3] { triangle.points[2].worldX - triangle.points[0].worldX, triangle.points[2].worldY - triangle.points[0].worldY, triangle.points[2].worldZ - triangle.points[0].worldZ });

            return MathExtensions.CrossProduct(V, U).Normalize(2);
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
                         

                         
                         

                         
                         

                         
                         

                        
                        