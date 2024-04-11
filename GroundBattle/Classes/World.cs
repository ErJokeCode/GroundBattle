using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using GroundBattle.Classes;
using System.Collections.Generic;
using System;
using SharpDX.Direct3D9;
using static GroundBattle.Game1;

namespace GroundBattle.Classes
{
    public static class World
    {
        public static int WindowWidth { get; set; }
        public static int WindowHeight { get; set; }
        private static int width;
        public static int Width 
        { 
            get {  return width; } 
            set { width = value - WindowWidth; }
        }
        public static int PositionX {  get; set; }
        public static int LiteralBorder { get; set; }

        public static List<Player> Players = new List<Player>();

        public static List<Elips> elips = new List<Elips>();

        private static int velisityScroll;

        public static void LoadContent()
        {
            WindowWidth = 1920;
            WindowHeight = 1080;
            Width = 3000;
            LiteralBorder = WindowWidth / 10;
            LoadGround();
        }

        private static void LoadGround()
        {
            //Ground.WidthWorld = Width;
            Ground.Gravity = new Vector2(0, 2);
            Ground.Initialize();
        }

        public static void Scroll(int velosity)
        {
            if (velisityScroll == 0)
                velisityScroll = velosity;
            PositionX += velisityScroll;
        }

        public static void NoScroll()
        {
            velisityScroll = 0;
        }

        public static void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            Ground.Draw(spriteBatch);

            elips[0].Draw(spriteBatch);

            foreach (var player in Players)
                player.Draw(spriteBatch);

            
        }

        public static void Update(List<Direction> directs)
        {
            Ground.Update();

            elips[0].Update(-PositionX);

            foreach (var player in Players)
                player.Update(directs);
        }
    }
}
