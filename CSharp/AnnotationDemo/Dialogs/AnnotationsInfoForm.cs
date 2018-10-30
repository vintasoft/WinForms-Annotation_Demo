using System.Windows.Forms;
using Vintasoft.Imaging.Annotation;

namespace AnnotationDemo
{
	public partial class AnnotationsInfoForm : Form
    {

        #region Constructor

        public AnnotationsInfoForm(AnnotationDataController annotations)
		{
			InitializeComponent();

			for (int i = 0; i < annotations.Images.Count; i++)
			{
				ListViewGroup group = annoInfoListView.Groups.Add("pageNumber", "Page " + (i + 1));
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