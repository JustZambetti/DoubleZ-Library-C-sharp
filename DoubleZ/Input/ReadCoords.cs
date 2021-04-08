using System;
using System.Drawing;

namespace DoubleZ.Input
{
    public class Read
    {
        public static Point Coords(int xBound, int yBound)
        {
            Point coords = new Point();
            string s = Console.ReadLine().ToUpper().Replace(" ", "");
            if (s.Length < 2) return Coords(xBound, yBound);

            if (s[0] >= 'A' && s[0] <= 'A'+xBound)
                coords.X = s[0] - 'A';
            else Coords(xBound, yBound);

            coords.Y = int.Parse(s.Substring(1)) - 1;
            if (coords.Y < 0 || coords.Y > yBound) Coords(xBound, yBound);

            return coords;
        }
    }
}