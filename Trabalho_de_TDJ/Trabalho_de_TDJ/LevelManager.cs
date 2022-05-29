using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Trabalho_de_TDJ
{
    public class LevelManager
    {

        string[] LevelPath = { "testlevel.txt"};
        int LevelNumber, tileSize;

        GraphicsDevice gd;
        ContentManager content;
        Texture2D grassTex;
        Texture2D dirtTex;

        int height, width;

        char[,] map;

        public LevelManager(GraphicsDevice gd, int tileSize, ContentManager Content)
        {
            this.gd = gd;
            this.tileSize = tileSize;

            grassTex = Content.Load<Texture2D>("Grass_Block");
            dirtTex = Content.Load<Texture2D>("Dirt_Block");
        }

        public void NextLevel(int height, int width, GraphicsDeviceManager gdm ,char[,] map, ref Vector2 playerPos, ref Vector2 enemyPos)
        {
            LevelNumber++;
            LoadLevel(gdm, ref playerPos, ref enemyPos);
        }

        public Vector2 ConvertToWorld(Vector2 pos)
        {
            pos.X = -gd.Viewport.Width /2 + pos.X;
            pos.Y = gd.Viewport.Height / 2 - pos.Y;

            return pos;
        }

        public Vector2 EnemyConvertToWorld(Vector2 pos)
        {
            pos.X = -gd.Viewport.Width / 2 + pos.X;
            pos.Y = gd.Viewport.Height / 2 - pos.Y + 32;
            return pos;
        }

        public void LoadLevel(GraphicsDeviceManager graphics, ref Vector2 playerPos, ref Vector2 enemypos)
        {
            if (LevelNumber >= LevelPath.Length) return;

            Vector2 windowplayer = Vector2.Zero;
            Vector2 windowenemy = Vector2.Zero;

            string[] lines = File.ReadAllLines("Content/" + LevelPath[LevelNumber]);
            map = new char[lines[0].Length, lines.Length];

            for (int x = 0; x < lines[0].Length; x++)
                for (int y = 0; y < lines.Length; y++)
                {
                    string currentLine = lines[y];
                    map[x, y] = currentLine[x];

                    if (currentLine[x] == 'i')
                    {
                        windowplayer = new Vector2(x*tileSize,y*tileSize);
                    }
                        
                    if(currentLine[x] == 'E')
                    {
                        windowenemy = new Vector2(x * tileSize, y * tileSize);
                    }

                }

            height = lines.Length;
            width = lines[0].Length;

            graphics.PreferredBackBufferHeight = height * tileSize;
            graphics.PreferredBackBufferWidth = width * tileSize;
            graphics.ApplyChanges();

            playerPos = ConvertToWorld(windowplayer);
            enemypos = EnemyConvertToWorld(windowenemy);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    char currentSymbol = map[x, y];
                    Console.Write(currentSymbol);


                    switch (currentSymbol)
                    {
                        case 'D':
                            _spriteBatch.Draw(dirtTex, new Vector2(x, y) * tileSize, Color.White);
                            break;

                        
                        case 'G':
                            _spriteBatch.Draw(grassTex, new Vector2(x, y) * tileSize, Color.White);
                            break;
                        
                    }
                }
        }

    }
}
