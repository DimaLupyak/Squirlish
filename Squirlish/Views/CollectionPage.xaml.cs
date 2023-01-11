using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Squirlish.Domain.Collections.Model;
using Squirlish.ViewModels;

namespace Squirlish.Views;

public partial class CollectionPage : ContentPage
{
    private readonly IMediator _mediator;
    private readonly NavigableElement _parentView;
    public WordsCollection Collection { get; }

    public CollectionPage(IMediator mediator, NavigableElement parentView, WordsCollection collection)
    {
        _mediator = mediator;
        _parentView = parentView;
        Collection = collection;
        InitializeComponent();
        try
        {
            this.BindingContext = new CollectionViewModel(mediator, parentView, collection);
        }

        catch (Exception e)
        {
            this.Title = e.ToString();
        }
    }
}