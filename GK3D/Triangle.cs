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
        public Color color;

        public Triangle(Vertex _p1, Vertex _p2, Vertex _p3, Color c)
        {
            points = new Vertex[3] { _p1, _p2, _p3 };
            color = c;
        }

        public double Z(int x, int y)
        {
            double denominator = (points[1].Y - points[2].Y) * (points[0].X - points[2].X) + (points[2].X - points[1].X) * (points[0].Y - points[2].Y);
            var w0 = ((points[1].Y - points[2].Y) * (x - points[2].X) + (points[2].X - points[1].X) * (y - points[2].Y)) / denominator;
            var w1 = ((points[2].Y - points[0].Y) * (x - points[2].X) + (points[0].X - points[2].X) * (y - points[2].Y)) / denominator;
            var w2 = 1 - w1 - w0;

            return (w0 * points[0].Z + w1 * points[1].Z + w2 * points[2].Z);

            var distances = new double[3]
            {
                Vertex.Dist(points[0], x, y),
                Vertex.Dist(points[1], x, y),
                Vertex.Dist(points[2], x, y)
            };

            var weights = new double[3]
            {
                //distances[1] * distances[2],
                //distances[0] * distances[2],
                //distances[0] * distances[1]
                1 / distances[0],
                1 / distances[1],
                1 / distances[2]
            };

            double sum = weights.Sum();

            return (points[0].Z * weights[0] + points[1].Z * weights[1] + points[2].Z * weights[2]) / sum;
        }

        public int[] GetSortedIndexes()
        {
            var indexes = new int[3];

            if (points[0].Y < points[1].Y)
            {
                if (points[0].Y < points[2].Y)
                {
                    indexes[0] = 0;

                    if (points[1].Y < points[2].Y)
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
                if (points[1].Y < points[2].Y)
                {
                    indexes[0] = 1;

                    if (points[0].Y < points[2].Y)
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

            if (_p1.Y > _p2.Y)
            {
                p1 = _p2;
                p2 = _p1;
            }
            else
            {
                p1 = _p1;
                p2 = _p2;
            }

            x = p1.X;

            xd = _p1.Y - _p2.Y != 0 ? (float)(_p1.X - _p2.X) / (_p1.Y - _p2.Y) : 0;
        }
    }
}
