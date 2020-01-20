using GK3D.Models;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public static class Initializers
    {
        public static List<Light> InitializeLights()
        {
            return new List<Light>()
            {
                new Light()
                {
                    nominalPosition = Vector<double>.Build.Dense(new double[4] { -4.5, -0.5, 0, 1 }),
                    color = Color.FromArgb(255, 240, 188)
                }
            };
        }

        public static List<IModel> InitializeModels()
        {
            var initialModels = new List<IModel>();

            var matrix1 = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                }
            );
            var matrix2 = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 2 },
                    { 0, 1, 0, 1 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 0, 1 }
                }
            );

            var points1 = new List<Vector<double>>()
            {
                Vector<double>.Build.Dense(new double[4] { -1, -1, -1, 1 }),
                Vector<double>.Build.Dense(new double[4] { 1, -1, -1, 1 }),
                Vector<double>.Build.Dense(new double[4] { 1, 1, -1, 1 }),
                Vector<double>.Build.Dense(new double[4] { -1, 1, -1, 1 }),
                Vector<double>.Build.Dense(new double[4] { -1, -1, 1, 1 }),
                Vector<double>.Build.Dense(new double[4] { 1, -1, 1, 1 }),
                Vector<double>.Build.Dense(new double[4] { 1, 1, 1, 1 }),
                Vector<double>.Build.Dense(new double[4] { -1, 1, 1, 1 })
            };

            var points2 = new List<Vector<double>>()
            {
                Vector<double>.Build.Dense(new double[4] { -0.5, -0.5, -0.5, 1 }),
                Vector<double>.Build.Dense(new double[4] { 0.5, -0.5, -0.5, 1 }),
                Vector<double>.Build.Dense(new double[4] { 0.5, 0.5, -0.5, 1 }),
                Vector<double>.Build.Dense(new double[4] { -0.5, 0.5, -0.5, 1 }),
                Vector<double>.Build.Dense(new double[4] { -0.5, -0.5, 0.5, 1 }),
                Vector<double>.Build.Dense(new double[4] { 0.5, -0.5, 0.5, 1 }),
                Vector<double>.Build.Dense(new double[4] { 0.5, 0.5, 0.5, 1 }),
                Vector<double>.Build.Dense(new double[4] { -0.5, 0.5, 0.5, 1 })
            };


            var matrix3 = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 1.0 },
                    { 0, 1, 0, 2.5 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                }
            );

            initialModels.Add(new Cuboid(points1, matrix1, Color.Aqua));
            initialModels.Add(new Cuboid(points2, matrix2, Color.BlueViolet));

            initialModels.Add(new Sphere(1.2, matrix3, Color.PaleGreen));

            return initialModels;
        }
    }
}
