using MediatR;
using Squirlish.Domain.Collections.Model;
using Squirlish.Domain.Collections.UseCases;
using Squirlish.Domain.Inventory.Model;
using Squirlish.Domain.Inventory.UseCases;
using Squirlish.Views;

namespace Squirlish.ViewModels
{
    public class CollectionsViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;
        private readonly NavigableElement _parentView;


        public CollectionsViewModel(IMediator mediator, NavigableElement parentView)
        {
            _mediator = mediator;
            _parentView = parentView;
            UnlockCollectionCommand = new Command<WordsCollection>(UnlockCollection);
            RefreshCommand = new Command(Refresh);
            AddCollectionCommand = new Command(AddCollection);
            OpenCollectionCommand = new Command<WordsCollection>(OpenCollection);
            Refresh();
        }


        private int _acornsAmount;
        public int AcornsAmount
        {
            get => _acornsAmount;
            set => SetField(ref _acornsAmount, value);
        }

        public ICollection<WordsCollection> WordsCollections { get; set; }
        public ICollection<WordsCollection> OpenedCollections => WordsCollections.Where(c => c.IsOpened).ToArray();
        public ICollection<WordsCollection> ClosedCollections => WordsCollections.Where(c => !c.IsOpened).ToArray();

        public Command UnlockCollectionCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command AddCollectionCommand { get; set; }

        public Command OpenCollectionCommand { get; set; }

        private void Refresh()
        {
            WordsCollections = _mediator.Send(new GetCollectionsRequest()).Result;
            AcornsAmount = _mediator.Send(new GetInventoryItemAmountRequest(InventoryItemType.Acorn)).Result;
            OnPropertyChanged(nameof(OpenedCollections));
            OnPropertyChanged(nameof(ClosedCollections));
        }


        private async void UnlockCollection(WordsCollection collectionToUnlock)
        {
            await _mediator.Send(new UnlockCollectionCommand(collectionToUnlock));
            Refresh();
        }


        private async void AddCollection()
        {
            await _parentView.Navigation.PushAsync(new AddCollectionPage(_mediator, _parentView));
        }

        private async void OpenCollection(WordsCollection collection)
        {
            await _parentView.Navigation.PushAsync(new CollectionPage(_mediator, _parentView, collection));
        }
    }
}
