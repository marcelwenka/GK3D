using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GK3D
{
    public static class ColorCalculation
    {
        public static double ka = 0.2;
        public static double kd = 0.7;
        public static double ks = 1;
        public static int m = 8;
        public static int p = 30;

        public static Vector<double> cameraPosition;

        public static List<Light> lights;

        public static Color Phong(Vector<double> coordinates, Vector<double> N, Color color)
        {
            double red = ka * color.R;
            double green = ka * color.G;
            double blue = ka * color.B;

            foreach (var light in lights)
            {
                var L = (light.actualPosition - coordinates).Normalize(2);
                var V = (cameraPosition - coordinates).Normalize(2);
                var R = (2 * MathExtensions.Cos(N, L) * N - L).Normalize(2);

                var diffusedCosine = MathExtensions.Cos(N, L);
                var specularCosine = Positive(MathExtensions.Cos(R, V));
                var lightCulaculations = kd * diffusedCosine + ks * Math.Pow(specularCosine, m);

                var multiplier = 1.0;

                if (light.type == LightType.Spot)
                {
                    var spotCos = MathExtensions.Cos(L, light.direction);
                    if (spotCos > 0)
                        multiplier = Math.Pow(spotCos, p);
                    else
                        multiplier = 0;
                }

                red += multiplier * color.R * light.color.R / 255.0 * lightCulaculations;
                green += multiplier * color.G * light.color.G / 255.0 * lightCulaculations;
                blue += multiplier * color.B * light.color.B / 250.0 * lightCulaculations;
            }

            return Color.FromArgb(Trim(red), Trim(green), Trim(blue));
        }

        private static double Positive(double value)
        {
            return value < 0 ? 0 : value;
        }

        public static Color Gouraud(Color[] colors, Triangle triangle)
        {
            double red = triangle.w0 * colors[0].R + triangle.w1 * colors[1].R + triangle.w2 * colors[2].R;
            double green = triangle.w0 * colors[0].G + triangle.w1 * colors[1].G + triangle.w2 * colors[2].G;
            double blue = triangle.w0 * colors[0].B + triangle.w1 * colors[1].B + triangle.w2 * colors[2].B;

            return Color.FromArgb(Trim(red), Trim(green), Trim(blue));
        }

        private static int Trim(double color)
        {
            return (int)Math.Round(color < 0 ? 0 : (color > 255 ? 255 : color));
        }
    }
}
