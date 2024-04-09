using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GroundBattle.Classes
{
    internal class Elips
    {
        public static Texture2D BackGround { get; set; }
        static Vector2 vector = Vector2.Zero;
        static Color color = Color.White;

        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackGround, vector, color);
        }

        static public void Update(int delta)
        {
            vector.X += delta;
        }
    }
}
