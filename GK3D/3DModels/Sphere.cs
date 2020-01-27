using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D.Models
{
    public class Sphere : IModel
    {
        public List<(int, int, int)> TriangleIndexes { get; set; }
        public List<Triangle> Triangles { get; set; }
        public List<Vector<double>> Points { get; set; }
        public Matrix<double> Matrix { get; set; }
        public Color Color { get; set; }
        public Vector<double> Center { get; set; }

        public Vector<double> N(double x, double y, double z)
        {
            return Vector<double>.Build.Dense(new double[3] { x - Matrix[0, 3], y - Matrix[1, 3], z - Matrix[2, 3] }).Normalize(2);

            //return Vector<double>.Build.Dense(new double[3] { Matrix[0, 3] - x, y - Matrix[1, 3], Matrix[2, 3] - z }).Normalize(2);
            //return Vector<double>.Build.Dense(new double[3] { Center[0] - x, y - Center[1] - y, z - Center[2] }).Normalize(2);
            //return Vector<double>.Build.Dense(new double[3] { Center[0] - x, Center[1] - y, Center[2] - z }).Normalize(2);
            //return Vector<double>.Build.Dense(new double[3] { x - Center[0], Center[1] - y, Center[2] - z }).Normalize(2);
            //return Vector<double>.Build.Dense(new double[3] { Center[0] - x, y - Center[1], Center[2] - z }).Normalize(2);
        }

        public Sphere(double radius, Matrix<double> matrix, Color color)
        {
            Color = color;
            Matrix = matrix;

            Points = new List<Vector<double>>
            {
                Vector<double>.Build.Dense(new double[4] { 0, 0, radius, 1 }),
                Vector<double>.Build.Dense(new double[4] { radius, 0, 0, 1 }),
                Vector<double>.Build.Dense(new double[4] { 0, radius, 0, 1 }),
                Vector<double>.Build.Dense(new double[4] { -radius, 0, 0, 1 }),
                Vector<double>.Build.Dense(new double[4] { 0, -radius, 0, 1 }),
                Vector<double>.Build.Dense(new double[4] { 0, 0, -radius, 1 })
            };

            TriangleIndexes = new List<(int, int, int)>
            {
                (1, 5, 2), (2, 5, 3), (3, 5, 4), (4, 5, 1),
                (1, 0, 4), (4, 0, 3), (3, 0, 2), (2, 0, 1)
            };

            for (int depth = 0; depth < 5; depth++)
            {
                int TriangleIndexesCount = TriangleIndexes.Count();
                for (int i = 0; i < TriangleIndexesCount; i++)
                {
                    var w1 = (Points[TriangleIndexes[i].Item2] + Points[TriangleIndexes[i].Item3]).Normalize3D() * radius;
                    var w2 = (Points[TriangleIndexes[i].Item1] + Points[TriangleIndexes[i].Item3]).Normalize3D() * radius;
                    var w3 = (Points[TriangleIndexes[i].Item1] + Points[TriangleIndexes[i].Item2]).Normalize3D() * radius;
                    w1[3] = 1;
                    w2[3] = 1;
                    w3[3] = 1;


                    int i1 = Points.IndexOf(w1);
                    if (i1 == -1)
                    {
                        i1 = Points.Count;
                        Points.Add(w1);
                    }
                    int i2 = Points.IndexOf(w2);
                    if (i2 == -1)
                    {
                        i2 = Points.Count;
                        Points.Add(w2);
                    }
                    int i3 = Points.IndexOf(w3);
                    if (i3 == -1)
                    {
                        i3 = Points.Count;
                        Points.Add(w3);
                    }

                    TriangleIndexes.Add((i1, i2, i3));
                    TriangleIndexes.Add((TriangleIndexes[i].Item1, i2, i3));
                    TriangleIndexes.Add((i1, TriangleIndexes[i].Item2, i3));
                    TriangleIndexes.Add((i1, i2, TriangleIndexes[i].Item3));
                }

                TriangleIndexes.RemoveRange(0, TriangleIndexesCount);
            }
        }
    }
}
