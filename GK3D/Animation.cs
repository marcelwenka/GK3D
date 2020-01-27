using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GK3D
{
    partial class Form
    {
        double rotation = 0;
        double movementSpeed = 0.1;
        double movementDirection = 1;

        private void Animation(object sender, EventArgs eventArgs)
        {
            isIdle = false;

            actualfps++;

            rotation += 0.01;

            if (rotation > 6.283) // 2PI
            {
                rotation %= 6.283;
            }

            if (models[1].Matrix[1, 3] > 2)
                movementDirection = -1;
            if (models[1].Matrix[1, 3] < -2)
                movementDirection = 1;


            models[1].Matrix[1, 3] += movementDirection * movementSpeed;
            ColorCalculation.lights[1].position[1] += movementDirection * movementSpeed;

            switch (cameraType)
            {
                case CameraType.Fixed:
                    viewMatrix.CameraPosition = ViewMatrix.DefaultCameraPosition;
                    viewMatrix.CameraTarget = Vector<double>.Build.Dense(new double[3] { 0, 0.5, 0.5 });
                    break;
                case CameraType.FollowingMoving:
                    viewMatrix.CameraPosition = ViewMatrix.DefaultCameraPosition + Vector<double>.Build.Dense(new double[3] { models[1].Matrix[0, 3], models[1].Matrix[1, 3], models[1].Matrix[2, 3] });
                    viewMatrix.CameraTarget = Vector<double>.Build.Dense(new double[3] { models[1].Matrix[0, 3], models[1].Matrix[1, 3], models[1].Matrix[2, 3] });
                    break;
                case CameraType.FollowingFixed:
                    viewMatrix.CameraPosition = ViewMatrix.DefaultCameraPosition;
                    viewMatrix.CameraTarget = Vector<double>.Build.Dense(new double[3] { models[1].Matrix[0, 3], models[1].Matrix[1, 3], models[1].Matrix[2, 3] });
                    break;
            }

            models[0].Matrix[0, 0] = Math.Cos(rotation);
            models[0].Matrix[0, 1] = Math.Sin(rotation);
            models[0].Matrix[1, 0] = -Math.Sin(rotation);
            models[0].Matrix[1, 1] = Math.Cos(rotation);

            models[1].Matrix[1, 1] = Math.Cos(5 * rotation);
            models[1].Matrix[1, 2] = Math.Sin(5 * rotation);
            models[1].Matrix[2, 1] = -Math.Sin(5 * rotation);
            models[1].Matrix[2, 2] = Math.Cos(5 * rotation);

            Draw();
        }
    }
}
