using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Trabalho_de_TDJ
{
    public class Player
    {
        Vector2 pos;
        Vector2 initialJumpPos;

        KeyboardManager km;

        SpriteBatch spriteBatch;
        GraphicsDevice gd;

        bool isGrounded = true;
        bool isJumping;
        bool isFalling;

        float JumpTime = 0.3f;
        float timer;

        Texture2D playerTex;

        int MovementVelocity = 4;

        public Player(KeyboardManager km, SpriteBatch spriteBatch, ContentManager content, GraphicsDevice gd)
        {
            this.km = km;
            this.spriteBatch = spriteBatch;
            this.playerTex = content.Load<Texture2D>("Vadim");
            this.gd = gd;
            pos = new Vector2(0, 50);
        }

        public void StartPos(Vector2 StartPosition)
        {
            this.pos = StartPosition;
        }

        public void Move(GameTime gt)
        {
            if (km.isKeyHeld(Keys.Right))
            {
                pos = pos + new Vector2(1, 0) * MovementVelocity;
            }
            if (km.isKeyHeld(Keys.Left))
            {
                pos = pos + new Vector2(-1, 0) * MovementVelocity;
            }
            if (km.isKeyHeld(Keys.X))
            {

            }
            if(timer >= JumpTime)
            {
                isJumping = false;
                isFalling = true;
                timer = 0;
            }
            if (isJumping == true)
            {
                timer += (float)gt.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Jump(KeyboardManager km)
        {
            if (km.IsKeyPressed(Keys.Z))
            {
                initialJumpPos = pos;
                isGrounded = false;
                isJumping = true;
                
            }
            if (isJumping == true)
            {
                pos = pos + new Vector2(0, 5);
                
            }
            if(isFalling == true&&pos == initialJumpPos)
            {
                
            }
            if (isGrounded == false&&isJumping ==false)
            {
                pos = pos + new Vector2(0, -5);
            }

        }

        public void Draw()
        {
            spriteBatch.Draw(playerTex, ConvertToDraw(pos), Color.White);
        }

        public Vector2 ConvertToDraw(Vector2 pos)
        {

            return new Vector2(gd.Viewport.Width / 2 + pos.X, gd.Viewport.Height - pos.Y);
        }
    }
}
