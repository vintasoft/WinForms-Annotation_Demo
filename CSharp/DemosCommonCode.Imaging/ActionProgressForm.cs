using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

using Vintasoft.Imaging.Utils;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that executes a method in a background thread and shows the execution progress.
    /// </summary>
    public partial class ActionProgressForm : Form
    {

        #region Classes

        /// <summary>
        /// Custom action progress handler that sets captions and progress bar values.
        /// </summary>
        private class ActionProgressHandler : IActionProgressHandler
        {

            #region Fields

            /// <summary>
            /// Progress bars on a form.
            /// </summary>
            ProgressBar[] _progressBars;

            /// <summary>
            /// Progress bar to value dictionary.
            /// </summary>
            Dictionary<ProgressBar, int> _progressBarsToValue;

            /// <summary>
            /// Progress bar to progress range dictionary.
            /// </summary>
            Dictionary<ProgressBar, int> _progressBarsToRange;

            /// <summary>
            /// Labels on a form.
            /// </summary>
            Label[] _labels;

            /// <summary>
            /// Labels to value dictionary.
            /// </summary>
            Dictionary<Label, string> _labelsToValue;

            /// <summary>
            /// Determines whether action cancellation is requested.
            /// </summary>
            bool _cancelRequested = false;

            TextBox _logTextBox;

            Dictionary<int, string> _levelToMessage = new Dictionary<int, string>();

            #endregion



            #region Constructors

            internal ActionProgressHandler(
                ProgressBar[] progressBars,
                Label[] labels,
                TextBox logTextBox)
                : base()
            {
                _progressBars = progressBars;
                _progressBarsToValue = new Dictionary<ProgressBar, int>();
                _progressBarsToRange = new Dictionary<ProgressBar, int>();
                foreach (ProgressBar progressBar in progressBars)
                {
                    _progressBarsToValue.Add(progressBar, progressBar.Value);
                    _progressBarsToRange.Add(progressBar, progressBar.Maximum - progressBar.Minimum);
                }

                _labels = labels;
                _labelsToValue = new Dictionary<Label, string>();
                foreach (Label label in labels)
                    _labelsToValue.Add(label, label.Text);

                _logTextBox = logTextBox;
            }

            #endregion



            #region Methods

            /// <summary>
            /// Resets this action progress controller.
            /// </summary>
            public void Reset()
            {
            }

            /// <summary>
            /// Called when action step is changed.
            /// </summary>
            /// <param name="actionProgressController">The action progress controller.</param>
            /// <param name="actionStep">The action step.</param>
            /// <param name="canCancel">Indicates that action can be canceled.</param>
            /// <returns>
            /// <b>False</b> if action is canceled; otherwise <b>true</b>.
            /// </returns>
            public bool OnActionStep(
                ActionProgressController actionProgressController,
                double actionStep,
                bool canCancel)
            {
                if (canCancel && _cancelRequested)
                    return false;

                // action description
                string actionDescription = actionProgressController.ActionDescription;
                // action level
                int actionLevel = actionProgressController.ActionLevel;
                // is this first step of action
                bool firstStepOfAction = actionStep == 0;
                // if action level has progress bar
                if (actionLevel < _progressBars.Length)
                {
                    // show progress value
                    ProgressBar progressBar = _progressBars[actionLevel];

                    double progress = 0;
                    if (actionProgressController.StepCount > 0)
                    {
                        progress = actionStep / actionProgressController.StepCount;

                        SetProgressBarValueSafe(progressBar, progress);
                    }

                    string percentageDescription;
                    if (actionProgressController.StepCount > 0)
                        percentageDescription = string.Format(CultureInfo.InvariantCulture, "{0:f1}%", progress * 100);
                    else
                        percentageDescription = "0%";

                    string labelDescription;
                    if (actionDescription != null)
                        labelDescription = string.Format("{0}... ({1})", actionDescription, percentageDescription);
                    else
                        labelDescription = percentageDescription;

                    SetLabelTextSafe(_labels[actionLevel], labelDescription);

                    if (firstStepOfAction)
                    {
                        for (int i = actionLevel + 1; i < _progressBars.Length; i++)
                        {
                            SetProgressBarValueSafe(_progressBars[i], 0.0);
                            SetLabelTextSafe(_labels[i], string.Empty);
                        }
                    }
                }

                // add action description to Log TextBox
                string logMessage = actionDescription;
                if (logMessage != null)
                {
                    if (firstStepOfAction)
                    {
                        logMessage = string.Format("{0}...", logMessage);
                    }
                    else if (actionProgressController.IsFinished)
                    {
                        logMessage = string.Format("  Finished ({0}).", logMessage);
                    }
                    else
                    {
                        logMessage = "";
                    }
                    if (logMessage != "")
                    {
                        string prevMessage = null;
                        if (!_levelToMessage.TryGetValue(actionLevel, out prevMessage))
                            prevMessage = null;
                        if (prevMessage != logMessage)
                        {
                            _levelToMessage[actionLevel] = logMessage;
                            logMessage = logMessage.PadLeft(logMessage.Length + actionLevel * 4, ' ');
                            if (_logTextBox.InvokeRequired)
                                _logTextBox.Invoke(new AddLogMessageDelegate(AddLogMessage), logMessage);
                            else
                                AddLogMessage(logMessage);
                        }
                    }
                }

                return true;
            }


            private void SetLabelTextSafe(Label label, string text)
            {
                if (text != _labelsToValue[label])
                {
                    _labelsToValue[label] = text;
                    if (label.InvokeRequired)
                        label.Invoke(
                            new SetLabelTextDelegate(SetLabelText),
                            label,
                            text);
                    else
                        SetLabelText(label, text);
                }
            }

            private void SetProgressBarValueSafe(ProgressBar progressBar, double progress)
            {
                int value = (int)Math.Round(progress * _progressBarsToRange[progressBar]);
                if (value != _progressBarsToValue[progressBar])
                {
                    _progressBarsToValue[progressBar] = value;
                    if (progressBar.InvokeRequired)
                        progressBar.Invoke(
                            new SetProgressBarValueDelegate(SetProgressBarValue),
                            progressBar,
                            value);
                    else
                        SetProgressBarValue(progressBar, value);
                }
            }

            internal void CancelAction()
            {
                _cancelRequested = true;
            }

            private void SetProgressBarValue(ProgressBar progressBar, int progress)
            {
                int range = progressBar.Maximum - progressBar.Minimum;
                progressBar.Value = progressBar.Minimum + progress;
            }

            private void SetLabelText(Label label, string text)
            {
                if (label.Text != text)
                {
                    label.Text = text;
                }
            }

            private void AddLogMessage(string message)
            {
                _logTextBox.AppendText(string.Format("{0}{1}", message, Environment.NewLine));
                _logTextBox.ScrollToCaret();
            }

            #endregion



            #region Delegates

            delegate void SetProgressBarValueDelegate(ProgressBar progressBar, int progress);

            delegate void SetLabelTextDelegate(Label label, string text);

            delegate void AddLogMessageDelegate(string message);

            #endregion

        }

        #endregion



        #region Fields

        ProgressBar[] _progressBars;

        Label[] _labels;

        TextBox _logText;

        Button _cancelButton;

        BackgroundWorker _backgroundWorker;

        DoBackgroundWorkDelegate _callback;

        ActionProgressHandler _progressHandler;

        ActionProgressController _progressController;

        bool _errorOccured;

        #endregion



        #region Constructors

        public ActionProgressForm(DoBackgroundWorkDelegate callback, int levelCount, string caption)
        {
            if (levelCount <= 0)
                throw new Exception();

            _callback = callback;

            InitializeComponent();

            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            tableLayoutPanel1.RowCount = 2 * levelCount + 2;
            tableLayoutPanel1.ColumnCount = 1;

            ProgressBar[] progressBars = new ProgressBar[levelCount];
            Label[] labels = new Label[levelCount];
            for (int i = 0; i < levelCount; i++)
            {
                Label label = new Label();
                labels[i] = label;
                label.BackColor = Color.White;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.BottomCenter;
                tableLayoutPanel1.Controls.Add(label, 0, 2 * i);

                ProgressBar progressBar = new ProgressBar();
                progressBars[i] = progressBar;
                progressBar.Width = 500;
                progressBar.Height = 30;
                progressBar.Maximum = 0;
                progressBar.Maximum = progressBar.Width;
                tableLayoutPanel1.Controls.Add(progressBar, 0, 2 * i + 1);
            }

            TextBox logText = new TextBox();
            _logText = logText;
            logText.Multiline = true;
            logText.Width = 500;
            logText.Height = 150;
            logText.ScrollBars = ScrollBars.Vertical;
            logText.ReadOnly = true;
            tableLayoutPanel1.Controls.Add(logText, 0, 2 * levelCount);

            Button buttonCancel = new Button();
            _cancelButton = buttonCancel;
            buttonCancel.Width = 100;
            buttonCancel.Height = 30;
            buttonCancel.Text = "Cancel";
            buttonCancel.Margin = new Padding(200, 10, 200, 10);
            buttonCancel.Click += new EventHandler(cancelButton_Click);
            tableLayoutPanel1.Controls.Add(buttonCancel, 0, 2 * levelCount + 1);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.Text = caption;

            _progressHandler = new ActionProgressHandler(progressBars, labels, logText);
            _progressController = new ActionProgressController(_progressHandler);

            _progressBars = progressBars;
            _labels = labels;
        }

        #endregion



        #region Properties

        bool _closeAfterComplete = false;
        /// <summary>
        /// Gets or sets a value indicating whether the form can be closed.
        /// </summary>
        /// <value>
        /// <b>true</b> - form must be closed when action is completed; otherwise, <b>false</b>.
        /// </value>
        [DefaultValue(false)]
        public bool CloseAfterComplete
        {
            get
            {
                return _closeAfterComplete;
            }
            set
            {
                _closeAfterComplete = value;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        public DialogResult RunAndShowDialog(Form form)
        {
            _errorOccured = false;
            return ShowDialog(form);
        }

        #endregion


        #region PROTECTED

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult result = ClickToCancelButton();
            if (result == DialogResult.None)
                e.Cancel = true;
            else
                DialogResult = result;
        }

        #endregion


        #region PRIVATE

        private void ActionProgressForm_Load(object sender, EventArgs e)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

            _backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _callback(_progressController);
        }

        private void backgroundWorker_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            string text;
            if (e.Error != null)
            {
                _errorOccured = true;
                DemosTools.ShowErrorMessage(e.Error);
                text = "Error.";
            }
            else
            {
                if (CloseAfterComplete)
                    this.Close();

                if (_progressController.IsCanceled)
                    text = "Canceled.";
                else
                    text = "Finished.";
            }
            _cancelButton.Text = "Close";
            for (int i = 0; i < _labels.Length; i++)
                _labels[i].Text = text;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = ClickToCancelButton();
            if (result != DialogResult.None)
                DialogResult = result;
        }

        private DialogResult ClickToCancelButton()
        {
            if (_progressController.IsCanceled || _errorOccured)
                return DialogResult.Cancel;

            if (_progressController.IsFinished)
                return DialogResult.OK;

            _cancelButton.Enabled = false;
            _progressHandler.CancelAction();
            while (_backgroundWorker.IsBusy)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }
            _cancelButton.Enabled = true;
            for (int i = 0; i < _progressBars.Length; i++)
                _progressBars[i].Value = 0;
            _logText.AppendText("Canceled.");
            return DialogResult.None;
        }

        #endregion

        #endregion



        #region Delegates

        public delegate void DoBackgroundWorkDelegate(IActionProgressController progressController);

        #endregion

    }
}
