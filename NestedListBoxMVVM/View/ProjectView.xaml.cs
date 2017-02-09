using System.Windows;
using System.Windows.Controls;
using AutoDependencyPropertyMarker;
using gstc.wpf.NestedListBoxMVVM.ViewModel;

namespace gstc.wpf.NestedListBoxMVVM.View {
    /// <summary>
    /// Interaction logic for ProjectDisplayControl.xaml
    /// </summary>
    public partial class ProjectView : UserControl {
        public ProjectView() {
            InitializeComponent();
            //DataContext = ViewModel;
        }

        [AutoDependencyProperty]
        public BaseViewModel ViewModel { get; set; }

        public BaseViewModel SelectedLayerViewModel => (DataContext as BaseViewModel)?.Collection[LayerListBox.SelectedIndex];
        public BaseViewModel SelectedOperationViewModel => SelectedLayerView.SelectedOperationViewModel;

        public int SelectedLayerIndex => LayerListBox.SelectedIndex;
        public int SelectedOperationIndex => SelectedLayerView.SelectedOperationIndex;

        public LayerView SelectedLayerView => ViewHelper.GetDataTemplateItem<LayerView>(LayerListBox, SelectedLayerIndex, "layerView");
        public OperationView SelectedOperationView => SelectedLayerView.SelectedOperationView;

        private void RemoveContextItem_OnClickoveContextItem_OnClick(object sender, RoutedEventArgs e) {
            if (SelectedLayerIndex < 0) return;
            ViewModel.Collection.RemoveAt(SelectedLayerIndex);
        }

        private void NewLayerAboveContextItem_OnClick(object sender, RoutedEventArgs e) {
            int selectedIndex = (SelectedLayerIndex < 0) ? SelectedLayerIndex : 0;
            ViewModel.Collection.Insert(selectedIndex, new BaseViewModel("Inserted Layer"));
        }
        private void NewLayerBelowContextItem_OnClick(object sender, RoutedEventArgs e) {
            ViewModel.Collection.Insert(SelectedLayerIndex + 1, new BaseViewModel("Inserted Layer"));
        }
    }
}
