using Assisticant;
using System.Windows.Input;
using ViewModelFirst.Models;

namespace ViewModelFirst.ViewModels
{
    public class NavigationViewModel
    {
        private readonly Document _document;
		private readonly Selection _selection;

        public NavigationViewModel(Document document, Selection selection)
        {
            _document = document;
			_selection = selection;
        }

        public ICommand AddItem
        {
            get
            {
                return MakeCommand
                    .Do(delegate
                    {
                        _selection.SelectedItem = _document.NewItem();
                    });
            }
        }

        public ICommand DeleteItem
        {
            get
            {
                return MakeCommand
                    .When(() => _selection.SelectedItem != null)
                    .Do(delegate
                    {
                        _document.DeleteItem(_selection.SelectedItem);
                        _selection.SelectedItem = null;
                    });
            }
        }

        public ICommand MoveItemDown
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _selection.SelectedItem != null &&
                        _document.CanMoveDown(_selection.SelectedItem))
                    .Do(delegate
                    {
                        _document.MoveDown(_selection.SelectedItem);
                    });
            }
        }

        public ICommand MoveItemUp
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _selection.SelectedItem != null &&
                        _document.CanMoveUp(_selection.SelectedItem))
                    .Do(delegate
                    {
                        _document.MoveUp(_selection.SelectedItem);
                    });
            }
        }
    }
}
