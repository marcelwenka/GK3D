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
        public double rotationSpeed = 0;
        public double movementSpeed = 0.01;
        public double movementDirection = 1;

        private void Animation(object sender, EventArgs eventArgs)
        {
            isIdle = false;

            actualfps++;

            rotationSpeed += 0.01;

            if (rotationSpeed > 6.283)
            {
                rotationSpeed %= 6.283;
                movementDirection *= -1;
            }

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

            models[0].Matrix[0, 0] = Math.Cos(rotationSpeed);
            models[0].Matrix[0, 1] = Math.Sin(rotationSpeed);
            models[0].Matrix[1, 0] = -Math.Sin(rotationSpeed);
            models[0].Matrix[1, 1] = Math.Cos(rotationSpeed);

            models[1].Matrix[1, 1] = Math.Cos(5 * rotationSpeed);
            models[1].Matrix[1, 2] = Math.Sin(5 * rotationSpeed);
            models[1].Matrix[2, 1] = -Math.Sin(5 * rotationSpeed);
            models[1].Matrix[2, 2] = Math.Cos(5 * rotationSpeed);

            Draw();
        }
    }
}
