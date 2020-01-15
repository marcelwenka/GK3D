using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK3D
{
    partial class Form
    {
        private void Animation(object sender, EventArgs eventArgs)
        {
            actualfps++;

            i += 0.02;
            i %= 2 * Math.PI;

            if (i < Math.PI)
                models[1].Matrix[1, 3] = +i;
            else
                models[1].Matrix[1, 3] = +2 * Math.PI - i;

            switch (cameraType)
            {
                case CameraType.Fixed:
                    viewMatrix.CameraPosition = ViewMatrix.DefaultCameraPosition;
                    viewMatrix.CameraTarget = Vector<double>.Build.DenseOfArray(new double[3] { 0, 0.5, 0.5 });
                    break;
                case CameraType.FollowingMoving:
                    viewMatrix.CameraPosition = ViewMatrix.DefaultCameraPosition + Vector<double>.Build.DenseOfArray(new double[3] { models[1].Matrix[0, 3], models[1].Matrix[1, 3], models[1].Matrix[2, 3] });
                    viewMatrix.CameraTarget = Vector<double>.Build.DenseOfArray(new double[3] { models[1].Matrix[0, 3], models[1].Matrix[1, 3], models[1].Matrix[2, 3] });
                    break;
                case CameraType.FollowingFixed:
                    viewMatrix.CameraPosition = ViewMatrix.DefaultCameraPosition;
                    viewMatrix.CameraTarget = Vector<double>.Build.DenseOfArray(new double[3] { models[1].Matrix[0, 3], models[1].Matrix[1, 3], models[1].Matrix[2, 3] });
                    break;
            }

            models[0].Matrix[0, 0] = Math.Cos(i);
            models[0].Matrix[0, 1] = Math.Sin(i);
            models[0].Matrix[1, 0] = -Math.Sin(i);
            models[0].Matrix[1, 1] = Math.Cos(i);

            models[1].Matrix[1, 1] = Math.Cos(3 * i);
            models[1].Matrix[1, 2] = Math.Sin(3 * i);
            models[1].Matrix[2, 1] = -Math.Sin(3 * i);
            models[1].Matrix[2, 2] = Math.Cos(3 * i);

            Draw();
        }
    }
}
