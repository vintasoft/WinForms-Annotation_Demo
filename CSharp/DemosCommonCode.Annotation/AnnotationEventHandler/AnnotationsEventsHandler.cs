using System;
using System.Windows.Forms;

using Vintasoft.Imaging;

using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;

namespace DemosCommonCode.Annotation
{
    /// <summary>
    /// Class that handles all events of annotation and annotation collection.
    /// </summary>
    public class AnnotationsEventsHandler
    {

        #region Fields

        /// <summary>
        /// A value indicating whether the annotation data changes must be tracked.
        /// </summary>
        bool _handleDataEvents;

        /// <summary>
        /// A value indicating whether the annotation view changes must be tracked.
        /// </summary>
        bool _handleViewEvents;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnotationsEventsHandler"/> class.
        /// </summary>
        /// <param name="viewer">The annotation viewer.</param>
        /// <param name="handleDataEvents">A value indicating whether the annotation data changes must be tracked.</param>
        /// <param name="handleViewEvents">A value indicating whether the annotation view changes must be tracked.</param>
        public AnnotationsEventsHandler(
            AnnotationViewer viewer,
            bool handleDataEvents,
            bool handleViewEvents)
        {
            _annotationViewer = viewer;
            _handleViewEvents = handleViewEvents;
            _handleDataEvents = handleDataEvents;
            _annotationViewer.AnnotationDataControllerChanged += 
                new EventHandler<AnnotationDataControllerChangedEventArgs>(AnnotationViewer_AnnotationsDataChanged);
            _annotationViewer.AnnotationViewCollectionChanged += 
                new EventHandler<AnnotationViewCollectionChangedEventArgs>(AnnotationViewer_SelectedAnnotationViewCollectionChanged);

            if (_annotationViewer.AnnotationViewCollection != null)
                SubscribeToAnnotationDataCollectionEvents(_annotationViewer.AnnotationViewCollection.DataCollection);
        }

        #endregion



        #region Properties

