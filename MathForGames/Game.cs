using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    public class Game
    {
        Timer stopwatch = new Timer();
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;
        private float deltaTime = 0.005f;
        public static void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;
        }
        public static void Shutdown()
        { }
        public static void Update()
        {
            currentTime = stopwatch.ElapsedMilliseconds;
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
        }
        public static void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.WHITE);
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            EndDrawing();
        }

    }
}
