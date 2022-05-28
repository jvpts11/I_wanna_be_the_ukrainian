using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_de_TDJ
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        
        private SpriteBatch _spriteBatch;
        private Player player;
        private LevelManager LevelManager;
        private KeyboardManager km;
        
        const int tileSize = 32;
        Texture2D dirtTex, grassTex, tileBackground;
        Vector2 playerpos;
        

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
            LevelManager = new LevelManager(GraphicsDevice, tileSize, Content);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(km,_spriteBatch,Content,GraphicsDevice);

            tileBackground = Content.Load<Texture2D>("Tile_background");
            grassTex = Content.Load<Texture2D>("Grass_Block");
            dirtTex = Content.Load<Texture2D>("Dirt_Block");

            LevelManager.LoadLevel(_graphics,ref playerpos);
            player.StartPos(playerpos);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            km.Update();
            player.Update(gameTime);
            
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.DarkBlue);

            LevelManager.Draw(_spriteBatch);
            player.Draw();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}
