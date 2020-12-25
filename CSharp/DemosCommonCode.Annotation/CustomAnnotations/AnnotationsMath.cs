using System;
using System.Drawing;


namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Contains collection of helper-algorithms for annotations.
    /// </summary>
    internal static class AnnotationsMath
    {

        /// <summary>
        /// Returns the bounding box for specified points.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns>
        /// Bounding box for specified points.
        /// </returns>
        internal static RectangleF GetBoundingBox(PointF[] points)
        {
            if (points.Length == 0)
                return RectangleF.Empty;
            float x1, x2, y1, y2;
            x1 = x2 = points[0].X;
            y1 = y2 = points[0].Y;
            for (int i = 1; i < points.Length; i++)
            {
                float x = points[i].X;
                float y = points[i].Y;
                if (x1 > x)
                    x1 = x;
                if (x2 < x)
                    x2 = x;
                if (y1 > y)
                    y1 = y;
                if (y2 < y)
                    y2 = y;
            }
            return new RectangleF(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Rotates points around a specified point by a given angle.
        /// </summary>
        /// <param name="points">The points to rotate.</param>
        /// <param name="atPoint">The rotation point.</param>
        /// <param name="alpha">The rotation angle.</param>
        internal static void RotatePointsAt(PointF[] points, PointF atPoint, float alpha)
        {
            float sin = (float)Math.Sin(-GradToRad(alpha));
            float cos = (float)Math.Cos(-GradToRad(alpha));
            float x, y;
            for (int i = 0; i < points.Length; i++)
            {
                x = points[i].X - atPoint.X;
                y = points[i].Y - atPoint.Y;
                points[i].X = x * cos + y * sin + atPoint.X;
                points[i].Y = -x * sin + y * cos + atPoint.Y;
            }
        }

        /// <summary>
        /// Translates the points.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="dx">The horizontal translation.</param>
        /// <param name="dy">The vertical translation.</param>
        internal static void TranslatePoints(PointF[] points, float dx, float dy)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X += dx;
                points[i].Y += dy;
            }
        }

        /// <summary>
        /// Scales the points.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="sx">The horizontal scale.</param>
        /// <param name="sy">The vertical scale.</param>
        internal static void ScalePoints(PointF[] points, float sx, float sy)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X *= sx;
                points[i].Y *= sy;
            }
        }

        /// <summary>
        /// Converts the specified degree to radians.
        /// </summary>
        /// <param name="grad">The degree.</param>
        /// <returns>
        /// A value in radians.
        /// </returns>
        internal static float GradToRad(float grad)
        {
            return (float)(Math.PI / 180.0) * grad;
        }

    }
}
