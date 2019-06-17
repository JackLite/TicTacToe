using System;
using UnityEngine;

namespace TrueGames.Cell
{
    public struct CellPosition
    {
        public int X;
        public int Y;

        public CellPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public CellPosition(Vector2 pos)
        {
            X = Convert.ToInt32(pos.x);
            Y = Convert.ToInt32(pos.y);
        }
    }
}