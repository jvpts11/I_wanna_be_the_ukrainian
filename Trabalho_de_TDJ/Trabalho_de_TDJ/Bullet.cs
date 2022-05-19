using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_de_TDJ
{
    public class Bullet
    {
        Vector2 bulPos;

        KeyboardManager km;
        SpriteBatch spritebatch;
        GraphicsDevice gd;

        Texture2D bultex;

        int bulvel = 4;

        public Bullet(KeyboardManager km, SpriteBatch spriteBatch, ContentManager content, GraphicsDevice gd)
        {
            this.km = km;
            this.spritebatch = spriteBatch;
            bultex = content.Load<Texture2D>("Bullet");
            this.gd = gd;

        }

        public void Shoot()
        {
            if (km.IsKeyPressed(Keys.Space))
            {
                bulPos = bulPos + new Vector2(1,0)* bulvel;
            }
        }

        public void Draw()
        {

        }
    }
}
