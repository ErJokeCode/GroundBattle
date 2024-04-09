using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using static GroundBattle.Game1;

namespace GroundBattle.Classes
{
    public class Player
    {
        public Vector2 NowPosition { get; set; }
        public readonly int Speed;

        private Texture2D backGround;
        private Color color = Color.White;
        private int literalBorder;

        private int widthWindow = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

        public Player(Texture2D backGround, int startPosX, int speed, int freedomArea) 
        {
            this.backGround = backGround;
            this.Speed = speed;
            literalBorder = (widthWindow - freedomArea) / 2;
            NowPosition = new Vector2(startPosX, Ground.Top - 500);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, NowPosition, color);
        }

        public void Update(Direction direction)
        {
            float posY = NowPosition.Y;
            float posX = NowPosition.X;

            if (direction == Direction.Down && Ground.Top > NowPosition.Y + backGround.Height)
            {
                posY += Speed;
            }
            else if (direction == Direction.Left && posX > 0)
            {
                if (Ground.PositionX != 0 && posX < literalBorder)
                    Ground.PositionX -= Speed;
                else
                    posX -= Speed;
            } 
            else if (direction == Direction.Right && posX < widthWindow - backGround.Width)
            {
                if (Ground.PositionX != Ground.WidthWorld && posX >= widthWindow - literalBorder)
                    Ground.PositionX += Speed;
                else
                    posX += Speed;
            }

            NowPosition = new Vector2(posX, posY);
        }
    }
}
