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

        Vector2 direction;


        int bulvel = 6;

        public Bullet(KeyboardManager km, SpriteBatch spriteBatch, ContentManager content, GraphicsDevice gd, Vector2 direction, Vector2 playerpos)
        {
            this.km = km;
            this.spritebatch = spriteBatch;
            bultex = content.Load<Texture2D>("Bullet");
            this.gd = gd;
            this.direction = direction;
            bulPos = playerpos;
        }

        public Bullet(SpriteBatch spriteBatch, ContentManager content, GraphicsDevice gd, Vector2 direction, Vector2 enemypos)
        {
            spritebatch = spriteBatch;
            bultex = content.Load<Texture2D>("Bullet");
            this.gd = gd;
            this.direction = direction;
            bulPos = enemypos;
        }

        public void Update()
        {
            bulPos = bulPos + direction* bulvel;
        }

        public void Draw()
        {
            
            spritebatch.Draw(bultex,Conversions.ConvertToDraw(bulPos,gd),Color.White);
        }
    }
}
