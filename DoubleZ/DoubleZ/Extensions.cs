using System.Drawing;

namespace DoubleZ
{
    namespace Extensions
    {
        public static class BidimensionalArraysExtensions
        {
            /// <summary>
            /// Allows to access a bidimensional array using a point.
            /// </summary>
            /// <param name="array">The bidimensional array to access.</param>
            /// <param name="p">The point where access.</param>
            public static ref T FromPoint<T>(this T[,] array, Point p) => ref array[p.X, p.Y];
        }
    }
}