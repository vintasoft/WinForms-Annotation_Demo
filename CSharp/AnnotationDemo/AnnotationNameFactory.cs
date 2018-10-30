namespace AnnotationDemo
{
    /// <summary>
    /// Provides the ability to create the annotation name for annotation type.
    /// </summary>
    internal static class AnnotationNameFactory
    {

        /// <summary>
        /// Returns the anotation name.
        /// </summary>
        /// <param name="annotationType">The annotation type.</param>
        /// <returns>
        /// The annotation name.
        /// </returns>
        internal static string GetAnnotationName(AnnotationType annotationType)
        {
            switch (annotationType)
            {
                case AnnotationType.Rectangle:
                    return "Rectangle";

                case AnnotationType.CloudRectangle:
                    return "Cloud Rectangle";

                case AnnotationType.Ellipse:
                    return "Ellipse";

                case AnnotationType.CloudEllipse:
                    return "Cloud Ellipse";

                case AnnotationType.Highlight:
                    return "Highlight";

                case AnnotationType.CloudHighlight:
                    return "Cloud Highlight";

                case AnnotationType.FreehandHighlight:
                    return "Freehand Highlight";

                case AnnotationType.PolygonHighlight:
                    return "Polygon Highlight";

                case AnnotationType.FreehandPolygonHighlight:
                    return "Freehand Polygon Highlight";

                case AnnotationType.TextHighlight:
                    return "Text highlight";

                case AnnotationType.EmbeddedImage:
                    return "Embedded image";

                case AnnotationType.ReferencedImage:
                    return "Referenced image";

                case AnnotationType.Text:
                    return "Text";

                case AnnotationType.CloudText:
                    return "Cloud Text";

                case AnnotationType.StickyNote:
                    return "Sticky note";

                case AnnotationType.FreeText:
                    return "Free text";

                case AnnotationType.CloudFreeText:
                    return "Cloud Free text";

                case AnnotationType.RubberStamp:
                    return "Rubber stamp";

                case AnnotationType.Link:
                    return "Link";

                case AnnotationType.Arrow:
                    return "Arrow";

                case AnnotationType.DoubleArrow:
                    return "Double arrow";

                case AnnotationType.Line:
                    return "Line";

                case AnnotationType.Lines:
                    return "Lines";

                case AnnotationType.CloudLines:
                    return "Cloud Lines";

                case AnnotationType.TriangleLines:
                    return "Triangle Lines";

                case AnnotationType.LinesWithInterpolation:
                    return "Lines with interpolation";

                case AnnotationType.CloudLinesWithInterpolation:
                    return "Cloud Lines with interpolation";

                case AnnotationType.FreehandLines:
                    return "Freehand lines";

                case AnnotationType.Polygon:
                    return "Polygon";

                case AnnotationType.TrianglePolygon:
                    return "Triangle Polygon";

                case AnnotationType.CloudPolygon:
                    return "Cloud Polygon";

                case AnnotationType.PolygonWithInterpolation:
                    return "Polygon with interpolation";

                case AnnotationType.CloudPolygonWithInterpolation:
                    return "Cloud Polygon with interpolation";

                case AnnotationType.FreehandPolygon:
                    return "Freehand polygon";

                case AnnotationType.Ruler:
                    return "Ruler";

                case AnnotationType.Rulers:
                    return "Rulers";

                case AnnotationType.Angle:
                    return "Angle";

                case AnnotationType.Triangle:
                    return "Triangle - Custom Annotation";

                case AnnotationType.CloudTriangle:
                    return "Cloud Triangle - Custom Annotation";

                case AnnotationType.Mark:
                    return "Mark - Custom Annotation";
            }
            return "Unknown";
        }

    }
}
