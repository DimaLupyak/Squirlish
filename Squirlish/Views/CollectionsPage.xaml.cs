using Squirlish.ViewModels;

namespace Squirlish.Views
{
    public partial class CollectionsPage : ContentPage
    {
        public CollectionsPage()
        {
            InitializeComponent();

            this.BindingContext = new CollectionsViewModel();
        }
    }
}
