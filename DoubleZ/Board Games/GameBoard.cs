using System.Drawing;
using DoubleZ.Extensions;
using System;

namespace DoubleZ.BoardGames
{
    public class GameBoardException : Exception
    {
        public GameBoardException() : base() { }
        public GameBoardException(string message) : base(message) { }
    }

    /// <summary>
    /// A board for board games.
    /// </summary>
    /// <typeparam name="T">The type of the (usually abstract) object which will be placed on the board</typeparam>
    public class GameBoard<T> where T : class, IPlaceable<T> 
    {
        public Cell<T>[,] Board { get; set; }
        public int XSize { get; }
        public int YSize { get; }

        public GameBoard(int xSize, int ySize)
        {
            XSize = xSize;
            YSize = ySize;

            Board = new Cell<T>[xSize, ySize];

            for (int x = 0; x < xSize; x++)
                for (int y = 0; y < ySize; y++)
                    Board[x, y] = new Cell<T>(new Point(x, y), (x + y) % 2 == 0 ? Color.White : Color.Black, this);
        }

        public void RemoveAt(Point point)
        {
            if(IsOnBoard(point))
            {
                Board.FromPoint(point).Piece.Cell = null;
                Board.FromPoint(point).Piece = null;
            }
        }

        public void Add(T Piece, Point point)
        {
            if (Board.FromPoint(point).Piece != null) throw new GameBoardException();

            Board.FromPoint(point).Piece = Piece;
            Piece.Cell = Board.FromPoint(point);
        }

        public void Move(Point start, Point finish)
        {
            Board.FromPoint(finish).Piece = Board.FromPoint(start).Piece;
            Board.FromPoint(finish).Piece.Cell = Board.FromPoint(finish);
            Board.FromPoint(start).Piece = null;
        }

        /// <summary>
        /// Controls if a point is between the bounds of the chessboard.
        /// </summary>
        /// <param name="p">The point to control.</param>
        /// <returns></returns>
        public bool IsOnBoard(Point p) => p.X >= 0 && p.Y >= 0 && p.X < XSize && p.Y < YSize;
    }
}
