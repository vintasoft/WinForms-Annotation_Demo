using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to select image of image collection.
    /// </summary>
    public partial class SelectImageForm : Form
    {

        #region Fields

        /// <summary>
        /// The collection of images.
        /// </summary>
        ImageCollection _images;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectImageForm"/> class.
        /// </summary>
        /// <param name="images">The collection of images.</param>
        public SelectImageForm(ImageCollection images)
            : this()
        {
            SetImages(images);
        }


        /// <summary>
        /// Prevents a default instance of the <see cref="SelectImageForm"/> class
        /// from being created.
        /// </summary>
        public SelectImageForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the index of the selected image.
        /// </summary>
        public int SelectedImageIndex
        {
            get
            {
                return (int)selectedImageNumericUpDown.Value - 1;
            }
            set
            {
                selectedImageNumericUpDown.Value = value + 1;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Sets the images.
        /// </summary>
        /// <param name="images">The images.</param>
        public void SetImages(ImageCollection images)
        {
            if (images.Count == 0)
                throw new ArgumentOutOfRangeException();
            _images = images;
            ImagePreviewViewer.Images.AddRange(images.ToArray());
            selectedImageNumericUpDown.Maximum = images.Count;
            ImagePreviewViewer.FocusedIndex = 0;
        }

        /// <summary>
        /// Opens a form that allows to select image of image collection
        /// and returns the selected image.
        /// </summary>
        /// <param name="filename">The filename of image file.</param>
        /// <returns>Selected image.</returns>
        public static VintasoftImage SelectImageFromFile(string filename)
        {
            // temporary image for image in current file
            VintasoftImage image;

            // selected index
            int index;

            // create image collection
            using (ImageCollection images = SelectImageFromFile(filename, out index))
            {
                if (index == -1)
                    return null;

                // get the selected image
                image = images[index];

                // remove the selected image from image collection
                images.Remove(image);

                // if the count of images is more than one
                if (images.Count > 1)
                {
                    images.ClearAndDisposeItems();
                }
            }

            return image;
        }

        /// <summary>
        /// Opens a form that allows to select image of image collection
        /// and returns image collection and selected index.
        /// </summary>
        /// <param name="filename">The filename of image file.</param>
        /// <param name="selectedIndex">Selected index.</param>
        /// <returns>Image collection.</returns>
        public static ImageCollection SelectImageFromFile(string filename, out int selectedIndex)
        {
            selectedIndex = -1;

            // create image collection
            ImageCollection images = new ImageCollection();
            DocumentPasswordForm.EnableAuthentication(images);
            try
            {
                try
                {
                    // add an image file to the image collection
                    images.Add(filename);
                }
                catch (Exception e)
                {
                    DemosTools.ShowErrorMessage(e);
                    return null;
                }

                selectedIndex = 0;


                // if image file contains more than 1 image
                if (images.Count > 1)
                {
                    // create a dialog that allows to select image from multipage image file
                    using (SelectImageForm selectImageForm =
                        new SelectImageForm(images))
                    {
                        // show the dialog
                        DialogResult result = selectImageForm.ShowDialog();
                        // if image is selected
                        if (result == DialogResult.OK)
                        {
                            // get the selected index
                            selectedIndex = selectImageForm.SelectedImageIndex;
                        }
                        else
                        {
                            selectedIndex = -1;
                        }
                    }
                }
            }
            finally
            {
                DocumentPasswordForm.DisableAuthentication(images);

                // if image is not selected
                if (selectedIndex == -1)
                {
                    // clear and dispose images from the image collection
                    images.ClearAndDisposeItems();

                    // dispose image collection
                    images.Dispose();
                }
            }
            return images;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the DoubleClick event of ImagePreviewViewer object.
        /// </summary>
        private void ImagePreviewViewer_DoubleClick(object sender, EventArgs e)
        {
            // if image selected
            if (ImagePreviewViewer.FocusedIndex >= 0)
            {
                // set selected image index
                SelectedImageIndex = ImagePreviewViewer.FocusedIndex;
                
                // close dialog
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Handles the FocusedIndexChanged event of ImagePreviewViewer object.
        /// </summary>
        private void ImagePreviewViewer_FocusedIndexChanged(
            object sender,
            FocusedIndexChangedEventArgs e)
        {
            // update selected image index
            SelectedImageIndex = e.FocusedIndex;
        }

        /// <summary>
        /// Handles the ValueChanged event of SelectedImageNumericUpDown object.
        /// </summary>
        private void selectedImageNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // update focused image
            ImagePreviewViewer.FocusedIndex = SelectedImageIndex;

            // if selected image must be removed
            if (ImagePreviewViewer.SelectedIndices.Count > 0)
                // remove selected image
                ImagePreviewViewer.SelectedIndices.RemoveAt(0);

            // set selected image
            ImagePreviewViewer.SelectedIndices.Add(SelectedImageIndex);
        }

        #endregion

        #endregion
        
    }
}
