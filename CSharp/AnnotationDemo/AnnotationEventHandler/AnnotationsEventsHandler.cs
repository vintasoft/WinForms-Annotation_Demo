using System;
using System.Windows.Forms;

using Vintasoft.Imaging;

using Vintasoft.Imaging.Annotation;
using Vintasoft.Imaging.Annotation.UI;

namespace AnnotationDemo
{
    /// <summary>
    /// Class that handles all events of annotation and annotation collection.
    /// </summary>
    public class AnnotationsEventsHandler
    {

        #region Fields

        AnnotationViewer _annotationViewer;
        bool _handleDataEvents;
        bool _handleViewEvents;

        #endregion



        #region Constructor

        public AnnotationsEventsHandler(
            AnnotationViewer annotationViewer,
            bool handleDataEvents,
            bool handleViewEvents)
        {
            _annotationViewer = annotationViewer;
            _handleViewEvents = handleViewEvents;
            _handleDataEvents = handleDataEvents;
            _annotationViewer.AnnotationDataControllerChanged += new EventHandler<AnnotationDataControllerChangedEventArgs>(AnnotationViewer_AnnotationsDataChanged);
            _annotationViewer.AnnotationViewCollectionChanged += new EventHandler<AnnotationViewCollectionChangedEventArgs>(AnnotationViewer_SelectedAnnotationViewCollectionChanged);

            if (_annotationViewer.AnnotationViewCollection != null)
                SubscribeToAnnotationDataCollectionEvents(_annotationViewer.AnnotationViewCollection.DataCollection);
        }

        #endregion



        #region Properties

        bool _isEnabled = false;
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

        protected AnnotationViewer Viewer
        {
            get
            {
                return _annotationViewer;
            }
        }

        #endregion
        


        #region Methods

        #region PROTECTED

        protected virtual void OnAnnotationDataControllerChanged(AnnotationViewer viewer, PropertyChangedEventArgs<AnnotationDataController> e)
        {
        }

        protected virtual void OnAnnotationViewCollectionChanged(AnnotationViewer viewer, PropertyChangedEventArgs<AnnotationViewCollection> e)
        {
        }

        protected virtual void OnDataCollectionChanging(AnnotationDataCollection annotationDataCollection, CollectionChangeEventArgs<AnnotationData> e)
        {
        }

        protected virtual void OnDataCollectionChanged(AnnotationDataCollection annotationDataCollection, CollectionChangeEventArgs<AnnotationData> e)
        {
        }

        protected virtual void OnAnnotationDataPropertyChanging(AnnotationDataCollection annotationDataCollection, AnnotationData annotationData, ObjectPropertyChangingEventArgs e)
        {
        }

        protected virtual void OnAnnotationDataPropertyChanged(AnnotationDataCollection annotationDataCollection, AnnotationData annotationData, ObjectPropertyChangedEventArgs e)
        {
        }

        protected virtual void OnMouseWheel(AnnotationView annotationView, MouseEventArgs e)
        {            
        }

        protected virtual void OnMouseUp(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        protected virtual void OnMouseDown(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        protected virtual void OnMouseMove(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        protected virtual void OnClick(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        protected virtual void OnDoubleClick(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        protected virtual void OnMouseEnter(AnnotationView annotationView, MouseEventArgs e)
        {
        }

        #endregion


        #region PRIVATE

        private void AnnotationViewer_AnnotationsDataChanged(object sender, AnnotationDataControllerChangedEventArgs e)
        {
            OnAnnotationDataControllerChanged((AnnotationViewer)sender, e);
        }

        private void AnnotationViewer_SelectedAnnotationViewCollectionChanged(object sender, AnnotationViewCollectionChangedEventArgs e)
        {
            if (e.OldValue != null)
                UnubscribeFromAnnotationDataCollectionEvents(e.OldValue.DataCollection);

            if (e.NewValue != null)
                SubscribeToAnnotationDataCollectionEvents(e.NewValue.DataCollection);

            if (_isEnabled)
                OnAnnotationViewCollectionChanged((AnnotationViewer)sender, e);
        }

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

        private void UnubscribeFromAnnotationDataCollectionEvents(AnnotationDataCollection dataCollection)
        {
            if (_handleViewEvents)
            {
                AnnotationViewCollection viewCollection = _annotationViewer.AnnotationViewController.GetAnnotationsView(dataCollection);
                foreach (AnnotationView view in viewCollection)
                    UnsubscribeFromAnnotationViewEvents(view);
            }

            if (_handleDataEvents)
                dataCollection.ItemPropertyChanged -= new EventHandler<AnnotationDataPropertyChangedEventArgs>(dataCollection_ItemPropertyChanged);

            dataCollection.Changing -= new CollectionChangeEventHandler<AnnotationData>(dataCollection_Changing);
            dataCollection.Changed -= new CollectionChangeEventHandler<AnnotationData>(dataCollection_Changed);
        }


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

        private void dataCollection_Changing(object sender, CollectionChangeEventArgs<AnnotationData> e)
        {            
            if (_isEnabled)
                OnDataCollectionChanging((AnnotationDataCollection)sender, e);
        }

        private void dataCollection_Changed(object sender, CollectionChangeEventArgs<AnnotationData> e)
        {
            if (e.Action == CollectionChangeActionType.InsertItem || e.Action == CollectionChangeActionType.SetItem)
            {
                AnnotationDataCollection dataCollection = (AnnotationDataCollection)sender;
                AnnotationViewCollection viewCollection = _annotationViewer.AnnotationViewController.GetAnnotationsView(dataCollection);
                SubscribeToAnnotationViewEvents(viewCollection.FindView(e.NewValue));
            }
            if (_isEnabled)
                OnDataCollectionChanged((AnnotationDataCollection)sender, e);
        }

        private void dataCollection_ItemPropertyChanging(object sender, AnnotationDataPropertyChangingEventArgs e)
        {
            if (_isEnabled)
                OnAnnotationDataPropertyChanging((AnnotationDataCollection)sender, e.AnnotationData, e.ChangingArgs);
        }

        private void dataCollection_ItemPropertyChanged(object sender, AnnotationDataPropertyChangedEventArgs e)
        {
            if (_isEnabled)
                OnAnnotationDataPropertyChanged((AnnotationDataCollection)sender, e.AnnotationData, e.ChangedArgs);
        }

        private void annotationView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseWheel((AnnotationView)sender, e);
        }

        private void annotationView_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseUp((AnnotationView)sender, e);
        }

        private void annotationView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseMove((AnnotationView)sender, e);
        }

        private void annotationView_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseWheel((AnnotationView)sender, e);
        }

        private void annotationView_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseEnter((AnnotationView)sender, e);
        }

        private void annotationView_MouseDown(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnMouseDown((AnnotationView)sender, e);
        }

        private void annotationView_DoubleClick(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnDoubleClick((AnnotationView)sender, e);
        }

        private void annotationView_Click(object sender, MouseEventArgs e)
        {
            if (_isEnabled)
                OnClick((AnnotationView)sender, e);
        }

        #endregion

        #endregion

    }
}
