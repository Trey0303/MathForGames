using System;
using System.Collections.Generic;
using System.Text;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using MathClasses;
using Raylib_cs;

namespace MathClasses
{
    class SpriteObject : SceneObject
    {
        Texture2D texture = new Texture2D();
        Image image = new Image();
        public float Width
        {
            get { return texture.width; }
        }
        public float Height
        {
            get { return texture.height; }
        }
        public SpriteObject()
        {
        }
        public void Load(string filename)
        {
            //loads tank image
            Image img = LoadImage(filename);
            texture = LoadTextureFromImage(img);
        }
        public override void OnDraw()
        {
            //tank rotation
            float rotation = (float)Math.Atan2( globalTransform.m2, globalTransform.m1);
            //DrawTextureEx(Texture2D texture, Vector2 position, float rotation, float scale, Color tint);
            DrawTextureEx(texture, new Vector2(globalTransform.m7, globalTransform.m8), rotation * (float)(180.0f / Math.PI), 
                1, WHITE);
            
        }
    }
}
