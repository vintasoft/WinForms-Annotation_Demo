using System.Text;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;

namespace AnnotationDemo
{
    /// <summary>
    /// Class for handling of changes of IRuler.UnitOfMeasure property.
    /// </summary>
    public class RulerAnnotationPropertyChangedEventHandler : AnnotationsEventsHandler
    {

        #region Constructor

        public RulerAnnotationPropertyChangedEventHandler(AnnotationViewer annotationViewer)
            : base(annotationViewer, true, true)
        {
            IsEnabled = true;
        }

        #endregion



        #region Methods
        
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
                        case UnitOfMeasure.PdfUserUnits:
                            formatString.Append("uu");
                            break;
                        case UnitOfMeasure.DeviceIndependentPixels:
                            formatString.Append("dip");
                            break;
                    }
                    ruler.FormatString = formatString.ToString();
                }
            }
        }

        #endregion

    }
}
