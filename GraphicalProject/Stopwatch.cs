using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace MathForGamesF
{
    public class Stopwatch
    {
        //Stopwatch stopwatch = new Stopwatch();
        private long currentTime = 0;
        private long lastTime = 0;
        private int fps = 1;
        private int frames;
        private float deltaTime = 0.005f;

        public long ElapsedMilliseconds { get; private set; }

        public void Start()
        {

        }

        public void Reset(){

        }
        public void Update()
        {
            currentTime =
            ElapsedMilliseconds;
            if (currentTime - lastTime >= 1000)
            {
                fps = frames;
                frames = 0;
                lastTime = currentTime;
            }
            frames++;
            deltaTime = currentTime - lastTime;
        }
    }
}
