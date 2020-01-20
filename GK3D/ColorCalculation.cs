using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GK3D
{
    public static class Lighting
    {
        public static double ka = 0.2;
        public static double kd = 0.7;
        public static double ks = 1;

        public static Vector<double> cameraPosition;

        public static List<Light> lights;

        public static Color CalculateColor(Vector<double> coordinates, Vector<double> N, Color color)
        {
            int m = lights.Count;

            double red = ka * color.R / 255;
            double green = ka * color.G / 255;
            double blue = ka * color.B / 255;

            foreach (var light in lights)
            {
                var L = (coordinates - light.actualPosition).Normalize(2);
                var V = (coordinates - cameraPosition).Normalize(2);
                var R = 2 * MathExtensions.Cos(N, L) * N - L;

                var lightCulaculations = kd * MathExtensions.Cos(N, L) + ks * Math.Pow(MathExtensions.Cos(R, V), m);

                red += color.R / 255.0 * light.color.R / 255.0 * lightCulaculations;
                green += color.G / 255.0 * light.color.G / 255.0 * lightCulaculations;
                blue += color.B / 255.0 * light.color.B / 250.0 * lightCulaculations;
            }

            return Color.FromArgb(ConvertTo256(red), ConvertTo256(green), ConvertTo256(blue));
        }

        private static int ConvertTo256(double color)
        {
            return (int)Math.Round((color < 0 ? 0 : (color > 1 ? 1 : color)) * 255);
        }
    }
}
