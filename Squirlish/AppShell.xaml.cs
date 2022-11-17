using Squirlish.Views;

namespace Squirlish;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        this.HomeTab.Icon = ImageSource.FromResource("Squirlish.Resources.Images.home.png", this.GetType().Assembly);
        this.CollectionsTab.Icon = ImageSource.FromResource("Squirlish.Resources.Images.categories.png", this.GetType().Assembly);
        this.LearnTab.Icon = ImageSource.FromResource("Squirlish.Resources.Images.bookmarks.png", this.GetType().Assembly);
    }
}
