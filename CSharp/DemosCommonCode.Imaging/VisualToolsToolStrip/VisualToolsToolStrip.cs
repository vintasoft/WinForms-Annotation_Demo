using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

using DemosCommonCode.CustomControls;
using Vintasoft.Imaging;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A tool strip that shows buttons, which allow to enable/disable visual tools in image viewer.
    /// </summary>
    public partial class VisualToolsToolStrip : ToolStrip
    {

        #region Nested Class

        /// <summary>
        /// A dictionary, which contains links between actions and buttons.
        /// </summary>
        private class VisualToolActionButtonsDictionary
        {

            #region Fields

            /// <summary>
            /// Dictionary: the action => the tool strip item.
            /// </summary>
            Dictionary<VisualToolAction, ToolStripItem> _actionToToolStripItem =
                new Dictionary<VisualToolAction, ToolStripItem>();

            /// <summary>
            /// Dictionary: the tool strip item => the action.
            /// </summary>
            Dictionary<ToolStripItem, VisualToolAction> _toolStripItemToAction =
                new Dictionary<ToolStripItem, VisualToolAction>();

            #endregion



            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="VisualToolActionButtonsDictionary"/> class.
            /// </summary>
            internal VisualToolActionButtonsDictionary()
            {
            }

            #endregion



            #region Methods

            /// <summary>
            /// Adds the specified action and tool strip item.
            /// </summary>
            /// <param name="action">The action.</param>
            /// <param name="item">The tool strip item.</param>
            internal void Add(VisualToolAction action, ToolStripItem item)
            {
                _actionToToolStripItem.Add(action, item);
                _toolStripItemToAction.Add(item, action);
            }

            /// <summary>
            /// Determines whether the dictionary contains the specified action.
            /// </summary>
            /// <param name="action">The action to locate in the dictionary.</param>
            /// <returns>
            /// <b>True</b> if action is found in the dictionary; otherwise; <b>false</b>.
            /// </returns>
            internal bool Contains(VisualToolAction action)
            {
                return _actionToToolStripItem.ContainsKey(action);
            }

            /// <summary>
            /// Determines whether the dictionary contains the specified tool strip item.
            /// </summary>
            /// <param name="item">The tool strip item to locate in the dictionary.</param>
            /// <returns>
            /// <b>True</b> if tool strip item is found in the dictionary; otherwise; <b>false</b>.
            /// </returns>
            internal bool Contains(ToolStripItem item)
            {
                return _toolStripItemToAction.ContainsKey(item);
            }

            /// <summary>
            /// Removes all items from the collection.
            /// </summary>
            internal void Clear()
            {
                _actionToToolStripItem.Clear();
                _toolStripItemToAction.Clear();
            }

            /// <summary>
            /// Removes the specified action from the dictionary.
            /// </summary>
            /// <param name="action">The action to remove from the dictionary.</param>
            /// <returns>
            /// <b>True</b> if action was removed successfully; otherwise, <b>false</b>.
            /// </returns>
            internal bool Remove(VisualToolAction action)
            {
                if (Contains(action))
                {
                    ToolStripItem item = GetItem(action);

                    _actionToToolStripItem.Remove(action);
                    _toolStripItemToAction.Remove(item);

                    return true;
                }

                return false;
            }

            /// <summary>
            /// Removes the specified tool strip item from the dictionary.
            /// </summary>
            /// <param name="item">The tool strip item to remove from the dictionary.</param>
            /// <returns>
            /// <b>True</b> if tool strip item was removed successfully; otherwise, <b>false</b>.
            /// </returns>
            internal bool Remove(ToolStripItem item)
            {
                if (Contains(item))
                {
                    VisualToolAction action = GetAction(item);

                    _actionToToolStripItem.Remove(action);
                    _toolStripItemToAction.Remove(item);

                    return true;
                }

                return false;
            }

            /// <summary>
            /// Returns the tool strip item at the specified action.
            /// </summary>
            /// <param name="action">The action.</param>
            /// <returns>
            /// The tool strip item of action.
            /// </returns>
            internal ToolStripItem GetItem(VisualToolAction action)
            {
                return _actionToToolStripItem[action];
            }

            /// <summary>
            /// Returns the action at the specified tool strip item.
            /// </summary>
            /// <param name="item">The item.</param>
            /// <returns>
            /// The action of tool strip item.
            /// </returns>
            internal VisualToolAction GetAction(ToolStripItem item)
            {
                return _toolStripItemToAction[item];
            }

            #endregion

        }

        #endregion



        #region Fields

        /// <summary>
        /// The None tool item.
        /// </summary>
        NoneAction _noneVisualToolAction = null;

        /// <summary>
        /// The label, which shows the action status.
        /// </summary>
        ToolStripLabel _actionStatusLabel = new ToolStripLabel();

        /// <summary>
        /// A value indicating whether the action status label is moving.
        /// </summary>
        bool _isActionStatusLabelMoving = false;

        /// <summary>
        /// The dictionary: visual tool action => visual tool.
        /// </summary>
        Dictionary<VisualToolAction, VisualTool> _visualToolItemToVisualTool =
            new Dictionary<VisualToolAction, VisualTool>();

        /// <summary>
        /// The dictionary, which contains information about visual tools, which are added to the tool strip.
        /// </summary>
        VisualToolActionButtonsDictionary _toolStripDictionary =
            new VisualToolActionButtonsDictionary();

        /// <summary>
        /// The dictionary, which contains information about visual tools, which are added to the "Visual tools" menu.
        /// </summary>
        VisualToolActionButtonsDictionary _visualToolMenuItemDictionary =
            new VisualToolActionButtonsDictionary();

        /// <summary>
        /// The action activation count.
        /// </summary>
        int _actionActivationCount = 0;

        /// <summary>
        /// A value indicating whether the activating action can change the visual tool of image viewer.
        /// </summary>
        bool _canChangeVisualTool = true;

        /// <summary>
        /// The previous action of visual tool.
        /// </summary>
        VisualToolAction _previousActionOfVisualTool = null;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualToolsToolStrip"/> class.
        /// </summary>
        public VisualToolsToolStrip()
            : base()
        {
            InitializeComponent();

            Enabled = false;

            // Add "None" action

            Image icon = DemosResourcesManager.GetResourceAsBitmap(
                "DemosCommonCode.Imaging.VisualToolsToolStrip.Resources.None.png");
            _noneVisualToolAction = new NoneAction("None", "None", icon);
            AddAction(_noneVisualToolAction);

            _actionStatusLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
        }

        #endregion



        #region Properties

        #region PUBLIC

        ImageViewer _imageViewer = null;
        /// <summary>
        /// Gets or sets an image viewer, which is associated with this tool strip.
        /// </summary>
        /// <value>
        /// Default value <b>null</b>.
        /// </value>
        [Description("The image viewer, which is associated with this toolstrip.")]
        [Browsable(true)]
        public ImageViewer ImageViewer
        {
            get
            {
                return _imageViewer;
            }
            set
            {
                if (DesignMode || ImagingEnvironment.IsInDesignMode)
                {
                    _imageViewer = value;
                }
                else
                {
                    if (_imageViewer != null)
                        UnsubscribeFromImageViewerEvents(_imageViewer);

                    _imageViewer = value;

                    if (_imageViewer == null)
                    {
                        Enabled = false;
                    }
                    else
                    {
                        if (_imageViewer.FocusedIndex == -1)
                            Enabled = false;
                        else
                            Enabled = true;

                        SubscribeToImageViewerEvents(_imageViewer);
                    }

                    UpdateSelectedItem();
                }
            }
        }

        List<VisualToolAction> _visualToolActions = new List<VisualToolAction>();
        /// <summary>
        /// Gets the read-only collection of <see cref="VisualToolAction"/> objects, which were added to this <see cref="VisualToolsToolStrip"/>.
        /// </summary>
        [Browsable(false)]
        public ReadOnlyCollection<VisualToolAction> VisualToolActions
        {
            get
            {
                return _visualToolActions.AsReadOnly();
            }
        }

        VisualTool _mandatoryVisualTool = null;
        /// <summary>
        /// Gets or sets the mandatory visual tool.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        /// <remarks>
        /// The mandatory visual tool is always active because is always used in composition with selected visual tool.
        /// </remarks>
        [Browsable(false)]
        public virtual VisualTool MandatoryVisualTool
        {
            get
            {
                return _mandatoryVisualTool;
            }
            set
            {
                if (_mandatoryVisualTool != value)
                {
                    VisualToolAction currentAction = _currentActionOfVisualTool;

                    if (currentAction != null)
                        currentAction.Deactivate();

                    _visualToolItemToVisualTool.Clear();

                    _mandatoryVisualTool = value;

                    if (currentAction != null)
                        currentAction.Activate();
                }
            }
        }

        ToolStripMenuItem _visualToolsMenuItem = null;
        /// <summary>
        /// Gets or sets the visual tools menu item, which duplicates this toolstrip.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Description("The visual tools menu item, which duplicates this toolstrip.")]
        public ToolStripMenuItem VisualToolsMenuItem
        {
            get
            {
                return _visualToolsMenuItem;
            }
            set
            {
                if (_visualToolsMenuItem != value)
                {
                    if (_visualToolsMenuItem != null)
                        RemoveVisualToolActionsFromMenu(_visualToolsMenuItem);

                    _visualToolsMenuItem = value;

                    if (_visualToolsMenuItem != null)
                        AddVisualToolActionsToMenu(_visualToolsMenuItem);
                }
            }
        }

        #endregion


        #region PROTECTED

        VisualToolAction _currentActionOfVisualTool = null;
        /// <summary>
        /// The currently action of visual tool.
        /// </summary>
        protected VisualToolAction CurrentActionOfVisualTool
        {
            get
            {
                return _currentActionOfVisualTool;
            }
        }

        #endregion

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Resets the current visual tool of image viewer to the default visual tool.
        /// </summary>
        public void Reset()
        {
            if (!_noneVisualToolAction.IsActivated)
                _noneVisualToolAction.Activate();
        }

        /// <summary>
        /// Adds the visual tool action to this tool strip.
        /// </summary>
        /// <param name="visualToolAction">The visual tool action.</param>
        public void AddAction(VisualToolAction visualToolAction)
        {
            AddVisualToolActionToToolstrip(Items, visualToolAction, _toolStripDictionary);

            if (_visualToolsMenuItem != null)
            {
                AddVisualToolActionToToolstrip(
                    _visualToolsMenuItem.DropDownItems,
                    visualToolAction,
                    _visualToolMenuItemDictionary);
            }

            SubscribeToVisualToolActions(visualToolAction);

            // save added item
            _visualToolActions.Add(visualToolAction);

            UpdateSelectedItem();
        }

        /// <summary>
        /// Finds the specified action of specified type in tool strip.
        /// </summary>
        /// <typeparam name="T">The action type to find.</typeparam>
        /// <returns>
        /// The item of specified type if action is found; otherwise, <b>null</b>.
        /// </returns>
        public T FindAction<T>()
            where T : VisualToolAction
        {
            foreach (VisualToolAction item in _visualToolActions)
            {
                if (item is T)
                    return (T)item;
            }

            return null;
        }

        /// <summary>
        /// Determines whether the tool strip contains the specified action of specified type.
        /// </summary>
        /// <typeparam name="T">The action type.</typeparam>
        /// <returns>
        /// <b>True</b> the action of specified type is exist; otherwise, <b>false</b>.
        /// </returns>
        public bool ContainsAction<T>()
            where T : VisualToolAction
        {
            if (FindAction<T>() == null)
                return false;

            return true;
        }

        /// <summary>
        /// Sets the previous action of visual tool.
        /// </summary>
        /// <returns>
        /// <b>True</b> the action is changed; otherwise, <b>false</b>.
        /// </returns>
        public bool SetPreviousAction()
        {
            // if previous action of visual tool is not defined
            if (_previousActionOfVisualTool == null)
                return false;

            // activate previous action of visual tool
            _previousActionOfVisualTool.Activate();

            return true;
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.ToolStrip.ItemAdded"/> event.
        /// It is called when the item has been selected.
        /// </summary>
        /// <param name="e">An <see cref="System.Windows.Forms.ToolStripItemEventArgs"/> that contains the event data.</param>
        protected override void OnItemAdded(ToolStripItemEventArgs e)
        {
            base.OnItemAdded(e);

            if (!_isActionStatusLabelMoving)
            {
                if (Items.Count - 1 != Items.IndexOf(_actionStatusLabel))
                {
                    _isActionStatusLabelMoving = true;

                    // move action status label

                    this.Items.Remove(_actionStatusLabel);
                    this.Items.Add(_actionStatusLabel);

                    _isActionStatusLabelMoving = false;
                }
            }
        }

        /// <summary>
        /// Returns the visual tool, which is associated with specified visual tool action.
        /// </summary>
        /// <param name="visualToolAction">The visual tool action.</param>
        /// <returns>
        /// The visual tool.
        /// </returns>
        protected virtual VisualTool GetVisualTool(VisualToolAction visualToolAction)
        {
            // if mandatory visual tool is not specified
            if (MandatoryVisualTool == null)
                return visualToolAction.VisualTool;

            // get current visual tool
            VisualTool result = visualToolAction.VisualTool;

            // if visual tool must be created
            if (!_visualToolItemToVisualTool.TryGetValue(visualToolAction, out result))
            {
                // if action visual tool is not specified
                if (visualToolAction.VisualTool == null)
                {
                    // use mandatory visual tool
                    result = MandatoryVisualTool;
                }
                else
                {
                    // create composite visual tool: mandatory visual tool + action visual tool
                    CompositeVisualTool compositeTool = new CompositeVisualTool(
                        MandatoryVisualTool, visualToolAction.VisualTool);
                    // set active visual tool
                    compositeTool.ActiveTool = visualToolAction.VisualTool;
                    result = compositeTool;
                }

                // save current visual tool
                _visualToolItemToVisualTool.Add(visualToolAction, result);
            }

            return result;
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Adds the visual tools actions to the specified <see cref="ToolStripMenuItem"/>.
        /// </summary>
        /// <param name="visualToolsMenuItem">The menu item.</param>
        private void AddVisualToolActionsToMenu(ToolStripMenuItem visualToolsMenuItem)
        {
            foreach (VisualToolAction visualToolAction in VisualToolActions)
            {
                AddVisualToolActionToToolstrip(
                    visualToolsMenuItem.DropDownItems,
                    visualToolAction,
                    _visualToolMenuItemDictionary);
            }
        }

        /// <summary>
        /// Removes the visual tools actions from the specified <see cref="ToolStripMenuItem"/>.
        /// </summary>
        /// <param name="visualToolsMenuItem">The menu item.</param>
        private void RemoveVisualToolActionsFromMenu(ToolStripMenuItem visualToolsMenuItem)
        {
            foreach (VisualToolAction visualToolAction in VisualToolActions)
            {
                if (_visualToolMenuItemDictionary.Contains(visualToolAction))
                {
                    ToolStripItem item = _visualToolMenuItemDictionary.GetItem(visualToolAction);

                    visualToolsMenuItem.DropDownItems.Remove(item);
                }
            }

            _visualToolMenuItemDictionary.Clear();
        }

        /// <summary>
        /// Subscribes to the events of visual tool action and sub-actions.
        /// </summary>
        /// <param name="visualToolAction">The visual tool action.</param>
        private void SubscribeToVisualToolActions(VisualToolAction visualToolAction)
        {
            if (visualToolAction is SeparatorToolStripAction)
                return;

            // subscribe to the visual tool action events
            visualToolAction.Activated += new EventHandler(visualToolAction_Activated);
            visualToolAction.Deactivated += new EventHandler(visualToolAction_Deactivated);
            visualToolAction.StatusChanged += new EventHandler(visualToolAction_StatusChanged);
            visualToolAction.IconChanged += new EventHandler(visualToolAction_IconChanged);

            // if action contains sub-actions
            if (visualToolAction.HasSubactions)
            {
                foreach (VisualToolAction subAction in visualToolAction.SubActions)
                    SubscribeToVisualToolActions(subAction);
            }
        }

        /// <summary>
        /// Adds the specified visual tool action to the specified collection.
        /// </summary>
        /// <param name="toolStripItemCollection">The item collection of toolstrip.</param>
        /// <param name="visualToolAction">The visual tool action.</param>
        /// <param name="visualToolActionsDictionary">A dictionary, which contains links between visual tool actions and buttons.</param>
        private void AddVisualToolActionToToolstrip(
            ToolStripItemCollection toolStripItemCollection,
            VisualToolAction visualToolAction,
            VisualToolActionButtonsDictionary visualToolActionsDictionary)
        {
            ToolStripItem toolStripItem;
            // if new toolstrip item must be added to the collection of this toolstrip
            if (toolStripItemCollection == Items)
                // create the toolstip item for visual tool action
                toolStripItem = CreateToolStripItem(visualToolAction, true);
            // if new toolstrip item must be added to the collection of other toolstrip
            else
                // create the toolstip item for visual tool action
                toolStripItem = CreateToolStripItem(visualToolAction, false);

            // if action is not separator
            if (!(visualToolAction is SeparatorToolStripAction))
            {
                // save information about link between action and toolstrip item
                visualToolActionsDictionary.Add(visualToolAction, toolStripItem);

                // update action check state
                UpdateActionCheckState(visualToolAction);

                // if toolstrip item is split button
                if (toolStripItem is CheckedToolStripSplitButton)
                {
                    CheckedToolStripSplitButton button = (CheckedToolStripSplitButton)toolStripItem;
                    // subscribe to the button click event
                    button.ButtonClick += new EventHandler(ActionItem_Click);
                }
                else
                {
                    // subscribe to the item click event
                    toolStripItem.Click += new EventHandler(ActionItem_Click);
                }

                // if visual tool action contains sub-actions
                if (visualToolAction.HasSubactions)
                {
                    ToolStripItemCollection subActions = null;

                    if (toolStripItem is CheckedToolStripSplitButton)
                    {
                        CheckedToolStripSplitButton checkedToolStripSplitButton = (CheckedToolStripSplitButton)toolStripItem;
                        checkedToolStripSplitButton.DropDownOpened += Button_DropDownOpened;
                        subActions = checkedToolStripSplitButton.DropDownItems;
                    }
                    else if (toolStripItem is ToolStripMenuItem)
                    {
                        ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)toolStripItem;
                        toolStripMenuItem.DropDownOpened += Button_DropDownOpened;
                        subActions = toolStripMenuItem.DropDownItems;
                    }

                    // for each sub-action
                    foreach (VisualToolAction subAction in visualToolAction.SubActions)
                    {
                        AddVisualToolActionToToolstrip(subActions, subAction, visualToolActionsDictionary);
                    }
                }
            }

            // add the toolstrip item to the toolstrip
            toolStripItemCollection.Add(toolStripItem);
        }

        /// <summary>
        /// Updates action status.
        /// </summary>
        private void visualToolAction_StatusChanged(object sender, EventArgs e)
        {
            string status = ((VisualToolAction)sender).Status;
            if (_actionStatusLabel.Text != status)
                _actionStatusLabel.Text = status;
        }

        /// <summary>
        /// Changes image viewer visual tool and checks the action.
        /// </summary>
        private void visualToolAction_Activated(object sender, EventArgs e)
        {
            // update previous action of visual tool
            _previousActionOfVisualTool = _currentActionOfVisualTool;

            _actionActivationCount++;

            VisualToolAction action = (VisualToolAction)sender;

            // update action check state
            UpdateActionCheckState(action);

            // if visual tool must be changed
            if (action.CanChangeImageViewerVisualTool)
            {
                if (_currentActionOfVisualTool != null)
                    // deactivate previous visual tool action
                    _currentActionOfVisualTool.Deactivate();

                if (_canChangeVisualTool && ImageViewer != null)
                {
                    // change visual tool
                    ImageViewer.VisualTool = GetVisualTool(action);

                    if (ImageViewer.VisualTool is CompositeVisualTool)
                        ChangeActiveTool((CompositeVisualTool)ImageViewer.VisualTool, action.VisualTool);
                }

                _currentActionOfVisualTool = action;
            }

            _actionActivationCount--;
        }

        /// <summary>
        /// Changes image viewer visual tool and unchecks the action.
        /// </summary>
        private void visualToolAction_Deactivated(object sender, EventArgs e)
        {
            VisualToolAction action = (VisualToolAction)sender;

            // update action check state
            UpdateActionCheckState(action);

            // if visual tool can not be changed
            if (!action.CanChangeImageViewerVisualTool)
                return;

            if (_canChangeVisualTool && ImageViewer != null)
            {
                bool isActiveToolChanged = false;

                if (ImageViewer.VisualTool is CompositeVisualTool)
                    isActiveToolChanged = ChangeActiveTool((CompositeVisualTool)ImageViewer.VisualTool, null);

                if (!isActiveToolChanged)
                {
                    // remove visual tool
                    ImageViewer.VisualTool = null;
                }
            }

            if (_currentActionOfVisualTool == action)
                // remove current visual tool action
                _currentActionOfVisualTool = null;
        }

        /// <summary>
        /// Updates icon of action.
        /// </summary>
        private void visualToolAction_IconChanged(object sender, EventArgs e)
        {
            // get action
            VisualToolAction action = (VisualToolAction)sender;

            if (_toolStripDictionary.Contains(action))
            {
                // get tool strip item of action
                ToolStripItem toolStripItem = _toolStripDictionary.GetItem(action);

                // update icon
                toolStripItem.Image = action.Icon;
            }

            if (_visualToolMenuItemDictionary.Contains(action))
            {
                // get tool strip item of action
                ToolStripItem visualToolsMenuItem = _visualToolMenuItemDictionary.GetItem(action);

                // update icon
                visualToolsMenuItem.Image = action.Icon;
            }
        }

        /// <summary>
        /// Returns the action of specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        private VisualToolAction GetAction(ToolStripItem item)
        {
            if (_toolStripDictionary.Contains(item))
                return _toolStripDictionary.GetAction(item);
            else if (_visualToolMenuItemDictionary.Contains(item))
                return _visualToolMenuItemDictionary.GetAction(item);
            else
                throw new InvalidOperationException();
        }

        /// <summary>
        /// Activates the action of drop-down menu.
        /// </summary>
        private void Button_DropDownOpened(object sender, EventArgs e)
        {
            // get current action
            VisualToolAction action = GetAction((ToolStripItem)sender);

            // if current action is not activated
            if (action != null && !action.IsActivated)
                action.Activate();
        }

        /// <summary>
        /// Activates the action.
        /// </summary>
        private void ActionItem_Click(object sender, EventArgs e)
        {
            VisualToolAction action = GetAction((ToolStripItem)sender);

            // if action is activated
            if (action.IsActivated)
            {
                // show visual tool settings
                action.ShowVisualToolSettings();
            }
            else
            {
                // activate action
                action.Activate();
            }

            // click on action
            action.Click();
        }

        /// <summary>
        /// Updates the check state of action.
        /// </summary>
        /// <param name="visualToolAction">The visual tool action.</param>
        private void UpdateActionCheckState(VisualToolAction visualToolAction)
        {
            // if action can not be checked
            if (!visualToolAction.CheckActionButtonOnActivate)
                return;

            if (_toolStripDictionary.Contains(visualToolAction))
                UpdateToolStripItemCheckState(visualToolAction, _toolStripDictionary.GetItem(visualToolAction));

            if (_visualToolMenuItemDictionary.Contains(visualToolAction))
                UpdateToolStripItemCheckState(visualToolAction, _visualToolMenuItemDictionary.GetItem(visualToolAction));
        }

        /// <summary>
        /// Updates the check state the specified tool strip item of action.
        /// </summary>
        /// <param name="visualToolAction">The visual tool action.</param>
        /// <param name="toolStripItem">The tool strip item.</param>
        private void UpdateToolStripItemCheckState(VisualToolAction visualToolAction, ToolStripItem toolStripItem)
        {
            // get tool strip button
            ToolStripButton button = toolStripItem as ToolStripButton;

            // if tool strip item is tool strip button
            if (button != null)
            {
                // update check state
                button.Checked = visualToolAction.IsActivated;
            }
            else
            {
                // get tool strip split button
                CheckedToolStripSplitButton splitButton = toolStripItem as CheckedToolStripSplitButton;

                // if tool strip item is tool strip split button
                if (splitButton != null)
                {
                    // update check state
                    splitButton.Checked = visualToolAction.IsActivated;
                }
                else
                {
                    // get tool strip menu item
                    ToolStripMenuItem menuItem = toolStripItem as ToolStripMenuItem;

                    // if tool strip item is tool strip menu item
                    if (menuItem != null)
                    {
                        // update check state
                        menuItem.Checked = visualToolAction.IsActivated;
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }

        /// <summary>
        /// Creates the tool strip item for specified action.
        /// </summary>
        /// <param name="visualToolAction">The visual tool action.</param>
        /// <param name="createToolStripButton">A value indicating whether the tool strip button must be created.</param>
        /// <returns>
        /// The tool strip item
        /// </returns>
        private ToolStripItem CreateToolStripItem(
            VisualToolAction visualToolAction,
            bool createToolStripButton)
        {
            // if tool strip separator must be created
            if (visualToolAction is SeparatorToolStripAction)
                return new ToolStripSeparator();

            ToolStripItem toolStripItem;

            // if tool strip button must be created
            if (createToolStripButton)
            {
                // if action has subactions
                if (visualToolAction.HasSubactions)
                {
                    // create tool strip split button
                    toolStripItem = new CheckedToolStripSplitButton();
                }
                else
                {
                    // create tool strip button
                    toolStripItem = new ToolStripButton();
                }
            }
            else
            {
                // create tool strip menu item
                toolStripItem = new ToolStripMenuItem();
            }

            // set tool strip item text
            toolStripItem.Text = visualToolAction.Text;
            // set tool strip item tooltip
            toolStripItem.ToolTipText = visualToolAction.ToolTip;

            // if tool strip items is button
            if (createToolStripButton)
                toolStripItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            else
                toolStripItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

            // set tool strip item icon
            toolStripItem.Image = visualToolAction.Icon;
            toolStripItem.ImageScaling = ToolStripItemImageScaling.None;

            return toolStripItem;
        }

        /// <summary>
        /// Changes the active visual tool in composite visual tool.
        /// </summary>
        /// <param name="compositeVisualTool">The composite visual tool.</param>
        /// <param name="activeTool">The active tool.</param>
        /// <returns>
        /// <b>True</b> if active visual tool is changed; otherwise, <b>false</b>.
        /// </returns>
        private bool ChangeActiveTool(CompositeVisualTool compositeVisualTool, VisualTool activeTool)
        {
            if (activeTool == null)
            {
                compositeVisualTool.ActiveTool = null;

                return true;
            }
            else
            {
                foreach (VisualTool tool in compositeVisualTool)
                {
                    if (tool == activeTool)
                    {
                        compositeVisualTool.ActiveTool = activeTool;
                        return true;
                    }
                    else if (tool is CompositeVisualTool)
                    {
                        CompositeVisualTool nestedCompositeTool = (CompositeVisualTool)tool;

                        if (ChangeActiveTool(nestedCompositeTool, activeTool))
                        {
                            compositeVisualTool.ActiveTool = nestedCompositeTool;
                            return true;
                        }
                    }
                }

                return false;
            }
        }


        #region Image Viewer

        /// <summary>
        /// Subscribes to image viewer events.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void SubscribeToImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged += new EventHandler<FocusedIndexChangedEventArgs>(ImageViewer_FocusedIndexChanged);
            imageViewer.VisualToolChanged += new EventHandler<VisualToolChangedEventArgs>(ImageViewer_VisualToolChanged);
        }

        /// <summary>
        /// Unsubscribes from image viewer events.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void UnsubscribeFromImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged -= ImageViewer_FocusedIndexChanged;
            imageViewer.VisualToolChanged -= ImageViewer_VisualToolChanged;
        }

        /// <summary>
        /// Updates the selected tool strip item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FocusedIndexChangedEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            bool isEnabled = false;
            if (e.FocusedIndex != -1)
                isEnabled = true;

            Enabled = isEnabled;
            if (isEnabled)
                UpdateSelectedItem();
        }

        /// <summary>
        /// The visual tool is changed in image viewer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisualToolChangedEventArgs"/> instance containing the event data.</param>
        private void ImageViewer_VisualToolChanged(object sender, VisualToolChangedEventArgs e)
        {
            if (_actionActivationCount == 0)
                UpdateSelectedItem();
        }

        /// <summary>
        /// Updates the selected visual tool item.
        /// </summary>
        private void UpdateSelectedItem()
        {
            // if image viewer is not specified
            if (ImageViewer == null)
                return;

            // if current visual tool action is specified
            if (_currentActionOfVisualTool != null)
            {
                // if visual tool action is selected
                if (ImageViewer.VisualTool == GetVisualTool(_currentActionOfVisualTool))
                    return;
            }

            // get current visual tool action
            VisualToolAction currentVisualToolAction = _noneVisualToolAction;

            // for each visual tool actions
            foreach (VisualToolAction action in _visualToolActions)
            {
                // if action must be selected
                if (ImageViewer.VisualTool == GetVisualTool(action))
                {
                    currentVisualToolAction = action;
                    break;
                }
            }

            // if action is not activated
            if (!currentVisualToolAction.IsActivated)
            {
                _canChangeVisualTool = false;
                currentVisualToolAction.Activate();
                _canChangeVisualTool = true;
            }
        }

        #endregion

        #endregion

        #endregion

    }
}
