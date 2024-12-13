using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

using Vintasoft.Data;
using Vintasoft.Imaging;
using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.Formatters;
using Vintasoft.Imaging.Annotation.UI;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.ImageProcessing;
#if !REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Annotation.Pdf;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Drawing;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.Annotations;
#endif
using Vintasoft.Imaging.Undo;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Contains collection of helper-algorithms for demo applications with annotations.
    /// </summary>
    public class AnnotationDemosTools
    {

        #region Constructors

        /// <summary>
        /// Initializes the <see cref="AnnotationDemosTools"/> class.
        /// </summary>
        public AnnotationDemosTools()
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Loads annotation collection from file.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        /// <param name="openFileDialog">The open file dialog.</param>
        /// <param name="undoManager">The undo manager.</param>
        public static void LoadAnnotationsFromFile(AnnotationViewer annotationViewer, OpenFileDialog openFileDialog, CompositeUndoManager undoManager)
        {
            // cancel annotation building
            annotationViewer.CancelAnnotationBuilding();

            openFileDialog.FileName = null;
            openFileDialog.Filter = "Binary Annotations(*.vsab)|*.vsab|XMP Annotations(*.xmp)|*.xmp|WANG Annotations(*.wng)|*.wng|All Formats(*.vsab;*.xmp;*.wng)|*.vsab;*.xmp;*.wng";
            openFileDialog.FilterIndex = 4;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // begin the composite undo action
                undoManager.BeginCompositeAction("Load annotations from file");
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        // get the annotation collection
                        AnnotationDataCollection annotations = annotationViewer.AnnotationDataCollection;
                        // clear the annotation collection
                        annotations.ClearAndDisposeItems();
                        // add annotations from stream to the annotation collection
                        annotations.AddFromStream(fs, annotationViewer.Image.Resolution);
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
                finally
                {
                    // end the composite undo action
                    undoManager.EndCompositeAction();
                }
            }
        }

        /// <summary>
        /// Saves annotation collection to a file.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        /// <param name="saveFileDialog">The save file dialog.</param>
        public static void SaveAnnotationsToFile(AnnotationViewer annotationViewer, SaveFileDialog saveFileDialog)
        {
            // cancel annotation building
            annotationViewer.CancelAnnotationBuilding();

            saveFileDialog.FileName = null;
            saveFileDialog.Filter = "Binary Annotations|*.vsab|XMP Annotations|*.xmp|WANG Annotations|*.wng";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // open specified file
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        // get annotation formatter

                        AnnotationFormatter annotationFormatter = null;
                        if (saveFileDialog.FilterIndex == 1)
                            annotationFormatter = new AnnotationVintasoftBinaryFormatter();
                        else if (saveFileDialog.FilterIndex == 2)
                            annotationFormatter = new AnnotationVintasoftXmpFormatter();
                        else if (saveFileDialog.FilterIndex == 3)
                        {
                            if (MessageBox.Show(
                                "Important: Some data in annotations will be lost. Do you want to continue anyway?",
                                "Warning",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning) == DialogResult.Cancel)
                            {
                                return;
                            }

                            annotationFormatter = new AnnotationWangFormatter(annotationViewer.Image.Resolution);
                        }

                        // get focused annotation data collection
                        AnnotationDataCollection annotations = annotationViewer.AnnotationDataController[annotationViewer.FocusedIndex];
                        // serialize annotation data to specified stream
                        annotationFormatter.Serialize(fs, annotations);
                    }
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);
                }
            }
        }

        /// <summary>
        /// Groups/ungroups selected annotations of annotation collection.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        /// <param name="undoManager">The undo manager.</param>
        public static void GroupUngroupSelectedAnnotations(AnnotationViewer annotationViewer, CompositeUndoManager undoManager)
        {
            // cancel annotation building
            annotationViewer.CancelAnnotationBuilding();

            // get selected annotations
            Collection<AnnotationView> selectedAnnotations = annotationViewer.AnnotationVisualTool.SelectedAnnotations;

            if (selectedAnnotations.Count == 0)
                return;

            // if several annotations are selected
            if (selectedAnnotations.Count > 1)
            {
                // begin the composite undo action
                undoManager.BeginCompositeAction("Group annotations");

                try
                {
                    // create group annotation data
                    GroupAnnotationData groupAnnotationData = new GroupAnnotationData();
                    // create annotation view array
                    AnnotationView[] annotations = new AnnotationView[selectedAnnotations.Count];
                    // copy selected annotations to array
                    selectedAnnotations.CopyTo(annotations, 0);
                    // for each annotation in array
                    foreach (AnnotationView view in annotations)
                    {
                        groupAnnotationData.Items.Add(view.Data);
                        annotationViewer.AnnotationDataCollection.Remove(view.Data);
                    }
                    // add group annotation to viewer
                    annotationViewer.AnnotationDataCollection.Add(groupAnnotationData);
                    // update focused annotation data
                    annotationViewer.FocusedAnnotationData = groupAnnotationData;
                    // update selected annotations
                    annotationViewer.AnnotationVisualTool.SelectedAnnotations.Clear();
                    annotationViewer.AnnotationVisualTool.SelectedAnnotations.Add(annotationViewer.FocusedAnnotationView);
                }
                finally
                {
                    // end the composite undo action
                    undoManager.EndCompositeAction();
                }
            }
            else
            {
                GroupAnnotationView groupAnnotationView = annotationViewer.AnnotationVisualTool.SelectedAnnotations[0] as GroupAnnotationView;
                // if focused annotation is group
                if (groupAnnotationView != null)
                {
                    // begin the composite undo action
                    undoManager.BeginCompositeAction("Ungroup annotations");

                    try
                    {
                        // clear selected annotations
                        selectedAnnotations.Clear();

                        // get annotation data
                        GroupAnnotationData groupAnnotationData = (GroupAnnotationData)groupAnnotationView.Data;
                        // add group annotation items to annotation data collection
                        annotationViewer.AnnotationDataCollection.AddRange(groupAnnotationData.Items.ToArray());
                        // remove group annotation from annotation data collection
                        annotationViewer.AnnotationDataCollection.Remove(groupAnnotationData);
                        // if the annotation viewer allows multiple selection of annotations
                        if (annotationViewer.AnnotationMultiSelect)
                        {
                            // for each annotation data in group annotation items
                            foreach (AnnotationData itemData in groupAnnotationData.Items)
                                selectedAnnotations.Add(annotationViewer.AnnotationViewCollection.FindView(itemData));
                        }

                        // remove annotations from group annotation
                        groupAnnotationData.Items.Clear();
                        // dispose group annotation
                        groupAnnotationData.Dispose();
                    }
                    finally
                    {
                        // end the composite undo action
                        undoManager.EndCompositeAction();
                    }
                }
            }
        }

        /// <summary>
        /// Groups all annotations of annotation collection.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        /// <param name="undoManager">The undo manager.</param>
        public static void GroupAllAnnotations(AnnotationViewer annotationViewer, CompositeUndoManager undoManager)
        {
            // cancel the annotation building
            annotationViewer.CancelAnnotationBuilding();

            // get reference to the annotation collection of focused image
            AnnotationDataCollection annotationDataCollection = annotationViewer.AnnotationDataController[annotationViewer.FocusedIndex];
            if (annotationDataCollection.Count == 0)
                return;

            // begin the composite undo action
            undoManager.BeginCompositeAction("Group all annotations");

            try
            {
                // save the references to annotations in array
                AnnotationData[] annotationDataArray = annotationDataCollection.ToArray();

                // clear the annotation collection of focused image
                annotationDataCollection.Clear();

                // create the group annotation
                GroupAnnotationData groupAnnotationData = new GroupAnnotationData();

                // for each annotation in array
                for (int i = 0; i < annotationDataArray.Length; i++)
                {
                    // add annotations from array to group annotation
                    groupAnnotationData.Items.Add(annotationDataArray[i]);
                }

                // add the group annotation to the annotation collection of focused image
                annotationDataCollection.Add(groupAnnotationData);

                annotationViewer.FocusedAnnotationData = groupAnnotationData;
            }
            finally
            {
                // end the composite undo action
                undoManager.EndCompositeAction();
            }
        }

        /// <summary>
        /// Rotates image with annotations.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        /// <param name="undoManager">The undo manager.</param>
        /// <param name="dataStorage">The data storage.</param>
        public static void RotateImageWithAnnotations(AnnotationViewer annotationViewer, CompositeUndoManager undoManager, IDataStorage dataStorage)
        {
            // cancel annotation building
            annotationViewer.CancelAnnotationBuilding();

            // create rotate image dialog
            using (RotateImageWithAnnotationsForm dialog = new RotateImageWithAnnotationsForm(annotationViewer.Image.PixelFormat))
            {
                // if image with annotation must be rotated
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // if undo manager is enabled
                    if (undoManager.IsEnabled)
                    {
                        // begin the composite undo action
                        undoManager.BeginCompositeAction("Rotate image with annotations");

                        // if undo manager does not contain the history for current image
                        if (!undoManager.ContainsActionForSourceObject(annotationViewer.Image))
                        {
                            // create change undo action
                            ChangeImageUndoAction originalImageAction = new ChangeImageUndoAction(dataStorage, annotationViewer.Image);
                            undoManager.AddAction(originalImageAction, null);
                        }
                        try
                        {
                            // create change undo action
                            ChangeImageUndoAction action = new ChangeImageUndoAction(dataStorage, annotationViewer.Image, "Rotate");
                            // clone focused image
                            using (VintasoftImage previousImage = (VintasoftImage)annotationViewer.Image.Clone())
                            {
                                // rotate focused image with annotations
                                RotateFocusedImageWithAnnotations(annotationViewer, (float)dialog.Angle, dialog.BorderColorType, dialog.SourceImagePixelFormat);

                                // add action to the undo manager
                                undoManager.AddAction(action, previousImage);
                            }
                        }
                        finally
                        {
                            // end the composite undo action
                            undoManager.EndCompositeAction();
                        }
                    }
                    else
                    {
                        // rotate focused image with annotations
                        RotateFocusedImageWithAnnotations(annotationViewer, (float)dialog.Angle, dialog.BorderColorType, dialog.SourceImagePixelFormat);
                    }
                }
            }
        }

        /// <summary>
        /// Rotates focused image with annotations.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        /// <param name="rotationAngle">Rotation angle in degrees.</param>
        /// <param name="borderColorType">Border color type.</param>
        /// <param name="pixelFormat">New pixel format.</param>
        private static void RotateFocusedImageWithAnnotations(AnnotationViewer annotationViewer, float rotationAngle, BorderColorType borderColorType, PixelFormat pixelFormat)
        {
            // if pixel formats are not equal
            if (pixelFormat != annotationViewer.Image.PixelFormat)
            {
                // change pixel format
                ChangePixelFormatCommand command = new ChangePixelFormatCommand(pixelFormat);
                command.ExecuteInPlace(annotationViewer.Image);
            }

            // rotate the focused image with annotations
            annotationViewer.RotateImageWithAnnotations(rotationAngle, borderColorType);
        }

        /// <summary>
        /// Burns annotations on image.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        /// <param name="undoManager">The undo manager.</param>
        /// <param name="dataStorage">The data storage.</param>
        public static void BurnAnnotationsOnImage(AnnotationViewer annotationViewer, CompositeUndoManager undoManager, IDataStorage dataStorage)
        {
            // cancel annotation building
            annotationViewer.CancelAnnotationBuilding();

            // if focused image is not correct
            if (!CheckImage(annotationViewer))
                return;

            // get focused image
            VintasoftImage sourceImage = annotationViewer.Image;
#if !REMOVE_PDF_PLUGIN
            // if focused image is PDF vector image
            if (sourceImage.IsVectorImage && sourceImage.SourceInfo.Decoder is PdfDecoder)
            {
                // get PDF page
                PdfPage page = PdfDocumentController.GetPageAssociatedWithImage(sourceImage);
                // if focused PDF page contains vector content
                if (!page.IsImageOnly)
                {
                    DialogResult result = MessageBox.Show(string.Format("{0}\n\n{1}\n\n{2}\n\n{3}",
                        "This page is a vector page of PDF document. How annotations should be drawn on the page?",
                        "Press 'Yes' if you want convert annotations to PDF annotations and draw annotations on PDF page in a vector form.",
                        "Press 'No' if you want rasterize PDF page and draw annotations on raster image in raster form.",
                        "Press 'Cancel' to cancel burning."),
                        "Burn Annotations", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // burn vector annotations
                        BurnPdfAnnotations(
                            annotationViewer.AnnotationDataCollection,
                            sourceImage.Resolution,
                            page);
                        // remove annotations
                        annotationViewer.AnnotationDataCollection.ClearAndDisposeItems();
                        // reload focused image
                        sourceImage.Reload(true);
                        return;
                    }
                    if (result == DialogResult.Cancel)
                        return;
                }
            }
#endif
            // if undo manager is enabled
            if (undoManager.IsEnabled)
            {
                // create focused image copy
                using (VintasoftImage image = (VintasoftImage)sourceImage.Clone())
                {
                    // begin the composite undo action
                    undoManager.BeginCompositeAction("Burn annotations on image");

                    // if undo manager does not contain the history for current image
                    if (!undoManager.ContainsActionForSourceObject(sourceImage))
                    {
                        // create change undo action
                        ChangeImageUndoAction originalImageAction = new ChangeImageUndoAction(dataStorage, sourceImage);
                        undoManager.AddAction(originalImageAction, null);
                    }
                    try
                    {
                        // burn annotations on focused image
                        annotationViewer.AnnotationViewController.BurnAnnotationCollectionOnImage(annotationViewer.FocusedIndex);
                        // create change undo action
                        ChangeImageUndoAction action = new ChangeImageUndoAction(dataStorage, sourceImage, "Burn annotations on image");
                        undoManager.AddAction(action, image);
                    }
                    finally
                    {
                        // end the composite undo action
                        undoManager.EndCompositeAction();
                    }
                }
            }
            else
            {
                // burn annotations on focused image
                annotationViewer.AnnotationViewController.BurnAnnotationCollectionOnImage(annotationViewer.FocusedIndex);
            }

        }

