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

        public void AddItem()
        {
            _selection.SelectedItem = _document.NewItem();
        }

        public bool CanDeleteItem => _selection.SelectedItem != null;

        public void DeleteItem()
        {
            _document.DeleteItem(_selection.SelectedItem);
            _selection.SelectedItem = null;
        }

        public bool CanMoveItemDown =>
            _selection.SelectedItem != null &&
            _document.CanMoveDown(_selection.SelectedItem);

        public void MoveItemDown()
        {
            _document.MoveDown(_selection.SelectedItem);
        }

        public bool CanMoveItemUp =>
            _selection.SelectedItem != null &&
            _document.CanMoveUp(_selection.SelectedItem);

        public void MoveItemUp()
        {
            _document.MoveUp(_selection.SelectedItem);
        }
    }
}
