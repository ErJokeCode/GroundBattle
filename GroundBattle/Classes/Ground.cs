using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GroundBattle.Classes
{
    class Ground
    {
        public static Texture2D BackGround { get; set; }

        private static int widthWindow = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private static int heightWindow = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        private static int heightGround = 150;
        private static int lenOneSprite = 1440;

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

        public static int Top
        {
            get { return heightWindow - heightGround; }
        }

        private static int positionX;
        private static Rectangle rect = new Rectangle(positionX, heightGround, widthWindow, heightGround);
        private static Vector2 vec = new Vector2(positionX, Top);
        private static Color color = Color.White;

        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackGround, vec, rect, color);
        }

        static public void Update(int delta)
        {
            if (positionX + delta >= 0 && positionX + delta <= widthWorld)
                positionX += delta;
            rect = new Rectangle(positionX % lenOneSprite, heightGround, widthWindow, heightGround);
        }
    }
}
