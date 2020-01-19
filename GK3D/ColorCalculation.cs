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
        public static double m = 2;

        public static Vector<double> cameraPosition;

        public static List<Light> lights;

        public static Color CalculateColor(Vector<double> coordinates, Vector<double> N, Color color)
        {
            double red = ka * color.R;
            double green = ka * color.G;
            double blue = ka * color.B;

            foreach (var light in lights)
            {
                var L = (coordinates - light.position).Normalize(2);
                var V = (coordinates - cameraPosition).Normalize(2);
                var R = 2 * MathExtensions.CrossProduct(N, L) * N - L;

                red += color.R * light.color.R * (kd * light.color.R * MathExtensions.Cos(N, L) + ks * Math.Pow(MathExtensions.Cos(R, V), m));
                green += color.G * light.color.G * (kd * light.color.G * MathExtensions.Cos(N, L) + ks * Math.Pow(MathExtensions.Cos(R, V), m));
                blue += color.B * light.color.B * (kd * light.color.B * MathExtensions.Cos(N, L) + ks * Math.Pow(MathExtensions.Cos(R, V), m));
            }

            return Color.FromArgb(ConvertTo256(red), ConvertTo256(green), ConvertTo256(blue));
        }

        private static int ConvertTo256(double color)
        {
            return (int)Math.Round((color < 0 ? 0 : (color > 1 ? 1 : color)) * 255);
        }
    }
}
