using MediatR;
using Squirlish.Domain.Collections.Model;
using Squirlish.Domain.Collections.UseCases;
using Squirlish.Views;

namespace Squirlish.ViewModels;

public class CollectionViewModel : BaseViewModel
{
    private readonly IMediator _mediator;
    private readonly NavigableElement _parentView;
    private readonly WordsCollection _collection;

    public CollectionViewModel(IMediator mediator, NavigableElement parentView, WordsCollection collection)
    {
        _mediator = mediator;
        _parentView = parentView;
        _collection = collection;
        Words = collection.Words;
        AddWordCommand = new Command(AddWord);
        RefreshCommand = new Command(Refresh);
        Refresh();
    }
    
    private ICollection<Word> _words;

    public ICollection<Word> Words
    {
        get => _words;
        set => SetField(ref _words, value);
    }

    public Command AddWordCommand { get; set; }
    public Command RefreshCommand { get; set; }

    private async void AddWord()
    {
        await _parentView.Navigation.PushAsync(new AddWordPage(_mediator, _parentView, _collection));
    }

    private void Refresh()
    {
        Words = new List<Word>(_mediator.Send(new GetCollectionsRequest()).Result
            .First(c => c.WordsCollectionId == _collection.WordsCollectionId).Words);
    }
}