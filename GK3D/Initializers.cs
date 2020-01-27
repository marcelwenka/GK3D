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
                    position = Vector<double>.Build.Dense(new double[3] { 10, 0, -10 }),
                    color = Color.FromArgb(255, 240, 188),
                    type = LightType.Point
                },
                new Light()
                {
                    position = Vector<double>.Build.Dense(new double[3] { 2.5, -2, 0 }),
                    color = Color.Red,
                    type = LightType.Spot,
                    direction = Vector<double>.Build.Dense(new double[3] { 1, 0, 0 }).Normalize(2)
                }
            };
        }

        public static List<IModel> InitializeModels()
        {
            var initialModels = new List<IModel>();

            var cuboid1Matrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, -0.5 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                }
            );
            var cuboid2Matrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 2.5 },
                    { 0, 1, 0, -2 },
                    { 0, 0, 1, 1 },
                    { 0, 0, 0, 1 }
                }
            );

            var sphereMatrix = DenseMatrix.OfArray(
                new double[4, 4]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 2.5 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                }
            );

            var cuboid1Points = new List<Vector<double>>()
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

            var cuboid2Points = new List<Vector<double>>()
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

            initialModels.Add(new Cuboid(cuboid1Points, cuboid1Matrix, Color.Gold));
            initialModels.Add(new Cuboid(cuboid2Points, cuboid2Matrix, Color.Firebrick));
            initialModels.Add(new Sphere(1.5, sphereMatrix, Color.SlateBlue));

            return initialModels;
        }
    }
}
