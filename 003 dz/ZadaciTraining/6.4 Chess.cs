using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadaciTraining
{
    public abstract class ChessPiece
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        protected ChessPiece(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract bool CanMove(int newX, int newY);
        public abstract void Move(int newX, int newY);
    }

    public class Rook : ChessPiece
    {
        public Rook(int x, int y) : base(x, y) { }

        public override bool CanMove(int newX, int newY)
        {
            return X == newX || Y == newY;
        }

        public override void Move(int newX, int newY)
        {
            if (CanMove(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }
    }

    public class Bishop : ChessPiece
    {
        public Bishop(int x, int y) : base(x, y) { }

        public override bool CanMove(int newX, int newY)
        {
            return Math.Abs(X - newX) == Math.Abs(Y - newY);
        }

        public override void Move(int newX, int newY)
        {
            if (CanMove(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }
    }
}
