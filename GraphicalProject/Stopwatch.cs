using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace MathClasses
{
    public class Stopwatch
    {
        //Stopwatch stopwatch = new Stopwatch();
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
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
            currentTime = ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;
            lastTime = currentTime;



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
