using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameTutorial
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D TargetSprite;
        Texture2D CrossHairsSrpite;
        Texture2D BackGroundSprite;
        SpriteFont GameFont;

        Vector2 TargetsPosition = new Vector2(30, 200);
        Vector2 CrossHairPosition = new Vector2(30, 200);
        const int TargetRadius = 45;

        int RandomCaller = 0;
        Random TargetRandomXPosition = new Random(185481);
        Random TargetRandomYPosition = new Random(754154);

        int Score = 0;

        MouseState MState;
        bool IsMouseReleased = false;

        int CrossHairTimer = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            TargetSprite = Content.Load<Texture2D>("target");
            CrossHairsSrpite = Content.Load<Texture2D>("crosshairs");
            BackGroundSprite = Content.Load<Texture2D>("sky");

            GameFont = Content.Load<SpriteFont>("galleryFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MState = Mouse.GetState();

            if (MState.LeftButton == ButtonState.Released)
            {
                IsMouseReleased = true;
            }
            if (IsMouseReleased && MState.LeftButton == ButtonState.Pressed)
            {
                CrossHairPosition.X = MState.Position.X - 25;
                CrossHairPosition.Y = MState.Position.Y - 25;
                IsMouseReleased = false;
                CrossHairTimer = 0;
                TargetMouseCollision();
            }

            if (RandomCaller >= 60)
            {
                RandomizeTargetLocation();
                RandomCaller = 0;
            }

            RandomCaller++;
            base.Update(gameTime);
        }

        private bool TargetMouseCollision()
        {
            float mouseTargetDist = Vector2.Distance(TargetsPosition, MState.Position.ToVector2());
            if(mouseTargetDist < TargetRadius)
            {
                Score++;
                RandomizeTargetLocation();
                return true;
            }
            return false;
        }
        private void RandomizeTargetLocation()
        {
            TargetsPosition.X = TargetRandomXPosition.Next(0, _graphics.PreferredBackBufferWidth);
            TargetsPosition.Y = TargetRandomYPosition.Next(0, _graphics.PreferredBackBufferHeight);
            RandomCaller = 0;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(BackGroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(GameFont, "Score: " + Score, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(TargetSprite, new Vector2(TargetsPosition.X - 45, TargetsPosition.Y - 45), Color.White);
            if (CrossHairTimer < 30 )
            {
                _spriteBatch.Draw(CrossHairsSrpite, CrossHairPosition, Color.White);
                CrossHairTimer++;
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
