using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using gstc.wpf.NestedListBoxMVVM.View;
using gstc.wpf.NestedListBoxMVVM.ViewModel;

namespace gstc.wpf.NestedListBoxMVVM {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public BaseViewModel ProjectViewModel { get; set; }
        public MainWindow() {
            InitializeComponent();
            ProjectViewModel = new BaseViewModel("Project 1");
            ProjectViewModel.Collection.Add(new BaseViewModel("Layer 1") );
            ProjectViewModel.Collection[0].Collection.Add(new BaseViewModel("Operation 1"));
            ProjectView.ViewModel = ProjectViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            BaseViewModel viewModel = new BaseViewModel("New Layer");
            viewModel.Collection.Add(new BaseViewModel("Operation 1"));
            int layerIndex = (ProjectView.SelectedLayerIndex >= 0) ? ProjectView.SelectedLayerIndex : 0;
            ProjectViewModel.Collection.Insert(layerIndex, viewModel);
            //ListDisplay.ViewModelCollection.Collection.Add(new BaseViewModel("New Element"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            LayerView layerView = ProjectView.SelectedLayerView;
            if (layerView == null) return;
            var operationIndex = (layerView.SelectedOperationIndex >= 0) ? layerView.SelectedOperationIndex : 0;
            layerView.SelectedLayerViewModel.Collection.Insert(operationIndex, new BaseViewModel("New Operation"));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            ProjectViewModel = new BaseViewModel("New Project");
            ProjectViewModel.Collection.Add(new BaseViewModel("New Layer"));
            ProjectViewModel.Collection[0].Collection.Add(new BaseViewModel("New Op"));
            ProjectView.ViewModel = ProjectViewModel;
        }
    }
}
