using System;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
//using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
//using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using MathForGames;

namespace MathRaylib
{
    class Program
    {

        public static int Main()
        {
            Game game = new Game();
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 450;

            InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            SetTargetFPS(60);
            //--------------------------------------------------------------------------------------
            Timer t = new Timer();

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                t.Update();

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(RAYWHITE);

                game.Update();
                game.Draw();
                SetTargetFPS(60);
                InitWindow(640, 480, "Tanks for Everything!");
                game.Init();
                DrawText("time Since Start: " + GetTime().ToString("0.0"), 25, 25, 20, RED);
                DrawText("Delta Time: " + t.deltaTime.ToString("0.0000"), 25, 50, 20, RED);
                DrawText("Congrats! You created your first window!", 190, 200, 20, MAROON);

                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            game.Shutdown();
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
