using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IWannaBeTheUkrainian
{
    public class Player
    {
        Texture2D playerTex;
        Vector2 pos;
        KeyboardManager km;
        SpriteBatch spriteBatch;
        GraphicsDevice gd;
        public Player(KeyboardManager km, SpriteBatch spriteBatch, ContentManager content, GraphicsDevice gd)
        {
            this.km = km;
            this.spriteBatch = spriteBatch;
            playerTex = content.Load<Texture2D>("Vadim");
            this.gd = gd;
        }

        public void Move()
        {
            if (km.isKeyHeld(Keys.D))
            {
                pos = pos + new Vector2(1, 0);
            }
            if (km.isKeyHeld(Keys.A))
            {
                pos = pos + new Vector2(-1, 0);
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
