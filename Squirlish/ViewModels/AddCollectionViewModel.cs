using MediatR;
using Squirlish.Domain.Collections.Model;
using Squirlish.Domain.Collections.UseCases;
using Squirlish.Views;

namespace Squirlish.ViewModels;

public class AddCollectionViewModel : BaseViewModel
{
    private readonly IMediator _mediator;
    private readonly NavigableElement _parentView;

    public AddCollectionViewModel(IMediator mediator, NavigableElement parentView)
    {
        _mediator = mediator;
        _parentView = parentView;
        AddCollectionCommand = new Command(AddCollection);
    }
    
    private string _collectionName = string.Empty;

    public string CollectionName
    {
        get => _collectionName;
        set => SetField(ref _collectionName, value);
    }

    public Command AddCollectionCommand { get; set; }

    private async void AddCollection()
    {
        var collection = new WordsCollection
        {
            Name = CollectionName,
            IsOpened = true
        };
        await _mediator.Send(new AddCollectionCommand(collection));
        await _parentView.Navigation.PopAsync(false);
        await _parentView.Navigation.PushAsync(new CollectionPage(_mediator, _parentView, collection));

    }
}

