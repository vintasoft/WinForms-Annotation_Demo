using System;

using Vintasoft.Imaging.Annotation.Formatters;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Allows user to control the annotation loading process and select the annotation to load.
    /// </summary>
    public class CustomAnnotationSerializationBinder : AnnotationSerializationBinder
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAnnotationSerializationBinder"/> class.
        /// </summary>
        public CustomAnnotationSerializationBinder()
            : base()
        {
        }

        #endregion



        #region Methdos

        /// <summary>
        /// Controls the binding of serialized object to a type.
        /// </summary>
        /// <param name="assemblyName">Specifies the System.Reflection.Assembly name of
        /// the serialized object.</param>
        /// <param name="typeName">Specifies the System.Type name of the serialized object.</param>
        /// <returns>
        /// The type of the object the formatter creates a new instance of.
        /// </returns>
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (assemblyName.StartsWith("WpfAnnotationDemo"))
                assemblyName = assemblyName.Remove(0, 3);

            if (typeName == "AnnotationDemo.TriangleAnnotation")
                typeName = "AnnotationDemo.TriangleAnnotationData";

            if (typeName == "AnnotationDemo.MarkAnnotation")
                typeName = "AnnotationDemo.MarkAnnotationData";

            if (typeName.StartsWith("WpfAnnotationDemo"))
                typeName = typeName.Remove(0, 3);

            if (typeName == "AnnotationDemo.TriangleAnnotationData")
                typeName = "DemosCommonCode.Annotation.TriangleAnnotationData";

            if (typeName == "AnnotationDemo.MarkAnnotationData")
                typeName = "DemosCommonCode.Annotation.MarkAnnotationData";

            if (typeName.StartsWith("WpfDemosCommonCode"))
                typeName = typeName.Remove(0, 3);

            return base.BindToType(assemblyName, typeName);
        }

        #endregion

    }
}
