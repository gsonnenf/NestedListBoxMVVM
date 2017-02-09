# NestedListBoxMVVM
The is a template for a nested listbox that uses WPF data binding to a ViewModel to populate a Parent Listbox and a Child Listbox embedded in the Parent Listbox's Items.

The project consists of a nestable Class "BaseModelView" which contains a ObservableCollection<BaseModelView> that can be nested, and 3 Views that present the displayablecontent of the BaseModelView objects (in this case a display name). The parent listbox view (ProjectView) displays a set of child listboxes based on the Collection in the modelview and a Datatemplate specifying the child view (LayerView). In the same way the childview displays a list of child items using the view model and its child view (OperationView).

The parent view contains instructions for adding and removing both children and grandchildren from the child and grandchild collections. In order to minimize boilerplate code, the project uses Fody to convert Standard properties into dependency properties or implement INotifyPropertyChanged where neccessary.
