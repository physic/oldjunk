using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoardViewer
{
    class Util
    {
        /* Returns a list of coordinates representing a polygon with the provided number of sides and edge length.
         * The polygon will be horizontal along the bottom, and points are listed clockwise from bottom left to bottom right.
         */
        public static List<Point> GetPolygonCoordinates(int sides, double edgeLength)
        {
            double halfAngle = Math.PI / sides;
            double outerRadius = (edgeLength / 2.0) / Math.Sin(halfAngle);

            List<Point> points = new List<Point>();
            for (int i = 0; i < sides; i++)
            {
                double angle = halfAngle * (-2 * i - 1);
                points.Add(new Point(outerRadius * Math.Sin(angle), outerRadius * Math.Cos(angle)));
            }
            return points;
        }
    }
}
