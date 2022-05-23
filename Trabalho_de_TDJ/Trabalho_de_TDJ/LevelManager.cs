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

        string[] LevelPath = {"Test_Level.txt" };
        int LevelNumber;

        public LevelManager()
        {
            
        }

        public void NextLevel()
        {

        }

        public void LoadLevel(ref int height, ref int width, GraphicsDeviceManager graphics, ref char[,] map, int tileSize, ref List<Vector2> objectivePointsPos, ref Vector2 playerPos)
        {
            if (LevelNumber >= LevelPath.Length) return;

            string[] lines = File.ReadAllLines("Content/" + LevelPath[LevelNumber]);
            map = new char[lines[0].Length, lines.Length];
            objectivePointsPos = new List<Vector2>();
        }

    }
}
