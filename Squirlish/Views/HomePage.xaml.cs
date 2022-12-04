
using MediatR;
using Squirlish.ViewModels;

namespace Squirlish.Views;

public partial class HomePage : ContentPage
{
	public HomePage(IMediator mediator)
	{
		InitializeComponent();
		this.BindingContext = new HomeViewModel(mediator);
	}
}
