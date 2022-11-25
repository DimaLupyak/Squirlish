using MediatR;
using System;
using System.Globalization;
using Squirlish.Domain.Collections.Model;
using Squirlish.Domain.Learn;

namespace Squirlish.ViewModels
{
    public class LearnViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;

        public LearnViewModel(IMediator mediator)
        {
            _mediator = mediator;

            CheckTranslationCommand = new Command(CheckTranslation);
            GetHintCommand = new Command(ApplyHint);
            GoToCollectionCommand = new Command(GoToCollection);
            RefreshCommand = new Command(Refresh);

            Refresh();
        }

        private WordToLearnViewModel _wordToLearn;
        public WordToLearnViewModel WordToLearn
        {
            get => _wordToLearn;
            set => SetField(ref _wordToLearn, value);
        }

        private string _translation = string.Empty;

        public string Translation
        {
            get => _translation;
            set => SetField(ref _translation, value);
        }

        public Command CheckTranslationCommand { get; set; }
        public Command GetHintCommand { get; set; }
        public Command GoToCollectionCommand { get; set; }
        public Command RefreshCommand { get; set; }

        private void Refresh()
        {
            WordToLearn = new WordToLearnViewModel(_mediator.Send(new GetWordToLearnRequest()).Result);
            Translation = string.Empty;
        }


        private void CheckTranslation()
        {
            if (WordToLearn.Translations.Any(x => x.Equals(Translation, StringComparison.InvariantCultureIgnoreCase)))
            {
                _mediator.Send(new MarkWordAsLearnedCommand(WordToLearn.Word, WordToLearn.FromLanguage, WordToLearn.ToLanguage));
                WordToLearn = new WordToLearnViewModel(_mediator.Send(new GetWordToLearnRequest()).Result);
                Translation = string.Empty;
            }
        }

        private void GoToCollection()
        {
            Shell.Current.GoToAsync("//collections");
        }
        private void ApplyHint()
        {
            Translation = GetHint(Translation, WordToLearn.Translations);
        }

        private string GetHint(string input, ICollection<string> translations)
        {
            var (word, commonPart) = translations
                .Select(translation => (translation, commonPart: GetCommonStringStart(input, translation)))
                .MaxBy(tupleItem => tupleItem.commonPart.Length);

            if (word.Length == commonPart.Length)
            {
                return word;
            }

            return word[..(commonPart.Length + 1)];
        }

        private string GetCommonStringStart(string a, string b)
        {
            for (var i = 0; i < a.Length && i < b.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return a[..i];
                }
            }
            return a.Length < b.Length? a : b;
        }
    }
}
