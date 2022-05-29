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
        bool hasShooted;

        float Timer;
        float shootTime = 1.2f;

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

        public void Update(GameTime gt)
        {
            ShootTiming(gt);
            foreach (Bullet b in balas)
            {
                b.Update();
            }
        }
        public void ShootTiming(GameTime gt)
        {
            if(Timer == 0 && hasShooted == false)
            {
                hasShooted = true;
                Shoot();
            }
            if (hasShooted == true)
            {
                Timer += (float)gt.ElapsedGameTime.TotalSeconds;
            }
            if (Timer >= shootTime)
            {
                hasShooted = false;
                Timer = 0;
            }

        }

        public void Shoot()
        {
            som.CreateInstance().Play();
            Bullet bala = new Bullet(sp,content,gd,enemyDir,enemyPos);
            balas.Add(bala);
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
