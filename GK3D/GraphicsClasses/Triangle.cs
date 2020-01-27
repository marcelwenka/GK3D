using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    public class Triangle
    {
        public Vertex[] points;

        public Triangle(Vertex _p1, Vertex _p2, Vertex _p3)
        {
            points = new Vertex[3] { _p1, _p2, _p3 };
        }

        public (double, double, double) GetWeights(int x, int y)
        {
            double denominator = (points[1].projectionY - points[2].projectionY) * (points[0].projectionX - points[2].projectionX) + (points[2].projectionX - points[1].projectionX) * (points[0].projectionY - points[2].projectionY);
            var w0 = ((points[1].projectionY - points[2].projectionY) * (x - points[2].projectionX) + (points[2].projectionX - points[1].projectionX) * (y - points[2].projectionY)) / denominator;
            var w1 = ((points[2].projectionY - points[0].projectionY) * (x - points[2].projectionX) + (points[0].projectionX - points[2].projectionX) * (y - points[2].projectionY)) / denominator;
            var w2 = 1 - w1 - w0;

            return (w0, w1, w2);
        }

        public double Z(double w0, double w1, double w2)
        {
            return w0 * points[0].projectionZ + w1 * points[1].projectionZ + w2 * points[2].projectionZ;
        }

        public double[] interpolateXYZ(double w0, double w1, double w2)
        {
            return new double[3]
            {
                w0 * points[0].worldX + w1 * points[1].worldX + w2 * points[2].worldX,
                w0 * points[0].worldY + w1 * points[1].worldY + w2 * points[2].worldY,
                w0 * points[0].worldZ + w1 * points[1].worldZ + w2 * points[2].worldZ
            };
        }

        public Vector<double> interpolateN(double w0, double w1, double w2)
        {
            return w0 * points[0].N + w1 * points[1].N + w2 * points[2].N;
        }

        public int[] GetSortedIndexes()
        {
            var indexes = new int[3];

            if (points[0].projectionY < points[1].projectionY)
            {
                if (points[0].projectionY < points[2].projectionY)
                {
                    indexes[0] = 0;

                    if (points[1].projectionY < points[2].projectionY)
                    {
                        indexes[1] = 1;
                        indexes[2] = 2;
                    }
                    else
                    {
                        indexes[1] = 2;
                        indexes[2] = 1;
                    }
                }
                else
                {
                    indexes[0] = 2;
                    indexes[1] = 0;
                    indexes[2] = 1;
                }
            }
            else
            {
                if (points[1].projectionY < points[2].projectionY)
                {
                    indexes[0] = 1;

                    if (points[0].projectionY < points[2].projectionY)
                    {
                        indexes[1] = 0;
                        indexes[2] = 2;
                    }
                    else
                    {
                        indexes[1] = 2;
                        indexes[2] = 0;
                    }
                }
                else
                {
                    indexes[0] = 2;
                    indexes[1] = 1;
                    indexes[2] = 0;
                }
            }

            return indexes;
        }

        public static int prev(int k)
        {
            return k - 1 < 0 ? 2 : k - 1;
        }

        public static int next(int k)
        {
            return k + 1 > 2 ? 0 : k + 1;
        }
    }

    public class AETNode
    {
        public float x;
        public float xd;
        public Vertex p1;
        public Vertex p2;

        public AETNode(Vertex _p1, Vertex _p2)
        {

            if (_p1.projectionY > _p2.projectionY)
            {
                p1 = _p2;
                p2 = _p1;
            }
            else
            {
                p1 = _p1;
                p2 = _p2;
            }

            x = p1.projectionX;

            xd = _p1.projectionY - _p2.projectionY != 0 ? (float)(_p1.projectionX - _p2.projectionX) / (_p1.projectionY - _p2.projectionY) : 0;
        }
    }
}
