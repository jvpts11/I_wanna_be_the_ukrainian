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

        KeyboardManager km;

        SpriteBatch spriteBatch;
        GraphicsDevice gd;

        Texture2D playerTex;

        int MovementVelocity = 4;

        public Player(KeyboardManager km,SpriteBatch spriteBatch,ContentManager content,GraphicsDevice gd)
        {
            this.km = km;
            this.spriteBatch = spriteBatch;
            this.playerTex = content.Load<Texture2D>("Vadim");
            this.gd = gd;
            pos = new Vector2(0,50);
        }

        public void StartPos(Vector2 StartPosition)
        {
            this.pos = StartPosition;
        }

        public void Move()
        {
            if (km.isKeyHeld(Keys.Left))
            {
                pos = pos + new Vector2(1, 0) * MovementVelocity;
            }
            if (km.isKeyHeld(Keys.Right))
            {
                pos = pos + new Vector2(-1, 0) * MovementVelocity;
            }
            if (km.isKeyHeld(Keys.X))
            {

            }
        }

        public void Jump(KeyboardManager km)
        {
            
        }

        public void Draw()
        {
            spriteBatch.Draw(playerTex, ConvertToDraw(pos), Color.White);
        }

        public Vector2 ConvertToDraw(Vector2 pos)
        {
            
            return new Vector2(gd.Viewport.Width / 2 + pos.X,gd.Viewport.Height - pos.Y);
        }
    }
}
