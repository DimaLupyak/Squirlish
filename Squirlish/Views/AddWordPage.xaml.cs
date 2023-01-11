using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Squirlish.Domain.Collections.Model;
using Squirlish.ViewModels;

namespace Squirlish.Views;

public partial class AddWordPage : ContentPage
{
    private readonly WordsCollection _collection;

    public AddWordPage(IMediator mediator, NavigableElement _parentView, WordsCollection collection)
    {
        _collection = collection;
        InitializeComponent();
        try
        {
            this.BindingContext = new AddWordViewModel(mediator, _parentView, _collection);
        }

        catch (Exception e)
        {
            this.Title = e.ToString();
        }
    }
}