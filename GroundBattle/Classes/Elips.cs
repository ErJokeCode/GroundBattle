using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GroundBattle.Classes
{
    public class Elips
    {
        public Texture2D BackGround { get; set; }
        static Vector2 vector = Vector2.Zero;
        static Color color = Color.White;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackGround, vector, color);
        }

        public void Update(int delta)
        {
            vector.X = delta;
        }
    }
}
