using Squirlish.ViewModels;

namespace Squirlish.Views
{
    public partial class LearnPage : ContentPage
    {
        public LearnPage()
        {
            InitializeComponent();

            this.BindingContext = new LearnViewModel();
        }
    }
}
