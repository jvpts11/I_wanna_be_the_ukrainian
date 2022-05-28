using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Trabalho_de_TDJ
{
    static class Conversions
    {

        public static Vector2 ConvertToDraw(Vector2 pos, GraphicsDevice gd)
        {

            return new Vector2(gd.Viewport.Width / 2 + pos.X, gd.Viewport.Height / 2 - pos.Y + 45);

        }
    }
}
