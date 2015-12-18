﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DragDrop
{
    /// <summary>
    /// Represents a drag drop container
    /// </summary>
    public class DragDropContainer : Grid
    {
        #region Attached properties
        static public readonly DependencyProperty DragDropGroupNameProperty = DependencyProperty.RegisterAttached("DragDropGroupName", typeof(string), typeof(DragDropContainer), new UIPropertyMetadata(string.Empty, OnDragDropGroupNameChanged));
        static public string GetDragDropGroupName(DependencyObject obj)
        {
            return (string)obj.GetValue(DragDropGroupNameProperty);
        }
        static public void SetDragDropGroupName(DependencyObject obj, string value)
        {
            obj.SetValue(DragDropGroupNameProperty, value);
        }

        static public readonly DependencyProperty IsDraggableProperty = DependencyProperty.RegisterAttached("IsDraggable", typeof(bool), typeof(DragDropContainer), new UIPropertyMetadata(false));
        static public bool GetIsDraggable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDraggableProperty);
        }
        static public void SetIsDraggable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDraggableProperty, value);
        }

        static public readonly DependencyProperty IsDropTargetProperty = DependencyProperty.RegisterAttached("IsDropTarget", typeof(bool), typeof(DragDropContainer), new UIPropertyMetadata(true));
        static public bool GetIsDropTarget(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDropTargetProperty);
        }
        static public void SetIsDropTarget(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDropTargetProperty, value);
        }

        static public readonly DependencyProperty SourceDropCommandProperty = DependencyProperty.RegisterAttached("SourceDropCommand", typeof(DropCommand), typeof(DragDropContainer), new UIPropertyMetadata(null));
        static public DropCommand GetSourceDropCommand(DependencyObject obj)
        {
            return (DropCommand)obj.GetValue(SourceDropCommandProperty);
        }
        static public void SetSourceDropCommand(DependencyObject obj, DropCommand value)
        {
            obj.SetValue(SourceDropCommandProperty, value);
        }

        static public readonly DependencyProperty TargetDropCommandProperty = DependencyProperty.RegisterAttached("TargetDropCommand", typeof(DropCommand), typeof(DragDropContainer), new UIPropertyMetadata(null));
        static public DropCommand GetTargetDropCommand(DependencyObject obj)
        {
            return (DropCommand)obj.GetValue(TargetDropCommandProperty);
        }
        static public void SetTargetDropCommand(DependencyObject obj, DropCommand value)
        {
            obj.SetValue(TargetDropCommandProperty, value);
        }

        static public readonly DependencyProperty SourceDropCommandParameterProperty = DependencyProperty.RegisterAttached("SourceDropCommandParameter", typeof(object), typeof(DragDropContainer), new UIPropertyMetadata(null));
        static public object GetSourceDropCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(SourceDropCommandParameterProperty);
        }
        static public void SetSourceDropCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(SourceDropCommandParameterProperty, value);
        }

        static public readonly DependencyProperty TargetDropCommandParameterProperty = DependencyProperty.RegisterAttached("TargetDropCommandParameter", typeof(object), typeof(DragDropContainer), new UIPropertyMetadata(null));
        static public object GetTargetDropCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(TargetDropCommandParameterProperty);
        }
        static public void SetTargetDropCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(TargetDropCommandParameterProperty, value);
        }

        static private readonly DependencyPropertyKey IsDraggedKey = DependencyProperty.RegisterAttachedReadOnly("IsDragged", typeof(bool), typeof(DragDropContainer), new PropertyMetadata(false));
        static public readonly DependencyProperty IsDraggedProperty = IsDraggedKey.DependencyProperty;
        static public bool GetIsDragged(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDraggedProperty);
        }
        static internal void SetIsDragged(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDraggedKey, value);
        }

        static private readonly DependencyPropertyKey IsDragActiveKey = DependencyProperty.RegisterAttachedReadOnly("IsDragActive", typeof(bool), typeof(DragDropContainer), new PropertyMetadata(false));
        static public readonly DependencyProperty IsDragActiveProperty = IsDragActiveKey.DependencyProperty;
        static public bool GetIsDragActive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragActiveProperty);
        }
        static internal void SetIsDragActive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragActiveKey, value);
        }

        static private readonly DependencyPropertyKey IsActiveDropTargetKey = DependencyProperty.RegisterAttachedReadOnly("IsActiveDropTarget", typeof(bool), typeof(DragDropContainer), new PropertyMetadata(false));
        static public readonly DependencyProperty IsActiveDropTargetProperty = IsActiveDropTargetKey.DependencyProperty;
        static public bool GetIsActiveDropTarget(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsActiveDropTargetProperty);
        }
        static internal void SetIsActiveDropTarget(DependencyObject obj, bool value)
        {
            obj.SetValue(IsActiveDropTargetKey, value);
        }

        static internal readonly DependencyProperty ParentDragDropContainerProperty = DependencyProperty.RegisterAttached("ParentDragDropContainer", typeof(DragDropContainer), typeof(DragDropContainer), new UIPropertyMetadata(null));
        static internal DragDropContainer GetParentDragDropContainer(DependencyObject obj)
        {
            return (DragDropContainer)obj.GetValue(ParentDragDropContainerProperty);
        }
        static internal void SetParentDragDropContainer(DependencyObject obj, DragDropContainer value)
        {
            obj.SetValue(ParentDragDropContainerProperty, value);
        }

        static public readonly DependencyProperty MinDragAngleProperty = DependencyProperty.RegisterAttached("MinDragAngle", typeof(double), typeof(DragDropContainer), new UIPropertyMetadata(0.0));
        static public double GetMinDragAngle(DependencyObject obj)
        {
            return (double)obj.GetValue(MinDragAngleProperty);
        }
        static public void SetMinDragAngle(DependencyObject obj, double value)
        {
            obj.SetValue(MinDragAngleProperty, value);
        }

        static public readonly DependencyProperty MaxDragAngleProperty = DependencyProperty.RegisterAttached("MaxDragAngle", typeof(double), typeof(DragDropContainer), new UIPropertyMetadata(360.0));
        static public double GetMaxDragAngle(DependencyObject obj)
        {
            return (double)obj.GetValue(MaxDragAngleProperty);
        }
        static public void SetMaxDragAngle(DependencyObject obj, double value)
        {
            obj.SetValue(MaxDragAngleProperty, value);
        }
        #endregion attached properties

        #region Static Methods
        /// <summary>
        /// Handles the "Changed" event of the "DragDropGroupName" attached
        /// property
        /// </summary>
        /// <param name="sender">
        /// Sender of the event
        /// </param>
        /// <param name="args">
        /// Event argument
        /// </param>
        static private void OnDragDropGroupNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElement groupElement = sender as FrameworkElement;
            if (groupElement != null)
            {
                if (groupElement.IsLoaded)
                {
                    DragDropContainer dragDropContainer = FindParent<DragDropContainer>(groupElement);
                    if (dragDropContainer != null)
                    {
                        SetParentDragDropContainer(groupElement, dragDropContainer);
                        dragDropContainer.OnDragDropGroupNameChanged(groupElement, args.OldValue as string, args.NewValue as string);
                    }
                    groupElement.Unloaded -= new RoutedEventHandler(groupElement_Unloaded);
                    groupElement.Loaded -= new RoutedEventHandler(groupElement_Loaded);
                    groupElement.Unloaded += new RoutedEventHandler(groupElement_Unloaded);
                }
                else
                {
                    groupElement.Unloaded -= new RoutedEventHandler(groupElement_Unloaded);
                    groupElement.Loaded -= new RoutedEventHandler(groupElement_Loaded);
                    groupElement.Loaded += new RoutedEventHandler(groupElement_Loaded);
                }
            }
        }

        /// <summary>
        /// Handles the "Loaded" event of a group element
        /// </summary>
        /// <param name="sender">
        /// Sender of the event
        /// </param>
        /// <param name="args">
        /// Event argument
        /// </param>
        public static void groupElement_Loaded(object sender, RoutedEventArgs args)
        {
            FrameworkElement groupElement = sender as FrameworkElement;
            if (groupElement != null)
            {
                DragDropContainer dragDropContainer = FindParent<DragDropContainer>(groupElement);
                if (dragDropContainer != null && args != null)
                {
                    SetParentDragDropContainer(groupElement, dragDropContainer);
                    dragDropContainer.OnDragDropGroupNameChanged(groupElement, null, GetDragDropGroupName(groupElement));
                }
                groupElement.Unloaded -= new RoutedEventHandler(groupElement_Unloaded);
                groupElement.Loaded -= new RoutedEventHandler(groupElement_Loaded);
                groupElement.Unloaded += new RoutedEventHandler(groupElement_Unloaded);
            }
        }

        /// <summary>
        /// Handles the "Unloaded" event of a group element
        /// </summary>
        /// <param name="sender">
        /// Sender of the event
        /// </param>
        /// <param name="args">
        /// Event argument
        /// </param>
        static private void groupElement_Unloaded(object sender, RoutedEventArgs args)
        {
            FrameworkElement groupElement = sender as FrameworkElement;
            if (groupElement != null)
            {
                DragDropContainer dragDropContainer = FindParent<DragDropContainer>(groupElement);
                if (dragDropContainer != null && args != null)
                {
                    dragDropContainer.OnDragDropGroupNameChanged(groupElement, GetDragDropGroupName(groupElement), null);
                }
                groupElement.Unloaded -= new RoutedEventHandler(groupElement_Unloaded);
                groupElement.Loaded -= new RoutedEventHandler(groupElement_Loaded);
                groupElement.Loaded += new RoutedEventHandler(groupElement_Loaded);
            }
        }

        /// <summary>
        /// Handles the "Changed" event of the "DragDropGroupName" attached
        /// property of the given node element
        /// </summary>
        /// <param name="groupElement">
        /// Group element
        /// </param>
        /// <param name="oldDragDropGroupName">
        /// Old drag drop group name
        /// </param>
        /// <param name="newDragDropGroupName">
        /// New drag drop group name
        /// </param>
        private void OnDragDropGroupNameChanged(FrameworkElement groupElement, string oldDragDropGroupName, string newDragDropGroupName)
        {
            if (groupElement != null)
            {
                if (!string.IsNullOrEmpty(oldDragDropGroupName))
                {
                    IDragDropGroup dragDropGroup = FindDragDropGroup(oldDragDropGroupName);
                    if (dragDropGroup != null)
                    {
                        dragDropGroup.RemoveGroupElement(groupElement);
                        if (!dragDropGroup.HasGroupElements)
                        {
                            InternalChildren.Remove(dragDropGroup as UIElement);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(newDragDropGroupName))
                {
                    IDragDropGroup dragDropGroup = FindDragDropGroup(newDragDropGroupName);
                    if (dragDropGroup != null)
                    {
                        dragDropGroup.AddGroupElement(groupElement);
                    }
                    else
                    {
                        dragDropGroup = new DragDropGroup(this);
                        dragDropGroup.DragDropGroupName = newDragDropGroupName;
                        dragDropGroup.AddGroupElement(groupElement);
                        InternalChildren.Add(dragDropGroup as UIElement);
                    }
                }
            }
        }

        /// <summary>
        /// Finds the drag drop group with the given name
        /// </summary>
        /// <param name="dragDropGroupName">
        /// Drag drop group name
        /// </param>
        /// <returns>
        /// Drag drop group with the given name or null
        /// </returns>
        private IDragDropGroup FindDragDropGroup(string dragDropGroupName)
        {
            foreach (UIElement uiElement in InternalChildren)
            {
                IDragDropGroup dragDropGroup = uiElement as IDragDropGroup;
                if (dragDropGroup != null && dragDropGroup.DragDropGroupName == dragDropGroupName)
                {
                    return dragDropGroup;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds the parent element of the given type for the given child
        /// element
        /// </summary>
        /// <typeparam name="T">
        /// Type of the parent to find
        /// </typeparam>
        /// <param name="childElement">
        /// Child element
        /// </param>
        /// <returns>
        /// Parent element or null
        /// </returns>
        static private T FindParent<T>(DependencyObject childElement) where T : DependencyObject
        {
            DependencyObject visualParent = VisualTreeHelper.GetParent(childElement);
            if (visualParent == null)
            {
                return null;
            }
            T parent = visualParent as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(visualParent);
            }
        }
        
        #endregion
    }
}