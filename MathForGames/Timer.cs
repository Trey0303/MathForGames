using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Transactions;
using static Raylib_cs.Raylib;

namespace MathForGames
{
    public class Timer
    {
        private double preTime = 0.0f;
        private double currentTime = 0.0f;

        private float _deltaTime;
        public float deltaTime
        {
            get
            {
                return _deltaTime;
            }
        }

        public void Update()
        {
            currentTime = GetTime();
            _deltaTime = ((float)(currentTime - preTime));
            preTime = currentTime;

        }

    }
}
