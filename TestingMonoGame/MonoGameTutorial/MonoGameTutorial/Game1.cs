using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameTutorial
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D TargetSprite;
        Texture2D CrossHairsSrpite;
        Texture2D BackGroundSprite;

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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(BackGroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(TargetSprite, new Vector2(0,0), Color.White);
            _spriteBatch.Draw(CrossHairsSrpite, new Vector2(100, 0), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
