using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GroundBattle.Classes
{
    internal class Ground
    {
        public static Texture2D BackGround { get; set; }
        static int pos;
        static Rectangle rect = new Rectangle(pos, 150, 1440, 150);
        static Vector2 vec = new Vector2(pos, 880);
        static Color color = Color.White;

        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackGround, vec, rect, Color.White, 0, Vector2.Zero,
                1, SpriteEffects.None, 0);
        }

        static public void Update(int delta)
        {
            if (pos + delta >= 0 && pos + delta <= 3000)
                pos += delta;
            rect = new Rectangle(pos % 1440, 150, 1440, 150);
        }
    }
}
