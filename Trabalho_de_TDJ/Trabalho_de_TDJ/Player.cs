using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Trabalho_de_TDJ
{
    public class Player
    {
        Vector2 pos;
        Vector2 playerdirection = new Vector2(1,0);

        KeyboardManager km;

        SpriteBatch spriteBatch;
        GraphicsDevice gd;

        bool isGrounded = true;
        bool isJumping;

        float JumpTime = 0.3f;
        float timer;

        Texture2D playerTex;

        Rickroll lol;
        List<Bullet> balas;
        SoundEffect pulo, bala;

        int MovementVelocity = 4;
        private ContentManager content;

        public Player(KeyboardManager km, SpriteBatch spriteBatch, ContentManager content, GraphicsDevice gd,SoundEffect som,SoundEffect bala)
        {
            this.km = km;
            this.spriteBatch = spriteBatch;
            this.playerTex = content.Load<Texture2D>("Vadim");
            this.gd = gd;
            this.content = content;
            balas = new List<Bullet>();
            pulo = som;
            this.bala = bala;
        }

        public void StartPos(Vector2 StartPosition)
        {
            this.pos = StartPosition;
        }

        public void Update(GameTime gm)
        {
            Move(gm);
            Jump();
            Shoot();
            foreach (Bullet b in balas)
            {
                b.Update();
            }
        }

        public void Move(GameTime gt)
        {
            if (km.isKeyHeld(Keys.Right))
            {
                pos = pos + new Vector2(1, 0) * MovementVelocity;
                playerdirection = new Vector2(1,0);
            }
            if (km.isKeyHeld(Keys.Left))
            {
                pos = pos + new Vector2(-1, 0) * MovementVelocity;
                playerdirection = new Vector2(-1,0);
            }
            if (km.isKeyHeld(Keys.R))
            {
                lol = new Rickroll(content, spriteBatch);
                lol.playRickroll();
            }
            if(timer >= JumpTime)
            {
                isJumping = false;
                timer = 0;
            }
            if(pos.Y <= 0)
            {
                pos.Y = 0;
                isGrounded = true;
            }
            if (isJumping == true)
            {
                timer += (float)gt.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Shoot()
        {
            if (km.IsKeyPressed(Keys.Space))
            {
                bala.CreateInstance().Play();
                Bullet bullet = new Bullet(km, spriteBatch, content, gd,playerdirection, pos);
                balas.Add(bullet);
            }
        }

        public void Jump()
        {
            if (km.IsKeyPressed(Keys.Z))
            {
                pulo.CreateInstance().Play();
                isGrounded = false;
                isJumping = true;
                
            }
            if (isJumping == true)
            {
                pos = pos + new Vector2(0, 5);
                
            }
            if (isGrounded == false&&isJumping ==false)
            {
                pos = pos + new Vector2(0, -5);
            }

        }

        public void Draw()
        {
            spriteBatch.Draw(playerTex, Conversions.ConvertToDraw(pos,gd), Color.White);
            Vector2 coisa = Conversions.ConvertToDraw(pos,gd);
            foreach (Bullet b in balas)
            {
                b.Draw();
            }
            if(lol != null)
            {
                lol.DrawRickRoll();
            }
        }
    }
}
