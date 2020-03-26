using System;

using Vintasoft.Imaging.Annotation;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Provides the ability to create the annotation comment type for annotation.
    /// </summary>
    public class AnnotationCommentTypeFactory
    {

        /// <summary>
        /// Returns the comment type.
        /// </summary>
        /// <param name="annotation">The parent annotation.</param>
        /// <returns>
        /// The comment type.
        /// </returns>
        public static string GetCommentType(AnnotationData annotation)
        {
            string result = string.Empty;

            if (annotation != null)
            {
                Type type = annotation.GetType();

                if (type == typeof(RectangleAnnotationData))
                    result = "Rectangle";
                else if (type == typeof(EllipseAnnotationData))
                    result = "Ellipse";
                else if (type == typeof(HighlightAnnotationData))
                    result = "Highlight";
                else if (type == typeof(EmbeddedImageAnnotationData))
                    result = "Embedded Image";
                else if (type == typeof(ReferencedImageAnnotationData))
                    result = "Referenced Image";
                else if (type == typeof(TextAnnotationData))
                    result = "Text";
                else if (type == typeof(StickyNoteAnnotationData))
                    result = "Sticky Note";
                else if (type == typeof(FreeTextAnnotationData))
                    result = "Free Text";
                else if (type == typeof(StampAnnotationData))
                    result = "Stamp";
                else if (type == typeof(LinkAnnotationData))
                    result = "Link";
                else if (type == typeof(ArrowAnnotationData))
                    result = "Arrow";
                else if (type == typeof(LineAnnotationData))
                    result = "Line";
                else if (type == typeof(LinesAnnotationData))
                    result = "Lines";
                else if (type == typeof(PolygonAnnotationData))
                    result = "Polygon";
                else if (type == typeof(RulerAnnotationData))
                    result = "Ruler";
                else if (type == typeof(RulersAnnotationData))
                    result = "Rulers";
                else if (type == typeof(AngleAnnotationData))
                    result = "Angle";
                else if (type == typeof(ArcAnnotationData))
                    result = "Arc";
                else if (type == typeof(TriangleAnnotationData))
                    result = "Triangle";
                else if (type == typeof(MarkAnnotationData))
                    result = "Mark";
                else if (type == typeof(GroupAnnotationData))
                    result = "Group";
            }

            return result;
        }

    }
}
