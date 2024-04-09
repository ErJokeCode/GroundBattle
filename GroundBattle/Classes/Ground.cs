using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GroundBattle.Classes
{
    public class Ground
    {
        public static Texture2D BackGround;
        public static int PositionX { get; set; }

        private static int widthWorld;
        public static int WidthWorld
        {
            get { return widthWorld; }
            set
            {
                if (value - widthWindow < 0)
                    widthWorld = 0;
                else
                    widthWorld = value - widthWindow;
            }
        }

        private static int widthWindow = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private static int heightWindow = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        private static int heightGround = 150;
        private static int lenOneSprite = 1440;

        private static Color color = Color.White;
        private static Rectangle rect = new Rectangle(PositionX, heightGround, widthWindow, heightGround);
        private static Vector2 vec = new Vector2(PositionX, Top);

        public static int Top { get { return heightWindow - heightGround; } }

        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackGround, vec, rect, color);
        }

        static public void Update()
        {
            rect = new Rectangle(PositionX % lenOneSprite, heightGround, widthWindow, heightGround);
        }
    }
}
