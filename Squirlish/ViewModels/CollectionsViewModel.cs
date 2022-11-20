using MediatR;
using Squirlish.Domain.Collections;
using Squirlish.Domain.Collections.Model;

namespace Squirlish.ViewModels
{
    public class CollectionsViewModel
	{
		public CollectionsViewModel(IMediator mediator)
        {
            WordsCollections = mediator.Send(new GetCollectionsRequest()).Result;
        }

        public ICollection<WordsCollection> WordsCollections { get; set; }
        public ICollection<WordsCollection> OpenedCollections => WordsCollections.Where(c => c.IsOpened).ToArray();
        public ICollection<WordsCollection> ClosedCollections => WordsCollections.Where(c => !c.IsOpened).ToArray();
    }
}
