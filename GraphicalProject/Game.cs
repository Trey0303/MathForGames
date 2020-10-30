﻿using System;
using System.Collections.Generic;
using System.Text;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;
using Raylib_cs;

namespace MathClasses
{

    public class Game
    {
        //create tank and turret sprites from folder using SceneObjest and SpriteObject class
        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();
        SceneObject bulletObject = new SceneObject();

        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();
        SpriteObject bulletSprite = new SpriteObject();

        Timer stopwatch = new Timer();
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;
        private float deltaTime = 0.005f;
        
        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            //load tank sprites
            tankSprite.Load(@"res\tankBlue_outline.png");
            // sprite is facing the wrong way... fix that here
            tankSprite.SetRotate(90 * (float)(Math.PI / 180.0f));
            // sets an offset for the base, so it rotates around the centre
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);
            //load turret sprite
            turretSprite.Load(@"res\barrelBlue.png");
            turretSprite.SetRotate(90 * (float)(Math.PI / 180.0f));
            // set the turret offset from the tank base
            turretSprite.SetPosition(0, turretSprite.Width / 2.0f);
            
            // set up the scene object hierarchy - parent the turret to the base,
            // then the base to the tank sceneObject
            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);
            

            // having an empty object for the tank parent means we can set the
            // position/rotation of the tank without
            // affecting the offset of the base sprite
            tankObject.SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);

        }
        public void Shutdown()
        {
            stopwatch.Reset();
        }
        public void Update()
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
            deltaTime = GetFrameTime();

            //update tank position and rotation
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(
                    //changes which side is treated as the front of the tank
               tankObject.LocalTransform.m1,
               tankObject.LocalTransform.m2, 1) * deltaTime * 100;
                tankObject.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
               Vector3 facing = new Vector3(
                    //changes which side is treated as the back of the tank
                    tankObject.LocalTransform.m1,
                    tankObject.LocalTransform.m2, 1) * deltaTime * -100;
                tankObject.Translate(facing.x, facing.y);
            }
            //update turret position and rotation
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(-deltaTime);
            }
            //fire bullet
            if (IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                

            }
            tankObject.Update(deltaTime);

            lastTime = currentTime;
        }
        public void Draw()
        {
            BeginDrawing();
            ClearBackground(BLACK);
            //draw fps
            DrawText(fps.ToString(), 10, 10, 12, RED);
            //draw tank
            tankObject.Draw();
            
            EndDrawing();
        }

    }
}
