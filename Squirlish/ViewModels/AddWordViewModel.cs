using MediatR;
using Squirlish.Domain.Collections.Model;
using Squirlish.Domain.Collections.UseCases;

namespace Squirlish.ViewModels;

public class AddWordViewModel : BaseViewModel
{
    private readonly IMediator _mediator;
    private readonly NavigableElement _parentView;
    private readonly WordsCollection _wordsCollection;

    public AddWordViewModel(IMediator mediator, NavigableElement _parentView, WordsCollection wordsCollection)
    {
        _mediator = mediator;
        this._parentView = _parentView;
        _wordsCollection = wordsCollection;
        AddWordCommand = new Command(AddWord);
    }

    private string _wordEnglish = string.Empty;

    public string WordEnglish
    {
        get => _wordEnglish;
        set => SetField(ref _wordEnglish, value);
    }

    private string _wordUkrainian = string.Empty;

    public string WordUkrainian
    {
        get => _wordUkrainian;
        set => SetField(ref _wordUkrainian, value);
    }

    public Command AddWordCommand { get; set; }

    private void AddWord()
    {
        _mediator.Send(new AddWordCommand(
            new Word
            {
                WordsCollection = _wordsCollection,
                Translations = new List<WordTranslation>
                {
                    new()
                    {
                        Language = Language.English,
                        Meaning = WordEnglish
                    },
                    new()
                    {
                        Language = Language.Ukrainian,
                        Meaning = WordUkrainian
                    }
                }
            }));
        _parentView.Navigation.PopAsync(true);
    }
}