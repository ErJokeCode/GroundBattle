using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace GroundBattle.Classes
{
    class Player
    {
        public static Texture2D BackGround { get; set; }

        static Vector2 nowPosition = new Vector2(500, Ground.Top - 300);
        static Color color = Color.White;


        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackGround, nowPosition, color);
        }

        static public void Update()
        {
            if (Ground.Top > nowPosition.Y + BackGround.Height)
                nowPosition = new Vector2(nowPosition.X, nowPosition.Y + 10);
        }
    }
}
