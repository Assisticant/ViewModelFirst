using Assisticant;
using ViewModelFirst.Models;
using ViewModelFirst.ViewModels;

namespace ViewModelFirst.Screens
{
    public class MainScreen : ViewModelLocatorBase
    {
        private Document _document;
        private Selection _selection;

        public MainScreen()
        {
            _document = new Document();
            _selection = new Selection();
        }

        public object Main
        {
            get { return ViewModel(() => new MainViewModel(_document, _selection)); }
        }

        public object Item
        {
            get
            {
                return ViewModel(() => _selection.SelectedItem == null
                    ? null
                    : new ItemViewModel(_selection.SelectedItem));
            }
        }

        public object Navigation
        {
            get { return ViewModel(() => new NavigationViewModel(_document, _selection)); }
        }
    }
}