#if !REMOVE_PDF_PLUGIN
        /// <summary>
        /// Burns the annotations on PDF page with vector graphics.
        /// </summary>
        /// <param name="annotations">The annotations.</param>
        /// <param name="resolution">The resolution.</param>
        /// <param name="page">The page.</param>
        private static void BurnPdfAnnotations(
            AnnotationDataCollection annotations,
            Resolution resolution,
            PdfPage page)
        {
            PdfAnnotation[] annots =
                AnnotationConverter.ConvertToPdfAnnotations(annotations, resolution, page);

            using (PdfGraphics g = page.GetGraphics())
                foreach (PdfAnnotation annot in annots)
                    g.DrawAnnotation(annot);
        }
#endif        

        /// <summary>
        /// Copies image with annotations to the clipboard.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        public static void CopyImageToClipboard(AnnotationViewer annotationViewer)
        {
            // if focused image is not correct
            if (!CheckImage(annotationViewer))
                return;

            try
            {
                // create image with annotations
                using (VintasoftImage image = annotationViewer.AnnotationViewController.GetImageWithAnnotations(annotationViewer.FocusedIndex))
                    // copy image to the clipboard
                    Clipboard.SetImage(image.GetAsBitmap());
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }
      
        /// <summary>
        /// Checks that focused image is present and correct.
        /// </summary>
        /// <param name="annotationViewer">The annotation viewer.</param>
        public static bool CheckImage(AnnotationViewer annotationViewer)
        {
            // if current image is not correct
            if (annotationViewer.Image.IsBad)
            {
                MessageBox.Show("Focused image is bad.");
                return false;
            }
            return true;
        }

        #endregion

    }
}
