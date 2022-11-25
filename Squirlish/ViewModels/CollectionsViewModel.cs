using MediatR;
using Squirlish.Domain.Collections;
using Squirlish.Domain.Collections.Model;
using Squirlish.Domain.Collections.UseCases;

namespace Squirlish.ViewModels
{
    public class CollectionsViewModel : BaseViewModel
	{
        private readonly IMediator _mediator;

        public CollectionsViewModel(IMediator mediator)
        {
            _mediator = mediator;
            UnlockCollectionCommand = new Command<WordsCollection>(UnlockCollection);
            RefreshCommand = new Command(Refresh);
            Refresh();
        }


        public ICollection<WordsCollection> WordsCollections { get; set; }
        public ICollection<WordsCollection> OpenedCollections => WordsCollections.Where(c => c.IsOpened).ToArray();
        public ICollection<WordsCollection> ClosedCollections => WordsCollections.Where(c => !c.IsOpened).ToArray();

        public Command UnlockCollectionCommand { get; set; }
        public Command RefreshCommand { get; set; }

        private void Refresh()
        {
            WordsCollections = _mediator.Send(new GetCollectionsRequest()).Result;
            OnPropertyChanged(nameof(OpenedCollections));
            OnPropertyChanged(nameof(ClosedCollections));
        }


        private async void UnlockCollection(WordsCollection collectionToUnlock)
        {
            await _mediator.Send(new UnlockCollectionCommand(collectionToUnlock));
            Refresh();
        }
    }
}
