using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Color;
using Vintasoft.Imaging.ImageProcessing.Effects;
using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to edit magnifier tool settings.
    /// </summary>
    public partial class MagnifierToolSettingsForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MagnifierToolSettingsForm"/> class.
        /// </summary>
        public MagnifierToolSettingsForm()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        MagnifierTool _magnifier = null;
        /// <summary>
        /// Gets or sets magnifier tool.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Description("Magnifier tool.")]
        public MagnifierTool Magnifier
        {
            get
            {
                return _magnifier;
            }
            set
            {
                _magnifier = value;
                UpdateUI();
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // update tool settings
            SetSettings();
            // close form
            Close();
        }

        /// <summary>
        /// Handles the Click event of CancelButton object.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            // close form
            Close();
        }


        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // set values of size numeric up-downs
            widthNumericUpDown.Value = Magnifier.Size.Width;
            heightNumericUpDown.Value = Magnifier.Size.Height;

            // set value of zoom numeric up-down
            zoomNumericUpDown.Value = Magnifier.Zoom;

            // display pen settings
            Pen pen = Magnifier.BorderPen;
            if (pen != null)
            {
                borderColorPanelControl.Color = pen.Color;
                borderWidthNumericUpDown.Value = (decimal)pen.Width;
            }
            else
            {
                borderColorPanelControl.Color = Color.Black;
                borderWidthNumericUpDown.Value = 0;
            }

            // set elliptical outline check box value
            ellipticalOutlineCheckBox.Checked = Magnifier.UseEllipticalOutline;

            // set visual tools visibility check box value
            showVisualToolsCheckBox.Checked = Magnifier.ShowVisualTools;

            // set processing commands check boxes to false
            invertCheckBox.Checked = false;
            posterizeCheckBox.Checked = false;
            oilPaintingCheckBox.Checked = false;
            grayscaleCheckBox.Checked = false;

            // if the processing command is CompositeCommand
            if (Magnifier.ProcessingCommand is CompositeCommand)
            {
                CompositeCommand compositeCommand = (CompositeCommand)Magnifier.ProcessingCommand;

                // get sub commands
                ProcessingCommandBase[] commands = compositeCommand.GetCommands();

                // set processing commands check boxes
                for (int i = 0; i < commands.Length; i++)
                {
                    if (commands[i] is InvertCommand)
                        invertCheckBox.Checked = true;
                    else if (commands[i] is PosterizeCommand)
                        posterizeCheckBox.Checked = true;
                    else if (commands[i] is OilPaintingCommand)
                        oilPaintingCheckBox.Checked = true;
                    else if (commands[i] is ChangePixelFormatToGrayscaleCommand)
                        grayscaleCheckBox.Checked = true;
                }
            }
        }

        /// <summary>
        /// Sets settings to the magnifier tool.
        /// </summary>
        private void SetSettings()
        {
            // set magnifier size
            Magnifier.Size = new Size((int)widthNumericUpDown.Value, (int)heightNumericUpDown.Value);

            // set magnifier zoom
            Magnifier.Zoom = (int)zoomNumericUpDown.Value;

            // if selected width of magnifier pen is more than 0
            if (borderWidthNumericUpDown.Value > 0)
                // set the magnifier pen
                Magnifier.BorderPen = new Pen(borderColorPanelControl.Color, (float)borderWidthNumericUpDown.Value);
            else
                Magnifier.BorderPen = null;

            // set UseEllipticalOutline property of magnifier
            Magnifier.UseEllipticalOutline = ellipticalOutlineCheckBox.Checked;

            // set ShowVisualTools property of magnifier
            Magnifier.ShowVisualTools = showVisualToolsCheckBox.Checked;

            // create the list of selected processing commands
            List<ProcessingCommandBase> commands = new List<ProcessingCommandBase>();
            if (invertCheckBox.Checked)
                commands.Add(new InvertCommand());
            if (posterizeCheckBox.Checked)
                commands.Add(new PosterizeCommand());
            if (oilPaintingCheckBox.Checked)
                commands.Add(new OilPaintingCommand());
            if (grayscaleCheckBox.Checked)
                commands.Add(new ChangePixelFormatToGrayscaleCommand());

            // set the magnifier processing command
            if (commands.Count > 0)
                Magnifier.ProcessingCommand = new CompositeCommand(commands.ToArray());
            else
                Magnifier.ProcessingCommand = null;
        }

        #endregion

    }
}
