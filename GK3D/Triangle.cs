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
        public Point[] points;

        public Triangle(Point _p1, Point _p2, Point _p3)
        {
            points = new Point[3] { _p1, _p2, _p3 };
        }

        public void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, points[0].X, points[0].Y, points[1].X, points[1].Y);
            g.DrawLine(pen, points[1].X, points[1].Y, points[2].X, points[2].Y);
            g.DrawLine(pen, points[2].X, points[2].Y, points[0].X, points[0].Y);
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
        public int ymax;
        public float x;
        public float xd;
        public Point p1;
        public Point p2;

        public AETNode(Point _p1, Point _p2)
        {
            p1 = _p1;
            p2 = _p2;

            if (_p1.Y > _p2.Y)
            {
                x = _p2.X;
                ymax = _p1.Y;
            }
            else
            {
                x = _p1.X;
                ymax = _p2.Y;
            }

            xd = _p1.Y - _p2.Y != 0 ? (float)(_p1.X - _p2.X) / (_p1.Y - _p2.Y) : 0;
        }
    }
}
