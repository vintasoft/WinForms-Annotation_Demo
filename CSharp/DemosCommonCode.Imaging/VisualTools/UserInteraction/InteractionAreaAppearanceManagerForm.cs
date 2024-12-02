using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.UI.VisualTools.UserInteraction;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit InteractionAreaAppearanceManager settings.
    /// </summary>
    public partial class InteractionAreaAppearanceManagerForm : Form
    {

        #region Fields

        /// <summary>
        /// The font dialog.
        /// </summary>
        FontDialog _fontDialog;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionAreaAppearanceManagerForm"/> class.
        /// </summary>
        public InteractionAreaAppearanceManagerForm()
            : this(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionAreaAppearanceManagerForm"/> class.
        /// </summary>
        /// <param name="selectedTabIndex">The selected tab page index.</param>
        public InteractionAreaAppearanceManagerForm(int selectedTabIndex)
        {
            InitializeComponent();

            // Resize point
            resizePointsInteractionRadiusNumericUpDown.Minimum = decimal.MinValue;
            resizePointsInteractionRadiusNumericUpDown.Maximum = decimal.MaxValue;
            resizePointsRadiusNumericUpDown.Minimum = decimal.MinValue;
            resizePointsRadiusNumericUpDown.Maximum = decimal.MaxValue;
            resizePointsBorderPenWidthNumericUpDown.Minimum = decimal.MinValue;
            resizePointsBorderPenWidthNumericUpDown.Maximum = decimal.MaxValue;
            resizePointsBackgroundColorPanelControl.CanSetColor = true;
            resizePointsBorderColorPanelControl.CanSetColor = true;

            // Polygon point
            polygonPointBorderPenWidthNumericUpDown.Minimum = decimal.MinValue;
            polygonPointBorderPenWidthNumericUpDown.Maximum = decimal.MaxValue;
            polygonPointInteractionRadiusNumericUpDown.Minimum = decimal.MinValue;
            polygonPointInteractionRadiusNumericUpDown.Maximum = decimal.MaxValue;
            polygonPointRadiusNumericUpDown.Minimum = decimal.MinValue;
            polygonPointRadiusNumericUpDown.Maximum = decimal.MaxValue;
            polygonPointBackgroundColorPanelControl.CanSetColor = true;
            selectedPolygonPointBackgroundColorPanelControl.CanSetColor = true;
            polygonPointBorderColorPanelControl.CanSetColor = true;

            // Rotation point
            rotationPointBorderPenWidthNumericUpDown.Minimum = decimal.MinValue;
            rotationPointBorderPenWidthNumericUpDown.Maximum = decimal.MaxValue;
            rotationPointInteractionRadiusNumericUpDown.Minimum = decimal.MinValue;
            rotationPointInteractionRadiusNumericUpDown.Maximum = decimal.MaxValue;
            rotationPointRadiusNumericUpDown.Minimum = decimal.MinValue;
            rotationPointRadiusNumericUpDown.Maximum = decimal.MaxValue;
            rotationPointDistanceNumericUpDown.Minimum = int.MinValue;
            rotationPointDistanceNumericUpDown.Maximum = int.MaxValue;
            rotationPointBackgroundColorPanelControl.CanSetColor = true;
            rotationPointBorderColorPanelControl.CanSetColor = true;

            // Rotation assistant
            rotationAssistantBorderPenWidthNumericUpDown.Minimum = decimal.MinValue;
            rotationAssistantBorderPenWidthNumericUpDown.Maximum = decimal.MaxValue;
            rotationAssistantRadiusNumericUpDown.Minimum = decimal.MinValue;
            rotationAssistantRadiusNumericUpDown.Maximum = decimal.MaxValue;
            rotationAssistantBackgroundColorPanelControl.CanSetColor = true;
            rotationAssistantBorderColorPanelControl.CanSetColor = true;

            // Text box
            textBoxForeColorPanelControl.CanSetColor = true;
            textBoxBackColorPanelControl.CanSetColor = true;

            _fontDialog = new FontDialog();

            InteractionAreaSettings = new InteractionAreaAppearanceManager();
            mainPanel.Enabled = false;
            okButton.Enabled = mainPanel.Enabled;

            tabControl1.SelectedIndex = Math.Min(Math.Max(0, selectedTabIndex), tabControl1.TabCount - 1);
        }

        #endregion



        #region Properties

        InteractionAreaAppearanceManager _interactionAreaSettings = null;
        /// <summary>
        /// Gets or sets the interaction area settings.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InteractionAreaAppearanceManager InteractionAreaSettings
        {
            get
            {
                return _interactionAreaSettings;
            }
            set
            {
                mainPanel.Enabled = value != null;
                okButton.Enabled = mainPanel.Enabled;
                _interactionAreaSettings = value;

                spellCheckManagerViewSettingsControl1.InteractionAreaSettings = value;

                UpdateUI();
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of fontButton object.
        /// </summary>
        private void fontButton_Click(object sender, EventArgs e)
        {
            // show font dialog
            _fontDialog.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // initialization is started
            _interactionAreaSettings.BeginInit();
            try
            {
                // Resize points
                _interactionAreaSettings.ResizePointsRadius =
                    Convert.ToSingle(resizePointsRadiusNumericUpDown.Value);
                _interactionAreaSettings.ResizePointsInteractionRadius =
                    Convert.ToSingle(resizePointsInteractionRadiusNumericUpDown.Value);
                _interactionAreaSettings.ResizePointsBackgroundColor = resizePointsBackgroundColorPanelControl.Color;
                _interactionAreaSettings.ResizePointsBorderColor = resizePointsBorderColorPanelControl.Color;
                _interactionAreaSettings.ResizePointsBorderPenWidth =
                    Convert.ToSingle(resizePointsBorderPenWidthNumericUpDown.Value);
                _interactionAreaSettings.NorthwestSoutheastResizePointCursor = resizePointsNwseCursorPanelControl.SelectedCursor;
                _interactionAreaSettings.NortheastSouthwestResizePointCursor = resizePointsNeswCursorPanelControl.SelectedCursor;
                _interactionAreaSettings.NorthSouthResizePointCursor = resizePointsNsCursorPanelControl.SelectedCursor;
                _interactionAreaSettings.WestEastResizePointCursor = resizePointsWeCursorPanelControl.SelectedCursor;

                // Polygon point
                _interactionAreaSettings.PolygonPointRadius =
                    Convert.ToSingle(polygonPointRadiusNumericUpDown.Value);
                _interactionAreaSettings.PolygonPointInteractionRadius =
                    Convert.ToSingle(polygonPointInteractionRadiusNumericUpDown.Value);
                _interactionAreaSettings.PolygonPointBackgroundColor = polygonPointBackgroundColorPanelControl.Color;
                _interactionAreaSettings.SelectedPolygonPointBackgroundColor = selectedPolygonPointBackgroundColorPanelControl.Color;
                _interactionAreaSettings.PolygonPointBorderColor = polygonPointBorderColorPanelControl.Color;
                _interactionAreaSettings.PolygonPointBorderPenWidth =
                    Convert.ToSingle(polygonPointBorderPenWidthNumericUpDown.Value);
                _interactionAreaSettings.PolygonPointCursor = polygonPointCursorPanelControl.SelectedCursor;

                // Rotation point
                _interactionAreaSettings.RotationPointRadius =
                    Convert.ToSingle(rotationPointRadiusNumericUpDown.Value);
                _interactionAreaSettings.RotationPointInteractionRadius =
                    Convert.ToSingle(rotationPointInteractionRadiusNumericUpDown.Value);
                _interactionAreaSettings.RotationPointBackgroundColor = rotationPointBackgroundColorPanelControl.Color;
                _interactionAreaSettings.RotationPointBorderColor = rotationPointBorderColorPanelControl.Color;
                _interactionAreaSettings.RotationPointBorderPenWidth =
                    Convert.ToSingle(rotationPointBorderPenWidthNumericUpDown.Value);
                _interactionAreaSettings.RotationPointDistance =
                    Convert.ToSingle(rotationPointDistanceNumericUpDown.Value);
                _interactionAreaSettings.RotationPointCursor = rotationPointCursorPanelControl.SelectedCursor;

                // Rotation assistant
                _interactionAreaSettings.RotationAssistantRadius =
                    Convert.ToSingle(rotationAssistantRadiusNumericUpDown.Value);
                _interactionAreaSettings.RotationAssistantBackgroundColor = rotationAssistantBackgroundColorPanelControl.Color;
                _interactionAreaSettings.RotationAssistantBorderColor = rotationAssistantBorderColorPanelControl.Color;
                _interactionAreaSettings.RotationAssistantBorderPenWidth =
                    Convert.ToSingle(rotationAssistantBorderPenWidthNumericUpDown.Value);
                _interactionAreaSettings.RotationAssistantDiscreteAngle =
                    Convert.ToSingle(rotationAssistantDiscreteAngleNumericUpDown.Value);

                // text box
                _interactionAreaSettings.TextBoxFont = (Font)_fontDialog.Font.Clone();
                _interactionAreaSettings.TextBoxForeColor = textBoxForeColorPanelControl.Color;
                _interactionAreaSettings.TextBoxBackColor = textBoxBackColorPanelControl.Color;
                _interactionAreaSettings.TextBoxCursor = textBoxCursorPanelControl.SelectedCursor;

                // spell check manager
                spellCheckManagerViewSettingsControl1.ApplySpellCheckManagerSetting();

                // move area
                _interactionAreaSettings.MoveAreaCursor = moveAreaCursorPanelControl.SelectedCursor;

                DialogResult = DialogResult.OK;
            }
            finally
            {
                // initialization is finished
                _interactionAreaSettings.EndInit();
            }
        }


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            InteractionAreaAppearanceManager settings = _interactionAreaSettings;

            if (settings == null)
                return;

            // Resize points
            resizePointsRadiusNumericUpDown.Value = Convert.ToDecimal(settings.ResizePointsRadius);
            resizePointsInteractionRadiusNumericUpDown.Value = Convert.ToDecimal(settings.ResizePointsInteractionRadius);
            resizePointsBackgroundColorPanelControl.Color = settings.ResizePointsBackgroundColor;
            resizePointsBorderColorPanelControl.Color = settings.ResizePointsBorderColor;
            resizePointsBorderPenWidthNumericUpDown.Value = Convert.ToDecimal(settings.ResizePointsBorderPenWidth);
            resizePointsNwseCursorPanelControl.SelectedCursor = settings.NorthwestSoutheastResizePointCursor;
            resizePointsNeswCursorPanelControl.SelectedCursor = settings.NortheastSouthwestResizePointCursor;
            resizePointsNsCursorPanelControl.SelectedCursor = settings.NorthSouthResizePointCursor;
            resizePointsWeCursorPanelControl.SelectedCursor = settings.WestEastResizePointCursor;

            // Polygon point
            polygonPointRadiusNumericUpDown.Value = Convert.ToDecimal(settings.PolygonPointRadius);
            polygonPointInteractionRadiusNumericUpDown.Value = Convert.ToDecimal(settings.PolygonPointInteractionRadius);
            polygonPointBackgroundColorPanelControl.Color = settings.PolygonPointBackgroundColor;
            selectedPolygonPointBackgroundColorPanelControl.Color = settings.SelectedPolygonPointBackgroundColor;
            polygonPointBorderColorPanelControl.Color = settings.PolygonPointBorderColor;
            polygonPointBorderPenWidthNumericUpDown.Value = Convert.ToDecimal(settings.PolygonPointBorderPenWidth);
            polygonPointCursorPanelControl.SelectedCursor = settings.PolygonPointCursor;

            // Rotation point
            rotationPointRadiusNumericUpDown.Value = Convert.ToDecimal(settings.RotationPointRadius);
            rotationPointInteractionRadiusNumericUpDown.Value = Convert.ToDecimal(settings.RotationPointInteractionRadius);
            rotationPointBackgroundColorPanelControl.Color = settings.RotationPointBackgroundColor;
            rotationPointBorderColorPanelControl.Color = settings.RotationPointBorderColor;
            rotationPointBorderPenWidthNumericUpDown.Value = Convert.ToDecimal(settings.RotationPointBorderPenWidth);
            rotationPointDistanceNumericUpDown.Value = Convert.ToDecimal(settings.RotationPointDistance);
            rotationPointCursorPanelControl.SelectedCursor = settings.RotationPointCursor;

            // Rotation assistant
            rotationAssistantRadiusNumericUpDown.Value = Convert.ToDecimal(settings.RotationAssistantRadius);
            rotationAssistantBackgroundColorPanelControl.Color = settings.RotationAssistantBackgroundColor;
            rotationAssistantBorderColorPanelControl.Color = settings.RotationAssistantBorderColor;
            rotationAssistantBorderPenWidthNumericUpDown.Value = Convert.ToDecimal(settings.RotationAssistantBorderPenWidth);
            rotationAssistantDiscreteAngleNumericUpDown.Value = Convert.ToDecimal(settings.RotationAssistantDiscreteAngle);

            // text box
            _fontDialog.Font = (Font)settings.TextBoxFont.Clone();
            textBoxForeColorPanelControl.Color = settings.TextBoxForeColor;
            textBoxBackColorPanelControl.Color = settings.TextBoxBackColor;
            textBoxCursorPanelControl.SelectedCursor = settings.TextBoxCursor;

            // move area
            moveAreaCursorPanelControl.SelectedCursor = settings.MoveAreaCursor;
        }

        #endregion

    }
}
