using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using PropertyChanged;

namespace gstc.wpf.NestedListBoxMVVM.ViewModel {

    [ImplementPropertyChanged]
    public class BaseViewModel {  
        public BaseViewModel() { }

        public BaseViewModel(string name) {
            DisplayName = name;
            PropertyChanged += (sender, args) => Console.WriteLine("CHANGED: " + DisplayName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string DisplayName { get; set; }

        private ObservableCollection<BaseViewModel> _collection;
        
        public ObservableCollection<BaseViewModel> Collection {
            get {
                if (_collection != null) return _collection;
                _collection = new ObservableCollection<BaseViewModel>();
                _collection.CollectionChanged += (sender, args) => PropertyChanged?.Invoke(sender, null);
                return _collection;
            }
        }
        public virtual void OpenWindow() { MessageBox.Show(DisplayName); }
    }
}
