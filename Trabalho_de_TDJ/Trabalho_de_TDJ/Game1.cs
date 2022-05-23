using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Trabalho_de_TDJ
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private LevelManager LevelManager;
        private KeyboardManager km;

        char[,] map;
        const int tileSize = 32;
        int width, height;
        Texture2D dirtTex, grassTex, background;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            km = new KeyboardManager();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(km,_spriteBatch,Content,GraphicsDevice);
            background = Content.Load<Texture2D>("Test_Background");

            grassTex = Content.Load<Texture2D>("Grass_Block");
            dirtTex = Content.Load<Texture2D>("Dirt_Block");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            km.Update();
            player.Move(gameTime);
            player.Jump(km);
            
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            player.Draw();

            //_spriteBatch.Draw(background,new Vector2(0,0),Color.White);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}
