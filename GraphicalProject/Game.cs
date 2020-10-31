using System;
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


        // BULLET
        bool bulletTrue = false;
        
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

            //load turret sprite
            bulletSprite.Load(@"res\bullet.png");
            bulletSprite.SetRotate(90 * (float)(Math.PI / 180.0f));
            // set the turret offset from the tank base
            bulletSprite.SetPosition(turretSprite.Width + 15.0f, turretSprite.Width );

            // set up the scene object hierarchy - parent the turret to the base,
            // then the base to the tank sceneObject
            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);

            bulletObject.AddChild(bulletSprite);
            

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
                if(bulletTrue == false)
                {
                    bulletObject.Rotate(deltaTime);
                }
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(-deltaTime);
                if (bulletTrue == false)
                {
                    bulletObject.Rotate(-deltaTime);
                }
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
               Vector3 facing = new Vector3(
                    //changes which side is treated as the front of the tank
                    tankObject.LocalTransform.m1,
                    tankObject.LocalTransform.m2, 1) * deltaTime * 100;
               tankObject.Translate(facing.x, facing.y);

                if (bulletTrue == false)
                {
                    bulletObject.Translate(facing.x, facing.y);
                }
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
               Vector3 facing = new Vector3(
                    //changes which side is treated as the back of the tank
                    tankObject.LocalTransform.m1,
                    tankObject.LocalTransform.m2, 1) * deltaTime * -100;
                tankObject.Translate(facing.x, facing.y);

                if (bulletTrue == false)
                {
                    bulletObject.Translate(facing.x, facing.y);
                }
            }
            //update turret position and rotation
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(deltaTime);
                if (bulletTrue == false)
                {
                    bulletObject.Rotate(deltaTime);
                }
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(-deltaTime);
                if (bulletTrue == false)
                {
                    bulletObject.Rotate(-deltaTime);
                }
            }
            //fire bullet
            if (IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                bulletTrue = true;

                // take the forward vector of the tank - its orientation
                // convert that into an angle
                // apply that angle as a rotation on the bullet

                // OR

                // copy the rotation directly from the transform of the tank (bypass SetRotate and access the mX directly)

                // TODO: rotate the bullet so it fires with the same orientation as the barrel of the tank

                //bulletObject.Rotate();
                //float bulletRotate = tankObject.GlobalTransform.m1 /2, tankObject.GlobalTransform.m2 / 2;
                //bulletObject.SetRotate(tankObject.);

                // TODO: reposition the bullet so it fires from where it needs to start from
                bulletObject.SetPosition(tankObject.GlobalTransform.m7, tankObject.GlobalTransform.m8);
            }

            

            tankObject.Update(deltaTime);
            if(bulletTrue)
            {
                bulletObject.Translate(bulletObject.LocalTransform.m1, bulletObject.LocalTransform.m2);


                //TODO: eventually disable bullet and make it ready to fire
                if (bulletObject.LocalTransform.m7 >= 800 || bulletObject.LocalTransform.m8 >= 450)
                {
                    bulletTrue = false;
                }
                else if(bulletObject.LocalTransform.m7 <= 0 || bulletObject.LocalTransform.m8 <= 0)
                {
                    bulletTrue = false;
                }
            }

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

            if(bulletTrue)
            {
                bulletObject.Draw();
            }


            EndDrawing();
        }

    }
}
