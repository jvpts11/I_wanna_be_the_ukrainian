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
        private Enemy enemy;
        private LevelManager LevelManager;
        private KeyboardManager km;
        
        const int tileSize = 32;
        Texture2D dirtTex, grassTex, tileBackground;
        Vector2 playerpos;
        Vector2 enemypos;
        List<SoundEffect> efeitos = new List<SoundEffect>(); // Tutorial de som extraído de: https://gamefromscratch.com/monogame-tutorial-audio/

        //Authors: João Tavares, 21871 && Antônio Saraiva 23491

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            km = new KeyboardManager();
            SoundEffect.MasterVolume = 1.0f;
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
            

            tileBackground = Content.Load<Texture2D>("Tile_background");
            grassTex = Content.Load<Texture2D>("Grass_Block");
            dirtTex = Content.Load<Texture2D>("Dirt_Block");

            efeitos.Add(Content.Load<SoundEffect>("jumpSound"));
            efeitos.Add(Content.Load<SoundEffect>("bulletSound"));
            efeitos.Add(Content.Load<SoundEffect>("DoomShotgunSound"));

            player = new Player(km,_spriteBatch,Content,GraphicsDevice, efeitos[0],efeitos[1]);
            enemy = new Enemy(_spriteBatch,Content,efeitos[2],GraphicsDevice);
            LevelManager.LoadLevel(_graphics,ref playerpos,ref enemypos);
            player.StartPos(playerpos);
            enemy.StartPosition(enemypos);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            km.Update();
            player.Update(gameTime);
            enemy.Update(gameTime);
            
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.DarkBlue);

            LevelManager.Draw(_spriteBatch);
            player.Draw();
            enemy.Draw();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}
