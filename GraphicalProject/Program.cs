﻿/*******************************************************************************************
*
*   raylib [core] example - Basic window
*
*   Welcome to raylib!
*
*   To test examples, just press F6 and execute raylib_compile_execute script
*   Note that compiled executable is placed in the same folder as .c file
*
*   You can find all basic examples on C:\raylib\raylib\examples folder or
*
*   Enjoy using raylib. :)
*
*   This example has been created using raylib-cs 3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   This example was lightly modified to provide additional 'using' directives to make
*   common math types and utilities readily available, though they are not using in this sample.
*
*   Copyright (c) 2019-2020 Academy of Interactive Entertainment (@aie_usa)
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
//using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
//using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using MathClasses;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace GraphicalProject
{
    public class core_basic_window
    {
        public static int Main()
        {
            Game game = new Game();
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 450;
            

            //InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
            InitWindow(screenWidth, screenHeight, "Tanks for Everything!");
            SetTargetFPS(60);
            
            //--------------------------------------------------------------------------------------

            
            game.Init();

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------
                

                // Draw
                //----------------------------------------------------------------------------------

                game.Update();
                game.Draw();

                //EndDrawing();
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
