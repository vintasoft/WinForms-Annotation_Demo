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
            /// Dictionary: the progress bar => the value.
            /// </summary>
            Dictionary<ProgressBar, int> _progressBarsToValue;

            /// <summary>
            /// Dictionary: the progress bar => the progress range.
            /// </summary>
            Dictionary<ProgressBar, int> _progressBarsToRange;

            /// <summary>
            /// Labels on a form.
            /// </summary>
            Label[] _labels;

            /// <summary>
            /// Dictionary: the label => the lavel value.
            /// </summary>
            Dictionary<Label, string> _labelsToValue;

            /// <summary>
            /// Determines whether action cancellation is requested.
            /// </summary>
            bool _cancelRequested = false;

            /// <summary>
            /// The text box for logging.
            /// </summary>
            TextBox _logTextBox;

            /// <summary>
            /// Dictionary: the aticon level => the message.
            /// </summary>
            Dictionary<int, string> _actionLevelToMessage = new Dictionary<int, string>();

            #endregion



            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ActionProgressHandler"/> class.
            /// </summary>
            /// <param name="progressBars">The progress bars.</param>
            /// <param name="labels">The labels.</param>
            /// <param name="logTextBox">The text box for logging.</param>
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

            #region PUBLIC

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

                        InvokeSetProgressBarValue(progressBar, progress);
                    }


                    // get current step precentage description

                    string percentageDescription;
                    if (actionProgressController.StepCount > 0)
                        percentageDescription = string.Format(CultureInfo.InvariantCulture, "{0:f1}%", progress * 100);
                    else
                        percentageDescription = "0%";


                    // get current label description

                    string labelDescription;
                    if (actionDescription != null)
                        labelDescription = string.Format("{0}... ({1})", actionDescription, percentageDescription);
                    else
                        labelDescription = percentageDescription;

                    InvokeSetLabelText(_labels[actionLevel], labelDescription);

                    if (firstStepOfAction)
                    {
                        for (int i = actionLevel + 1; i < _progressBars.Length; i++)
                        {
                            InvokeSetProgressBarValue(_progressBars[i], 0.0);
                            InvokeSetLabelText(_labels[i], string.Empty);
                        }
                    }
                }

                // add action description to Log TextBox
                string logMessage = actionDescription;
                if (logMessage != null)
                {
                    // if action is first step
                    if (firstStepOfAction)
                    {
                        logMessage = string.Format("{0}...", logMessage);
                    }
                    // if action is finished
                    else if (actionProgressController.IsFinished)
                    {
                        logMessage = string.Format("  Finished ({0}).", logMessage);
                    }
                    else
                    {
                        logMessage = "";
                    }

                    // if log message is created
                    if (logMessage != "")
                    {
                        string prevMessage = null;
                        if (!_actionLevelToMessage.TryGetValue(actionLevel, out prevMessage))
                            prevMessage = null;

                        // if log message is changed
                        if (prevMessage != logMessage)
                        {
                            _actionLevelToMessage[actionLevel] = logMessage;
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

            #endregion


            #region INTERNAL

            /// <summary>
            /// Cancels the current action.
            /// </summary>
            internal void CancelAction()
            {
                _cancelRequested = true;
            }

            #endregion


            #region PRIVATE

            /// <summary>
            /// Sets the label text thread-safely.
            /// </summary>
            /// <param name="label">The label.</param>
            /// <param name="text">The text.</param>
            private void InvokeSetLabelText(Label label, string text)
            {
                // if label text is changed
                if (text != _labelsToValue[label])
                {
                    // update label text
                    _labelsToValue[label] = text;

                    if (label.InvokeRequired)
                    {
                        label.Invoke(
                            new SetLabelTextDelegate(SetLabelText),
                            label,
                            text);
                    }
                    else
                    {
                        SetLabelText(label, text);
                    }
                }
            }

            /// <summary>
            /// Sets the label text.
            /// </summary>
            /// <param name="label">The label.</param>
            /// <param name="text">The text.</param>
            private void SetLabelText(Label label, string text)
            {
                if (label.Text != text)
                {
                    label.Text = text;
                }
            }

            /// <summary>
            /// Sets the progress bar value thread-safely.
            /// </summary>
            /// <param name="progressBar">The progress bar.</param>
            /// <param name="progress">The progress.</param>
            private void InvokeSetProgressBarValue(ProgressBar progressBar, double progress)
            {
                // get progress bar value
                int value = (int)Math.Round(progress * _progressBarsToRange[progressBar]);
                // if progress bar value is changed
                if (value != _progressBarsToValue[progressBar])
                {
                    // update progress bar value
                    _progressBarsToValue[progressBar] = value;

                    if (progressBar.InvokeRequired)
                    {
                        progressBar.Invoke(
                            new SetProgressBarValueDelegate(SetProgressBarValue),
                            progressBar,
                            value);
                    }
                    else
                    {
                        SetProgressBarValue(progressBar, value);
                    }
                }
            }

            /// <summary>
            /// Sets the progress bar value.
            /// </summary>
            /// <param name="progressBar">The progress bar.</param>
            /// <param name="progress">The progress.</param>
            private void SetProgressBarValue(ProgressBar progressBar, int progress)
            {
                int range = progressBar.Maximum - progressBar.Minimum;
                progressBar.Value = progressBar.Minimum + progress;
            }

            /// <summary>
            /// Adds the specified message to the log.
            /// </summary>
            /// <param name="message">The message.</param>
            private void AddLogMessage(string message)
            {
                _logTextBox.AppendText(string.Format("{0}{1}", message, Environment.NewLine));
                _logTextBox.ScrollToCaret();
            }

            #endregion

            #endregion



            #region Delegates

            /// <summary>
            /// The delegate for <see cref="SetProgressBarValue(ProgressBar, int)"/> method.
            /// </summary>
            /// <param name="progressBar">The progress bar.</param>
            /// <param name="progress">The progress.</param>
            delegate void SetProgressBarValueDelegate(ProgressBar progressBar, int progress);

            /// <summary>
            /// The delegate for <see cref="SetLabelText(Label, string)"/> method.
            /// </summary>
            /// <param name="label">The label.</param>
            /// <param name="text">The text.</param>
            delegate void SetLabelTextDelegate(Label label, string text);

            /// <summary>
            /// The delegate for <see cref="AddLogMessage(string)"/> method.
            /// </summary>
            /// <param name="message">The message.</param>
            delegate void AddLogMessageDelegate(string message);

            #endregion

        }

        #endregion



        #region Fields

        /// <summary>
        /// The action progress bars.
        /// </summary>
        ProgressBar[] _progressBars;

        /// <summary>
        /// The action labels.
        /// </summary>
        Label[] _labels;

        /// <summary>
        /// The text box for logging.
        /// </summary>
        TextBox _logText;

        /// <summary>
        /// The cancel button.
        /// </summary>
        Button _buttonCancel;

        /// <summary>
        /// The background worker.
        /// </summary>
        BackgroundWorker _backgroundWorker;

        /// <summary>
        /// The background worker callback.
        /// </summary>
        DoBackgroundWorkDelegate _backgroundWorkerCallback;

        /// <summary>
        /// The action progress handler.
        /// </summary>
        ActionProgressHandler _progressHandler;

        /// <summary>
        /// The action progress controller.
        /// </summary>
        ActionProgressController _progressController;

        /// <summary>
        /// A value indicating whether the error is occured.
        /// </summary>
        bool _isErrorOccured;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionProgressForm"/> class.
        /// </summary>
        /// <param name="callback">The background worker callback.</param>
        /// <param name="levelCount">The action level count.</param>
        /// <param name="caption">The form caption.</param>
        public ActionProgressForm(DoBackgroundWorkDelegate callback, int levelCount, string caption)
        {
            if (levelCount <= 0)
                throw new Exception();

            _backgroundWorkerCallback = callback;

            InitializeComponent();

            // update table layout panel properties
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.RowCount = 2 * levelCount + 2;
            tableLayoutPanel1.ColumnCount = 1;


            // create action progress bars

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


            // create textbox for logging

            TextBox logText = new TextBox();
            _logText = logText;
            logText.Multiline = true;
            logText.Width = 500;
            logText.Height = 150;
            logText.ScrollBars = ScrollBars.Vertical;
            logText.ReadOnly = true;
            tableLayoutPanel1.Controls.Add(logText, 0, 2 * levelCount);


            // create the button for canceling an action

            Button buttonCancel = new Button();
            _buttonCancel = buttonCancel;
            buttonCancel.Width = 100;
            buttonCancel.Height = 30;
            buttonCancel.Text = "Cancel";
            buttonCancel.Margin = new Padding(200, 10, 200, 10);
            buttonCancel.Click += new EventHandler(buttonCancel_Click);
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
        /// Gets or sets a value indicating whether the form must be closed when action is completed.
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

        /// <summary>
        /// Shows this form as a modal dialog with the specified owner.
        /// </summary>
        /// <param name="ownerForm">The owner form.</param>
        /// <returns>One of the System.Windows.Forms.DialogResult values.</returns>
        public DialogResult RunAndShowDialog(Form ownerForm)
        {
            _isErrorOccured = false;
            return ShowDialog(ownerForm);
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="E:OnFormClosing" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult result = GetActionDialogResult();
            if (result == DialogResult.None)
                e.Cancel = true;
            else
                DialogResult = result;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Handles the Click event of buttonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = GetActionDialogResult();
            if (result != DialogResult.None)
                DialogResult = result;
        }


        /// <summary>
        /// Runs the background worker.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ActionProgressForm_Load(object sender, EventArgs e)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

            _backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Calls the background worker callback.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _backgroundWorkerCallback(_progressController);
        }

        /// <summary>
        /// Shows the action complete result.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            string text;
            // if action is failed
            if (e.Error != null)
            {
                _isErrorOccured = true;
                DemosTools.ShowErrorMessage(e.Error);
                text = "Error.";
            }
            else
            {
                // if form must be closed when action is completed
                if (CloseAfterComplete)
                    this.Close();

                // if action is canceled
                if (_progressController.IsCanceled)
                    text = "Canceled.";
                else
                    text = "Finished.";
            }
            _buttonCancel.Text = "Close";
            for (int i = 0; i < _labels.Length; i++)
                _labels[i].Text = text;
        }

        /// <summary>
        /// Returns the action dialog result.
        /// </summary>
        private DialogResult GetActionDialogResult()
        {
            // if action is canceled
            if (_progressController.IsCanceled || _isErrorOccured)
                return DialogResult.Cancel;

            // if action is finished
            if (_progressController.IsFinished)
                return DialogResult.OK;


            // waiting for the completion of the task

            _buttonCancel.Enabled = false;
            _progressHandler.CancelAction();
            while (_backgroundWorker.IsBusy)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }
            _buttonCancel.Enabled = true;
            for (int i = 0; i < _progressBars.Length; i++)
                _progressBars[i].Value = 0;
            _logText.AppendText("Canceled.");
            return DialogResult.None;
        }

        #endregion

        #endregion



        #region Delegates

        /// <summary>
        /// The background worker callback delegate.
        /// </summary>
        /// <param name="progressController">The progress controller.</param>
        public delegate void DoBackgroundWorkDelegate(IActionProgressController progressController);

        #endregion

    }
}
