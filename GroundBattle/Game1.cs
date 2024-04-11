using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using GroundBattle.Classes;
using System;

namespace GroundBattle
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch;

        public enum Direction
        {
            Empty,
            Right, 
            Left, 
            Up,
            Down
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;

            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);


            World.LoadContent();
            

            var player1 = new Player(Content.Load<Texture2D>("Player"), 1000, 10, 2, 30);
            var player2 = new Player(Content.Load<Texture2D>("Player"), 500, 30, 2, 30);
            Ground.BackGround = Content.Load<Texture2D>("Ground");

            var el = new Elips();
            el.BackGround = Content.Load<Texture2D>("Ellipse");
            World.Players.Add(player1);
            World.Players.Add(player2);
            World.elips.Add(el);
        }

        protected override void Update(GameTime gameTime)
        {
            var directs = new System.Collections.Generic.List<Direction>();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                directs.Add(Direction.Right); 
            }   
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                directs.Add(Direction.Left);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                directs.Add(Direction.Up);
            }

            
            World.Update(directs);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            World.Draw(_spriteBatch);
            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}