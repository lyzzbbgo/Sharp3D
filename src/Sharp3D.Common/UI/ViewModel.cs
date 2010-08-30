using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;

namespace Sharp3D.Common.UI
{
    /// <summary>
    /// Base class for view models.
    /// </summary>
    /// <remarks>
    /// This class provides basic support for implementing the <see cref="INotifyPropertyChanged"/> interface.
    /// </remarks>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        #region IsInDesignMode Property

        public static readonly bool IsInDesignMode = (bool) DependencyPropertyDescriptor.FromProperty(
            DesignerProperties.IsInDesignModeProperty, typeof (FrameworkElement)).Metadata.DefaultValue;

        #endregion

        #region XAML Support

        #region ViewModelType

        public static Type GetViewModelType(DependencyObject obj)
        {
            return (Type)obj.GetValue(ViewModelTypeProperty);
        }

        public static void SetViewModelType(DependencyObject obj, Type value)
        {
            obj.SetValue(ViewModelTypeProperty, value);
        }

        public static readonly DependencyProperty ViewModelTypeProperty =
            DependencyProperty.RegisterAttached("ViewModelType", typeof(Type), typeof(ViewModel),
                                                new UIPropertyMetadata(null, OnViewModelTypeChanged));

        private static void OnViewModelTypeChanged(DependencyObject dp, DependencyPropertyChangedEventArgs args)
        {
            var control = (Control) dp;
            var type = (Type) args.NewValue;
            if (type != null && !IsInDesignMode && ServiceLocator.Current != null)
            {
                var model = ServiceLocator.Current.GetInstance(type);
                control.DataContext = model;
            }
        }

        #endregion

        #region DesignViewModelType

        public static Type GetDesignViewModelType(DependencyObject obj)
        {
            return (Type)obj.GetValue(DesignViewModelTypeProperty);
        }

        public static void SetDesignViewModelType(DependencyObject obj, Type value)
        {
            obj.SetValue(DesignViewModelTypeProperty, value);
        }

        public static readonly DependencyProperty DesignViewModelTypeProperty =
            DependencyProperty.RegisterAttached("DesignViewModelType", typeof(Type), typeof(ViewModel),
                                                new UIPropertyMetadata(null, OnDesignViewModelTypeChanged));

        private static void OnDesignViewModelTypeChanged(DependencyObject dp, DependencyPropertyChangedEventArgs args)
        {
            var control = (Control) dp;
            var type = (Type) args.NewValue;
            if (type != null && IsInDesignMode)
            {
                control.DataContext = Activator.CreateInstance(type);
            }
        }

        #endregion
        
        #endregion

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Executes an action on the UI thread.
        /// </summary>
        /// <param name="action">Action to be executed.</param>
        protected void Execute(Action action)
        {
            Execute(action, ThreadKind.UI);
        }

        /// <summary>
        /// Executes an action.
        /// </summary>
        /// <param name="action">Action to be executed.</param>
        /// <param name="threadKind">Thread kind on which the action should be executed.</param>
        protected void Execute(Action action, ThreadKind threadKind)
        {
            if (threadKind == ThreadKind.Background)
            {
                WaitCallback waitCallback = p => action();
                ThreadPool.QueueUserWorkItem(waitCallback);
            }
            else
            {
                var dispatcher = Application.Current.Dispatcher;
                if (dispatcher.CheckAccess())
                {
                    action();
                }
                else
                {
                    dispatcher.BeginInvoke(action);
                }
            }
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that has a new value</typeparam>
        /// <param name="propertyExpression">A Lambda expression representing the property that has a new value.</param>
        protected void RaisePropertyChanged<T>(System.Linq.Expressions.Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertyExtensions.ExtractPropertyName(propertyExpression);
            RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}