        bool _isEnabled = false;
        /// <summary>
        /// Gets or sets a value indicating whether <see cref="AnnotationsEventsHandler"/>
        /// must track annotation events.
        /// </summary>
        /// <value>
        /// <b>True</b> if <see cref="AnnotationsEventsHandler"/> 
        /// must track annotation events; otherwise, <b>false</b>.
        /// </value>
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
            }
        }

        AnnotationViewer _annotationViewer;
        /// <summary>
        /// Get the annotation viewer.
        /// </summary>
        protected AnnotationViewer AnnotationViewer
        {
            get
            {
                return _annotationViewer;
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// The annotation data controller is changed.
        /// </summary>
        /// <param name="viewer">The annotation viewer.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{AnnotationDataController}"/> instance containing the event data.</param>
        protected virtual void OnAnnotationDataControllerChanged(AnnotationViewer viewer, PropertyChangedEventArgs<AnnotationDataController> e)
        {
        }

        /// <summary>
        /// The annotation view collection is changed.
        /// </summary>
        /// <param name="viewer">The annotation viewer.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs{AnnotationViewCollection}"/> instance containing the event data.</param>
        protected virtual void OnAnnotationViewCollectionChanged(AnnotationViewer viewer, PropertyChangedEventArgs<AnnotationViewCollection> e)
        {
        }

        /// <summary>
        /// The annotation data collection is changing.
        /// </summary>
        /// <param name="annotationDataCollection">The annotation data collection.</param>
        /// <param name="e">The <see cref="CollectionChangeEventArgs{AnnotationData}"/> instance containing the event data.</param>
        protected virtual void OnDataCollectionChanging(AnnotationDataCollection annotationDataCollection, CollectionChangeEventArgs<AnnotationData> e)
        {
        }

        /// <summary>
        /// The annotation data controller is changed.
        /// </summary>
        /// <param name="annotationDataCollection">The annotation data collection.</param>
        /// <param name="e">The <see cref="CollectionChangeEventArgs{AnnotationData}"/> instance containing the event data.</param>
        protected virtual void OnDataCollectionChanged(AnnotationDataCollection annotationDataCollection, CollectionChangeEventArgs<AnnotationData> e)
        {
        }

        /// <summary>
        /// The annotation data property is changing.
        /// </summary>
        /// <param name="annotationDataCollection">The annotation data collection.</param>
        /// <param name="annotationData">The annotation data.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangingEventArgs"/> instance containing the event data.</param>
        protected virtual void OnAnnotationDataPropertyChanging(
            AnnotationDataCollection annotationDataCollection, AnnotationData annotationData, ObjectPropertyChangingEventArgs e)
        {
        }

        /// <summary>
        /// The annotation data property is changed.
        /// </summary>
        /// <param name="annotationDataCollection">The annotation data collection.</param>
        /// <param name="annotationData">The annotation data.</param>
        /// <param name="e">The <see cref="ObjectPropertyChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnAnnotationDataPropertyChanged(
            AnnotationDataCollection annotationDataCollection, AnnotationData annotationData, ObjectPropertyChangedEventArgs e)
        {
        }

        /// <summary>
        /// The mouse whell moves while the annotation view has focus.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseWheel(AnnotationView annotationView, MouseEventArgs e)
        {            
        }

        /// <summary>
        /// The mouse is up on annotation.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseUp(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        /// <summary>
        /// The mouse is down on annotation.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseDown(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        /// <summary>
        /// The mouse is moved on annotation.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseMove(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        /// <summary>
        /// The mouse is clicked on annotation.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnClick(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        /// <summary>
        /// The mouse is double clicked on annotation.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDoubleClick(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        /// <summary>
        /// The mouse enters the annotation.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseEnter(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// The annotation data controller is changed.
        /// </summary>
        private void AnnotationViewer_AnnotationsDataChanged(object sender, AnnotationDataControllerChangedEventArgs e)
        {
            OnAnnotationDataControllerChanged((AnnotationViewer)sender, e);
        }

        /// <summary>
        /// The selected annotation view collection is changed.
        /// </summary>
        private void AnnotationViewer_SelectedAnnotationViewCollectionChanged(object sender, AnnotationViewCollectionChangedEventArgs e)
        {
            if (e.OldValue != null)
                UnubscribeFromAnnotationDataCollectionEvents(e.OldValue.DataCollection);

            if (e.NewValue != null)
                SubscribeToAnnotationDataCollectionEvents(e.NewValue.DataCollection);

            if (_isEnabled)
                OnAnnotationViewCollectionChanged((AnnotationViewer)sender, e);
        }


        #region Annotation Data Collection

        /// <summary>
        /// Subscribes to the <see cref="AnnotationDataCollection"/> events.
        /// </summary>
        /// <param name="dataCollection">The annotation data collection.</param>
        private void SubscribeToAnnotationDataCollectionEvents(AnnotationDataCollection dataCollection)
        {
            dataCollection.Changing += new CollectionChangeEventHandler<AnnotationData>(dataCollection_Changing);
            dataCollection.Changed += new CollectionChangeEventHandler<AnnotationData>(dataCollection_Changed);

            if (_handleDataEvents)
            {
                dataCollection.ItemPropertyChanging += new EventHandler<AnnotationDataPropertyChangingEventArgs>(dataCollection_ItemPropertyChanging);
                dataCollection.ItemPropertyChanged += new EventHandler<AnnotationDataPropertyChangedEventArgs>(dataCollection_ItemPropertyChanged);
            }

            if (_handleViewEvents)
            {
                AnnotationViewCollection viewCollection = _annotationViewer.AnnotationViewController.GetAnnotationsView(dataCollection);
                foreach (AnnotationView view in viewCollection)
                    SubscribeToAnnotationViewEvents(view);
            }
        }

        /// <summary>
        /// Unsubscribes from <see cref="AnnotationDataCollection"/> events.
        /// </summary>
        /// <param name="dataCollection">The annotation data collection.</param>
        private void UnubscribeFromAnnotationDataCollectionEvents(AnnotationDataCollection dataCollection)
        {
            if (_handleViewEvents)
            {
                AnnotationViewCollection viewCollection = _annotationViewer.AnnotationViewController.GetAnnotationsView(dataCollection);
                foreach (AnnotationView view in viewCollection)
                    UnsubscribeFromAnnotationViewEvents(view);
            }

            if (_handleDataEvents)
            {
                dataCollection.ItemPropertyChanging -= new EventHandler<AnnotationDataPropertyChangingEventArgs>(dataCollection_ItemPropertyChanging);
                dataCollection.ItemPropertyChanged -= new EventHandler<AnnotationDataPropertyChangedEventArgs>(dataCollection_ItemPropertyChanged);
            }

            dataCollection.Changing -= new CollectionChangeEventHandler<AnnotationData>(dataCollection_Changing);
            dataCollection.Changed -= new CollectionChangeEventHandler<AnnotationData>(dataCollection_Changed);
        }

        /// <summary>
        /// The annotation data collection item property is changing.
        /// </summary>
        private void dataCollection_ItemPropertyChanging(object sender, AnnotationDataPropertyChangingEventArgs e)
        {
            if (_isEnabled)
                OnAnnotationDataPropertyChanging((AnnotationDataCollection)sender, e.AnnotationData, e.ChangingArgs);
        }

        /// <summary>
        /// The annotation data collection item property is changed.
        /// </summary>
        private void dataCollection_ItemPropertyChanged(object sender, AnnotationDataPropertyChangedEventArgs e)
        {
            if (_isEnabled)
                OnAnnotationDataPropertyChanged((AnnotationDataCollection)sender, e.AnnotationData, e.ChangedArgs);
        }

        /// <summary>
        /// The annotation data collection is changing.
        /// </summary>
        private void dataCollection_Changing(object sender, CollectionChangeEventArgs<AnnotationData> e)
        {
            if (_isEnabled)
                OnDataCollectionChanging((AnnotationDataCollection)sender, e);
        }

        /// <summary>
        /// The annotation data collection is changed.
        /// </summary>
        private void dataCollection_Changed(object sender, CollectionChangeEventArgs<AnnotationData> e)
        {
            // if annotation has been added to the collection
            if (e.Action == CollectionChangeActionType.InsertItem || e.Action == CollectionChangeActionType.SetItem)
            {
                AnnotationDataCollection dataCollection = (AnnotationDataCollection)sender;
                AnnotationViewCollection viewCollection = _annotationViewer.AnnotationViewController.GetAnnotationsView(dataCollection);
                // subscribe to the annotation view events
                SubscribeToAnnotationViewEvents(viewCollection.FindView(e.NewValue));
            }
            if (_isEnabled)
                OnDataCollectionChanged((AnnotationDataCollection)sender, e);
        }

        #endregion


        #region Annotation View

        /// <summary>
        /// Subscribes to <see cref="AnnotationView"/> events.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        private void SubscribeToAnnotationViewEvents(AnnotationView annotationView)
        {
            annotationView.Click += new MouseEventHandler(annotationView_Click);
            annotationView.DoubleClick += new MouseEventHandler(annotationView_DoubleClick);
            annotationView.MouseDown += new MouseEventHandler(annotationView_MouseDown);
            annotationView.MouseEnter += new MouseEventHandler(annotationView_MouseEnter);
            annotationView.MouseLeave += new MouseEventHandler(annotationView_MouseLeave);
            annotationView.MouseMove += new MouseEventHandler(annotationView_MouseMove);
            annotationView.MouseUp += new MouseEventHandler(annotationView_MouseUp);
            annotationView.MouseWheel += new MouseEventHandler(annotationView_MouseWheel);
        }

        /// <summary>
        /// Unsubscribes from <see cref="AnnotationView"/> events.
        /// </summary>
        /// <param name="annotationView">The annotation view.</param>
        private void UnsubscribeFromAnnotationViewEvents(AnnotationView annotationView)
        {
            annotationView.Click -= new MouseEventHandler(annotationView_Click);
            annotationView.DoubleClick -= new MouseEventHandler(annotationView_DoubleClick);
            annotationView.MouseDown -= new MouseEventHandler(annotationView_MouseDown);
            annotationView.MouseEnter -= new MouseEventHandler(annotationView_MouseEnter);
            annotationView.MouseLeave -= new MouseEventHandler(annotationView_MouseLeave);
            annotationView.MouseMove -= new MouseEventHandler(annotationView_MouseMove);
            annotationView.MouseUp -= new MouseEventHandler(annotationView_MouseUp);
            annotationView.MouseWheel -= new MouseEventHandler(annotationView_MouseWheel);
        }

        /// <summary>
        /// The mouse whell moves while the annotation view has focus.
        /// </summary>
        private void annotationView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseWheel((AnnotationView)sender, e);
        }

        /// <summary>
        /// The mouse is up on annotation view.
        /// </summary>
        private void annotationView_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseUp((AnnotationView)sender, e);
        }

        /// <summary>
        /// The mouse is moved on annotation view.
        /// </summary>
        private void annotationView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseMove((AnnotationView)sender, e);
        }

        /// <summary>
        /// The mouse leaves the annotation view.
        /// </summary>
        private void annotationView_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseWheel((AnnotationView)sender, e);
        }

        /// <summary>
        /// The mouse enters the annotation view.
        /// </summary>
        private void annotationView_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseEnter((AnnotationView)sender, e);
        }

        /// <summary>
        /// The mouse is down on annotation view.
        /// </summary>
        private void annotationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseDown((AnnotationView)sender, e);
        }

        /// <summary>
        /// The mouse is double clicked on annotation view.
        /// </summary>
        private void annotationView_DoubleClick(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnDoubleClick((AnnotationView)sender, e);
        }

        /// <summary>
        /// The mouse is clicked on annotation view.
        /// </summary>
        private void annotationView_Click(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnClick((AnnotationView)sender, e);
        } 

        #endregion

        #endregion

        #endregion

    }
}
