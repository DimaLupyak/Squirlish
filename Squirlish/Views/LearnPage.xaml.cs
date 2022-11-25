using MediatR;
using Squirlish.ViewModels;

namespace Squirlish.Views
{
    public partial class LearnPage : ContentPage
    {
        public LearnPage(IMediator mediator)
        {
            InitializeComponent();

            this.BindingContext = new LearnViewModel(mediator);
        }
    }
}
