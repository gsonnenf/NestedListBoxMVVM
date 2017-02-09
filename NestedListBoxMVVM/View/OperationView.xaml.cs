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
using gstc.wpf.NestedListBoxMVVM.ViewModel;

namespace gstc.wpf.NestedListBoxMVVM.View {
    /// <summary>
    /// Interaction logic for FilterDisplayControl.xaml
    /// </summary>
    public partial class OperationView : UserControl {
        public OperationView() {
            InitializeComponent();
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            var operationViewModel = (BaseViewModel) DataContext;
            operationViewModel.OpenWindow();
        }
    }
}
