using System.Windows;
using System.Windows.Controls;
using AutoDependencyPropertyMarker;
using gstc.wpf.NestedListBoxMVVM.ViewModel;

namespace gstc.wpf.NestedListBoxMVVM.View {
    /// <summary>
    /// Interaction logic for LayerDisplayControl.xaml
    /// </summary>
    public partial class LayerView : UserControl {
        public LayerView() {
            InitializeComponent();
            OperationListBox.GotFocus += (sender, args) => { ParentListbox.SelectedItem = this.DataContext; };
        }

        [AutoDependencyProperty]
        public ListBox ParentListbox { get; set; }
      
        public int SelectedOperationIndex => OperationListBox.SelectedIndex;
        public BaseViewModel SelectedLayerViewModel => (DataContext as BaseViewModel);
        public BaseViewModel SelectedOperationViewModel => SelectedLayerViewModel?.Collection[SelectedOperationIndex];
        public OperationView SelectedOperationView => ViewHelper.GetDataTemplateItem<OperationView>(OperationListBox, SelectedOperationIndex, "operationView");

        private void RemoveContextItem_OnClick(object sender, RoutedEventArgs e) {
            if (SelectedOperationIndex < 0) return;
            (DataContext as BaseViewModel)?.Collection.RemoveAt(SelectedOperationIndex);
        }
    }
}
