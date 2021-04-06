using System.Drawing;

namespace DoubleZ
{
    namespace BoardGames
    {
        /// <summary>
        /// A cell for a board game.
        /// </summary>
        /// <typeparam name="T">The piece linked to the cell.</typeparam>
        public class Cell<T> where T : class, IPlaceable<T>
        {
            public Point Position { get; }
            public T Piece { get; set; }
            public Color Color { get; }
            public GameBoard<T> GameBoard { get; }

            public Cell(Point position, T piece, Color color, GameBoard<T> gameBoard)
            {
                Position = position;
                Piece = piece;
                Color = color;
                GameBoard = gameBoard;
            }
            public Cell(Point position, Color color, GameBoard<T> gameBoard)
            {
                Position = position;
                Color = color;
                GameBoard = gameBoard;
            }
        }
    }
}