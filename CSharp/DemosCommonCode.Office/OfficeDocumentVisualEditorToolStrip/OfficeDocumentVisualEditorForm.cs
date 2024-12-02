#if REMOVE_OFFICE_PLUGIN
#error Remove OfficeDocumentVisualEditorForm from the project.
#endif

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Vintasoft.Imaging.Office.OpenXml.Editor;
using Vintasoft.Imaging.Office.OpenXml.Editor.Docx;
using Vintasoft.Imaging.Office.OpenXml.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;

namespace DemosCommonCode.Office
{
    /// <summary>
    /// A form that allows to edit Office document.
    /// </summary>
    public partial class OfficeDocumentVisualEditorForm : Form
    {

        #region Constants

        /// <summary>
        /// The content scale delta, in percents.
        /// </summary>
        const float ContentScaleDelta = 10f;

        #endregion



        #region Fields

        /// <summary>
        /// The last location of form, which owns this form.
        /// </summary>
        Point _ownerLastLocation;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfficeDocumentVisualEditorForm"/> class.
        /// </summary>
        public OfficeDocumentVisualEditorForm()
        {
            InitializeComponent();

            fontPropertiesVisualEditorToolStrip.MouseEnter += EditorStrip_MouseEnter;
            textPropertiesVisualEditorToolStrip.MouseEnter += EditorStrip_MouseEnter;
            paragraphPropertiesVisualEditorToolStrip.MouseEnter += EditorStrip_MouseEnter;
            officeDocumentStrip.MouseEnter += EditorStrip_MouseEnter;
            fontPropertiesVisualEditorToolStrip.MouseLeave += EditorStrip_MouseLeave;
            textPropertiesVisualEditorToolStrip.MouseLeave += EditorStrip_MouseLeave;
            paragraphPropertiesVisualEditorToolStrip.MouseLeave += EditorStrip_MouseLeave;
            officeDocumentStrip.MouseLeave += EditorStrip_MouseLeave;
        }

        #endregion



        #region Properties

        Point _locationOffsetFromOwnerForm = new Point(-140, 0);
        /// <summary>
        /// Gets or sets the offset from owner form.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Point LocationOffsetFromOwnerForm
        {
            get
            {
                return _locationOffsetFromOwnerForm;
            }
            set
            {
                _locationOffsetFromOwnerForm = value;
            }
        }

        IInteractionController _officeDocumentInteractionController = null;
        /// <summary>
        /// Gets or sets the interaction controller for Office document.
        /// </summary>
        private IInteractionController OfficeDocumentInteractionController
        {
            get
            {
                return _officeDocumentInteractionController;
            }
            set
            {
                if (_officeDocumentInteractionController != value)
                {
                    if (_officeDocumentInteractionController != null)
                        _officeDocumentInteractionController.Interaction -= _officeDocumentInteractionController_Interaction;
                    _officeDocumentInteractionController = value;
                    if (_officeDocumentInteractionController != null)
                        _officeDocumentInteractionController.Interaction += _officeDocumentInteractionController_Interaction;
                }
            }
        }

