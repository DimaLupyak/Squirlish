using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Squirlish.ViewModels;

namespace Squirlish.Views;

public partial class AddCollectionPage : ContentPage
{
    public AddCollectionPage(IMediator mediator, NavigableElement parentView)
    {
        InitializeComponent();
        try
        {
            this.BindingContext = new AddCollectionViewModel(mediator, parentView);
        }

        catch (Exception e)
        {
            this.Title = e.ToString();
        }
    }
}