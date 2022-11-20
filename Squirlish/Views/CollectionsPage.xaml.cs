using MediatR;
using Squirlish.ViewModels;

namespace Squirlish.Views
{
    public partial class CollectionsPage : ContentPage
    {
        public CollectionsPage(IMediator mediator)
        {
            InitializeComponent();

            this.BindingContext = new CollectionsViewModel(mediator);
        }
    }
}