        OfficeDocumentVisualEditor _visualEditor = null;
        /// <summary>
        /// Gets or sets the visual editor for Office document.
        /// </summary>
        private OfficeDocumentVisualEditor VisualEditor
        {
            get
            {
                return _visualEditor;
            }
            set
            {
                if (_visualEditor != value)
                {
                    if (_visualEditor != null)
                        _visualEditor.DocumentChanged -= _visualEditor_DocumentChanged;

                    _visualEditor = value;

                    if (_visualEditor != null)
                        _visualEditor.DocumentChanged += _visualEditor_DocumentChanged;

                    UpdateUI();
                }
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Adds visual tool that uses the Office document visual editor.
        /// </summary>
        public void AddVisualTool(UserInteractionVisualTool visualTool)
        {
            visualTool.ActiveInteractionControllerChanged += VisualTool_ActiveInteractionControllerChanged;

            fontPropertiesVisualEditorToolStrip.AddVisualTool(visualTool);
            textPropertiesVisualEditorToolStrip.AddVisualTool(visualTool);
            paragraphPropertiesVisualEditorToolStrip.AddVisualTool(visualTool);
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Shown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnShown(EventArgs e)
        {
            UpdateUI();

            base.OnShown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closing" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = true;
            Hide();
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the Click event of chartsButton object.
        /// </summary>
        private void chartsButton_Click(object sender, EventArgs e)
        {
            ShowChartForm(_visualEditor);
        }

        /// <summary>
        /// Handles the Click event of increaseContentScaleButton object.
        /// </summary>
        private void increaseContentScaleButton_Click(object sender, EventArgs e)
        {
            try
            {
                _visualEditor.InteractiveObject.ContentScale *= (1 + ContentScaleDelta / 100f);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of decreaseContentScaleButton object.
        /// </summary>
        private void decreaseContentScaleButton_Click(object sender, EventArgs e)
        {
            try
            {
                _visualEditor.InteractiveObject.ContentScale *= (1 - ContentScaleDelta / 100f);
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the MouseEnter event of EditorStrip object.
        /// </summary>
        private void EditorStrip_MouseEnter(object sender, EventArgs e)
        {
            // set focus to this form (the toolstrip for editing Office document)
            ((ToolStrip)sender).Focus();
        }

        /// <summary>
        /// Handles the MouseLeave event of EditorStrip object.
        /// </summary>
        private void EditorStrip_MouseLeave(object sender, EventArgs e)
        {
            // set focus to the owner form
            Owner.Focus();
        }

        #endregion


        /// <summary>
        /// Updates the User Interface.
        /// </summary>
        private void UpdateUI()
        {
            if (_visualEditor != null)
            {
                chartsButton.Enabled = _visualEditor.HasCharts;
            }
            else
            {
                chartsButton.Enabled = false;
            }
        }


        /// <summary>
        /// Handles the ActiveInteractionControllerChanged event of the VisualTool.
        /// </summary>
        private void VisualTool_ActiveInteractionControllerChanged(object sender, Vintasoft.Imaging.PropertyChangedEventArgs<IInteractionController> e)
        {
            // if interaction controller exists
            if (e.NewValue != null)
            {
                // find visual editor in current interaction controller
                VisualEditor = CompositeInteractionController.FindInteractionController<OfficeDocumentVisualEditor>(e.NewValue);
            }
            else
            {
                VisualEditor = null;
            }

            // if visual editor exists
            if (VisualEditor != null)
            {
                // set current OfficeDocumentInteractionController
                OfficeDocumentInteractionController = e.NewValue;
            }
            else
            {
                OfficeDocumentInteractionController = null;
            }

            // if visual editor is not found or disabled
            if (VisualEditor == null || !VisualEditor.IsEnabled)
            {
                // if this form is visible
                if (Visible)
                    // hide this form
                    Hide();
            }
            else
            {
                // if this form is not visible
                if (!Visible)
                {
                    try
                    {
                        // if owner form is specified
                        if (Owner != null)
                        {
                            // if owner form is moved
                            if (_ownerLastLocation != Owner.Location)
                            {
                                // reset location
                                _ownerLastLocation = Owner.Location;
                                int x = LocationOffsetFromOwnerForm.X;
                                if (x < 0)
                                    x += Owner.Size.Width - Size.Width;
                                int y = LocationOffsetFromOwnerForm.Y;
                                if (y < 0)
                                    y += Owner.Size.Height - Size.Height;
                                Location = new Point(Owner.Location.X + x, Owner.Location.Y + y);
                            }

                            // show form
                            Show();

                            // set focus to owner form
                            Owner.Focus();
                        }
                        else
                        {
                            // show form
                            Show();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Handles the DocumentChanged event of the OfficeDocumentVisualEditor.
        /// </summary>
        private void _visualEditor_DocumentChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the Interaction event of the OfficeDocumentInteractionController.
        /// </summary>
        private void _officeDocumentInteractionController_Interaction(object sender, InteractionEventArgs e)
        {
            // if mouse is double clicked
            if (e.MouseClickCount == 2)
            {
                // find visual editor
                OfficeDocumentVisualEditor visualEditor = CompositeInteractionController.FindInteractionController<OfficeDocumentVisualEditor>(e.InteractionController);
                // if visual editor is found and has charts
                if (visualEditor != null && visualEditor.HasCharts)
                {
                    // create document editor
                    using (DocxDocumentEditor editor = visualEditor.CreateDocumentEditor())
                    {
                        // if document has chart(s) and don't have text
                        if (editor.Charts.Length > 0 && string.IsNullOrEmpty(editor.Body.Text.Trim('\n')))
                        {
                            // open chart editor form
                            ShowChartForm(visualEditor);
                            e.InteractionOccured(false);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Shows the chart form.
        /// </summary>
        /// <param name="visualEditor">The visual editor for Office document.</param>
        private void ShowChartForm(OfficeDocumentVisualEditor visualEditor)
        {
            OpenXmlDocumentChartDataForm chartForm = new OpenXmlDocumentChartDataForm();
            chartForm.VisualEditor = visualEditor;
            if (Owner != null)
                chartForm.Location = Owner.Location;
            else
                chartForm.Location = Location;
            chartForm.ShowDialog();
        }

        #endregion

        #endregion

    }
}
