using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Trabalho_de_TDJ
{
    class Rickroll
    {

        Texture2D RickAstley;
        GraphicsDevice gd;
        ContentManager Content;
        SpriteBatch sb;
        Song NeverGonnaGiveYouUp;
        

        public Rickroll(ContentManager Content, SpriteBatch sb)
        {
            this.Content = Content;
            this.sb = sb;
            RickAstley = Content.Load<Texture2D>("rickastley");
            NeverGonnaGiveYouUp = Content.Load<Song>("Rick_Astley_Never_Gonna_Give_You_Up");
        }

        public void playRickroll()
        {
            MediaPlayer.Volume = 1.0f;
            MediaPlayer.Play(NeverGonnaGiveYouUp);
            
        }

        public void DrawRickRoll()
        {
            sb.Draw(RickAstley,new Vector2(15,60),Color.White);
        }

        
    }
}
