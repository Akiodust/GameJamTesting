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
        const int TargetRadius = 45;

        int RandomCaller = 0;
        Random TargetRandomXPosition = new Random(185481);
        Random TargetRandomYPosition = new Random(754154);

        int Score = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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

            // TODO: Add your update logic here
            if (RandomCaller == 120)
            {
                TargetsPosition.X = TargetRandomXPosition.Next(0, 650);
                TargetsPosition.Y = TargetRandomYPosition.Next(0, 320);
                RandomCaller = 0;
            }

            RandomCaller++;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(BackGroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(GameFont, "Score: " + Score, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(TargetSprite, TargetsPosition, Color.White);
            _spriteBatch.Draw(CrossHairsSrpite, new Vector2(150, 0), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
