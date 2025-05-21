namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Provides the ability to create the annotation icon name for annotation type.
    /// </summary>
    class AnnotationIconNameFactory
    {

        /// <summary>
        /// Returns the anotation icon name.
        /// </summary>
        /// <param name="annotationType">The annotation type.</param>
        /// <returns>
        /// The annotation icon name.
        /// </returns>
        internal static string GetAnnotationIconName(AnnotationType annotationType)
        {
            switch (annotationType)
            {
                case AnnotationType.Rectangle:
                    return "Rectangle";

                case AnnotationType.CloudRectangle:
                    return "CloudRectangle";

                case AnnotationType.Ellipse:
                    return "Ellipse";

                case AnnotationType.CloudEllipse:
                    return "CloudEllipse";

                case AnnotationType.Highlight:
                    return "Highlight";

                case AnnotationType.CloudHighlight:
                    return "CloudHighlight";

                case AnnotationType.FreehandHighlight:
                    return "FreehandHighlight";

                case AnnotationType.PolygonHighlight:
                    return "PolygonHighlight";

                case AnnotationType.FreehandPolygonHighlight:
                    return "FreehandPolygonHighlight";

                case AnnotationType.TextHighlight:
                    return "TextHighlight";

                case AnnotationType.EmbeddedImage:
                    return "EmbeddedImage";

                case AnnotationType.ReferencedImage:
                    return "ReferencedImage";

                case AnnotationType.OfficeDocument:
                    return "Office";

                case AnnotationType.Chart:
                    return "Chart";

                case AnnotationType.EmptyDocument:
                    return "EmptyDocument";

                case AnnotationType.Text:
                    return "Text";

                case AnnotationType.CloudText:
                    return "CloudText";

                case AnnotationType.StickyNote:
                    return "StickyNote";

                case AnnotationType.FreeText:
                    return "FreeText";

                case AnnotationType.CloudFreeText:
                    return "CloudFreeText";

                case AnnotationType.RubberStamp:
                    return "RubberStamp";

                case AnnotationType.Link:
                    return "Link";

                case AnnotationType.Arrow:
                    return "Arrow";

                case AnnotationType.DoubleArrow:
                    return "DoubleArrow";

                case AnnotationType.Line:
                    return "Line";

                case AnnotationType.Lines:
                    return "Lines";

                case AnnotationType.CloudLines:
                    return "CloudLines";

                case AnnotationType.TriangleLines:
                    return "TriangleLines";

                case AnnotationType.LinesWithInterpolation:
                    return "FreehandLines";

                case AnnotationType.CloudLinesWithInterpolation:
                    return "CloudLinesWithInterpolation";

                case AnnotationType.Ink:
                    return "Ink";

                case AnnotationType.Polygon:
                    return "Polygon";

                case AnnotationType.TrianglePolygon:
                    return "TrianglePolygon";

                case AnnotationType.CloudPolygon:
                    return "CloudPolygon";

                case AnnotationType.PolygonWithInterpolation:
                    return "FreehandPolygon";

                case AnnotationType.CloudPolygonWithInterpolation:
                    return "CloudPolygonWithInterpolation";

                case AnnotationType.FreehandPolygon:
                    return "FreehandPolygon";

                case AnnotationType.Ruler:
                    return "Ruler";

                case AnnotationType.Rulers:
                    return "Rulers";

                case AnnotationType.Angle:
                    return "Angle";

                case AnnotationType.Triangle:
                    return "Triangle";

                case AnnotationType.CloudTriangle:
                    return "CloudTriangle";

                case AnnotationType.Mark:
                    return "Mark";

                case AnnotationType.Arc:
                    return "Arc";

                case AnnotationType.ArcWithArrow:
                    return "ArcWithArrow";

                case AnnotationType.ArcWithDoubleArrow:
                    return "ArcWithDoubleArrow";
            }
            return "Unknown";
        }

    }
}
