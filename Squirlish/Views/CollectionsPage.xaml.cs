using MediatR;
using Squirlish.ViewModels;

namespace Squirlish.Views
{
    public partial class CollectionsPage : ContentPage
    {
        public CollectionsPage(IMediator mediator)
        {
            InitializeComponent();
            try
            {
                this.BindingContext = new CollectionsViewModel(mediator);
            }

            catch (Exception e)
            {

                this.Title = e.ToString();
                Label.Text = e.ToString();
            }
        }
    }
}
