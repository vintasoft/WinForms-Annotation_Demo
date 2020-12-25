using System.Text;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Class for handling of changes of IRuler.UnitOfMeasure property.
    /// </summary>
    public class RulerAnnotationPropertyChangedEventHandler : AnnotationsEventsHandler
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RulerAnnotationPropertyChangedEventHandler"/> class.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        public RulerAnnotationPropertyChangedEventHandler(AnnotationViewer annotationViewer)
            : base(annotationViewer, true, true)
        {
            IsEnabled = true;
        }

        #endregion



        #region Methods

        /// <summary>
        /// The annotation data property is changed.
        /// </summary>
        /// <param name="annotationDataCollection">The annotation data collection.</param>
        /// <param name="annotationData">The annotation data.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnAnnotationDataPropertyChanged(
            AnnotationDataCollection annotationDataCollection,
            AnnotationData annotationData,
            ObjectPropertyChangedEventArgs e)
        {
            IRuler ruler = annotationData as IRuler;
            if (ruler != null)
            {
                if (e.PropertyName == "UnitOfMeasure")
                {
                    StringBuilder formatString = new StringBuilder("0.0 ");
                    switch (ruler.UnitOfMeasure)
                    {
                        case UnitOfMeasure.Inches:
                            formatString.Append("in");
                            break;
                        case UnitOfMeasure.Centimeters:
                            formatString.Append("cm");
                            break;
                        case UnitOfMeasure.Millimeters:
                            formatString.Append("mm");
                            break;
                        case UnitOfMeasure.Pixels:
                            formatString.Append("px");
                            break;
                        case UnitOfMeasure.Points:
                            formatString.Append("point");
                            break;
                        case UnitOfMeasure.DeviceIndependentPixels:
                            formatString.Append("dip");
                            break;
                        case UnitOfMeasure.Twips:
                            formatString.Append("twip");
                            break;
                        case UnitOfMeasure.Emu:
                            formatString.Append("emu");
                            break;
                    }
                    ruler.FormatString = formatString.ToString();
                }
            }
        }

        #endregion

    }
}
