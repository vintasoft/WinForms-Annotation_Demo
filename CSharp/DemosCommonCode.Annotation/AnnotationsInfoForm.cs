using System.Windows.Forms;

using Vintasoft.Imaging.Annotation;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// A form that allows to view the annotation information.
    /// </summary>
    public partial class AnnotationsInfoForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnotationsInfoForm"/> class.
        /// </summary>
        /// <param name="annotations">The annotations.</param>
        public AnnotationsInfoForm(AnnotationDataController annotations)
        {
            InitializeComponent();

            // for each image in annotation data controller
            for (int i = 0; i < annotations.Images.Count; i++)
            {
                // create view group
                ListViewGroup group = annoInfoListView.Groups.Add("pageNumber", "Page " + (i + 1));
                // for each annotation in current image annotations
                for (int j = 0; j < annotations[i].Count; j++)
                {
                    AnnotationData annot = annotations[i][j];
                    ListViewItem item = annoInfoListView.Items.Add(annot.GetType().ToString());
                    item.Group = group;
                    item.SubItems.Add(annot.Location.ToString());
                    item.SubItems.Add(annot.CreationTime.ToString());
                }
            }
        }

        #endregion

    }
}