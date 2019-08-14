using System;

using Vintasoft.Imaging.Annotation.Formatters;

namespace AnnotationDemo
{
    public class CustomAnnotationSerializationBinder : AnnotationSerializationBinder
    {

        #region Constructors

        public CustomAnnotationSerializationBinder()
            : base()
        {
        }

        #endregion


        #region Methdos

        public override Type BindToType(string assemblyName, string typeName)
        {
            if (assemblyName.StartsWith("WpfAnnotationDemo"))
                assemblyName = assemblyName.Remove(0, 3);

            if (typeName == "AnnotationDemo.TriangleAnnotation")
                typeName = "AnnotationDemo.TriangleAnnotationData";

            if (typeName.StartsWith("WpfAnnotationDemo"))
                typeName = typeName.Remove(0, 3);

            return base.BindToType(assemblyName, typeName);
        }

        #endregion

    }
}
