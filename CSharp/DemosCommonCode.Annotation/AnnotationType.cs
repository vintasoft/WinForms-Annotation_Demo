
namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Specifies available types of annotations, which can be built.
    /// </summary>
    public enum AnnotationType
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// The rectangle annotation.
        /// </summary>
        Rectangle,

        /// <summary>
        /// The rectangle annotation with cloud border.
        /// </summary>
        CloudRectangle,


        /// <summary>
        /// The ellipse annotation.
        /// </summary>
        Ellipse,

        /// <summary>
        /// The ellipse annotation with cloud border.
        /// </summary>
        CloudEllipse,


        /// <summary>
        /// The highlight rectangle annotation.
        /// </summary>
        Highlight,

        /// <summary>
        /// The highlight rectangle annotation with cloud border.
        /// </summary>
        CloudHighlight,


        /// <summary>
        /// The freehand annotation.
        /// </summary>
        FreehandHighlight,

        /// <summary>
        /// The highlight polygon annotation.
        /// </summary>
        PolygonHighlight,

        /// <summary>
        /// The highlight freehand polygon annotation.
        /// </summary>
        FreehandPolygonHighlight,

        /// <summary>
        /// The highlight text annotation.
        /// </summary>
        TextHighlight,

        /// <summary>
        /// The embedded image annotation.
        /// </summary>
        EmbeddedImage,

        /// <summary>
        /// The referenced image annotation.
        /// </summary>
        ReferencedImage,

        /// <summary>
        /// The text annotation.
        /// </summary>
        Text,

        /// <summary>
        /// The text annotation with cloud border.
        /// </summary>
        CloudText,

        /// <summary>
        /// The sticky note annotation.
        /// </summary>
        StickyNote,

        /// <summary>
        /// The text annotation and line annotation with arrow.
        /// </summary>
        FreeText,

        /// <summary>
        /// The text annotation with cloud border and line annotation with arrow.
        /// </summary>
        CloudFreeText,

        /// <summary>
        /// The rubber stamp annotation.
        /// </summary>
        RubberStamp,

        /// <summary>
        /// The link annotation.
        /// </summary>
        Link,

        /// <summary>
        /// The arrow annotation.
        /// </summary>
        Arrow,

        /// <summary>
        /// The double arrow annotation.
        /// </summary>
        DoubleArrow,

        /// <summary>
        /// The line annotation.
        /// </summary>
        Line,

        /// <summary>
        /// The lines annotation.
        /// </summary>
        Lines,

        /// <summary>
        /// The lines annotation with cloud line style.
        /// </summary>
        CloudLines,

        /// <summary>
        /// The lines annotation with triangle line style.
        /// </summary>
        TriangleLines,

        /// <summary>
        /// The lines annotation with interpolation.
        /// </summary>
        LinesWithInterpolation,

        /// <summary>
        /// The lines annotation with interpolation and cloud line style.
        /// </summary>
        CloudLinesWithInterpolation,

        /// <summary>
        /// The freehand lines annotation.
        /// </summary>
        FreehandLines,

        /// <summary>
        /// The polygon annotation.
        /// </summary>
        Polygon,

        /// <summary>
        /// The polygon annotation with triangle border.
        /// </summary>
        TrianglePolygon,

        /// <summary>
        /// The polygon annotation with cloud border.
        /// </summary>
        CloudPolygon,

        /// <summary>
        /// The polygon annotation with interpolation.
        /// </summary>
        PolygonWithInterpolation,

        /// <summary>
        /// The polygon annotation with interpolation and cloud border.
        /// </summary>
        CloudPolygonWithInterpolation,

        /// <summary>
        /// The freehand polygon annotation.
        /// </summary>
        FreehandPolygon,

        /// <summary>
        /// The ruler annotation.
        /// </summary>
        Ruler,

        /// <summary>
        /// The rulers annotation.
        /// </summary>
        Rulers,

        /// <summary>
        /// The angle annotation.
        /// </summary>
        Angle,

        /// <summary>
        /// The triangle annotation.
        /// </summary>
        Triangle,

        /// <summary>
        /// The triangle annotation with cloud border.
        /// </summary>
        CloudTriangle,

        /// <summary>
        /// The mark annotation.
        /// </summary>
        Mark,

        /// <summary>
        /// The arc annotation.
        /// </summary>
        Arc,

        /// <summary>
        /// The arc annotation with arrow.
        /// </summary>
        ArcWithArrow,

        /// <summary>
        /// The arc annotation with double arrow.
        /// </summary>
        ArcWithDoubleArrow,

        /// <summary>
        /// The Office annotation that represents page in existing DOCX document.
        /// </summary>
        OfficeDocument,

        /// <summary>
        /// The Office annotation that represents page with chart in DOCX document.
        /// </summary>
        Chart,

        /// <summary>
        /// The Office annotation that represents page in empty DOCX document.
        /// </summary>
        EmptyDocument,
    }
}
