﻿using System;
using System.Collections.Generic;
using System.Text;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using MathForGamesF;

namespace MathForGamesF
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
            Image img = LoadImage(filename);
            texture = LoadTextureFromImage(img);
        }
        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(
           globalTransform.m2, globalTransform.m1);
            Raylib.Raylib.DrawTextureEx(
            texture,
            new Vector2(globalTransform.m7, globalTransform.m8),
            rotation * (float)(180.0f / Math.PI),
            1, Color.WHITE);
        }
    }
}
