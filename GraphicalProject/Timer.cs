using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Transactions;
using static Raylib_cs.Raylib;

namespace MathForGamesF
{
    public class Timer
    {
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float deltaTime = 0.005f;
        public Timer()
        {
            stopwatch.Start();
        }
        public void Restart()
        {
            stopwatch.Restart();
        }
        public float Seconds
        {
            get { return stopwatch.ElapsedMilliseconds / 1000.0f; }
        }
        public float GetDeltaTime()
        {
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            return deltaTime;
        }

        //private double preTime = 0.0f;
        //private double currentTime = 0.0f;

        //private float _deltaTime;
        //public float deltaTime
        //{
        //    get
        //    {
        //        return _deltaTime;
        //    }
        //}

        //public float Seconds
        //{
        //    get { return stopwatch.ElapsedMilliseconds / 1000.0f; }
        //}

        //public void Update()
        //{
        //    //currentTime = GetTime();
        //    //_deltaTime = ((float)(currentTime - preTime));
        //    //preTime = currentTime;



        //}

    }
}
