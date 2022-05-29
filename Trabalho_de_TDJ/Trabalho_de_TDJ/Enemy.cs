using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace Trabalho_de_TDJ
{
    class Enemy
    {
        Vector2 enemyPos;
        Vector2 enemyDir = new Vector2(-1,0);

        Texture2D enemyTex;

        SpriteBatch sp;
        ContentManager content;
        GraphicsDevice gd;

        SoundEffect som;
        List<Bullet> balas;

        bool isShootFromEnemy;

        float shootTimer;

        public Enemy(SpriteBatch spritebatch, ContentManager content,SoundEffect som, GraphicsDevice gd)
        {
            sp = spritebatch;
            this.content = content;
            this.som = som;
            this.gd = gd;
            enemyTex = content.Load<Texture2D>("RussianSolder");
            balas = new List<Bullet>();
        }

        public void StartPosition(Vector2 StartPosition)
        {
            enemyPos = StartPosition;
        }

        public void Update(GameTime gm)
        {

        }

        public void Shoot()
        {

        }

        public void Draw()
        {
            sp.Draw(enemyTex,Conversions.ConvertToDraw(enemyPos,gd),Color.White);
            foreach (Bullet b in balas)
            {
                b.Draw();
            }
        }
    }
}
