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
            public CellColor CellColor { get; }
            public GameBoard<T> GameBoard { get; }

            public Cell(Point position, CellColor cellColor, GameBoard<T> gameBoard)
            {
                Position = position;
                CellColor = cellColor;
                GameBoard = gameBoard;
            }
            public Cell(Point position, CellColor color, GameBoard<T> gameBoard, T piece) : this(position, color, gameBoard)
            {
                Piece = piece;
            }
        }
    }
}