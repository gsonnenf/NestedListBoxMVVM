using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace gstc.wpf.NestedListBoxMVVM.View {
    public static class ViewHelper {

        public static T GetDataTemplateItem<T>(ListBox listBox, int index, string itemName) where T: DependencyObject {
            if (index < 0) return null;
            var listBoxItem = listBox.ItemContainerGenerator.ContainerFromIndex(index) as ListBoxItem;
            if (listBoxItem == null) return null;
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(listBoxItem);
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            return myDataTemplate.FindName(itemName, myContentPresenter) as T;
       
        }

        public static TChildItem FindVisualChild<TChildItem>(DependencyObject obj) where TChildItem : DependencyObject {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++) {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is TChildItem) return (TChildItem)child;
                else {
                    TChildItem childOfChild = FindVisualChild<TChildItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

      
    }
}
