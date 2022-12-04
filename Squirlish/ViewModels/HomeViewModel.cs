using MediatR;
using System;
using Squirlish.Domain.Statistic.Model;
using Squirlish.Domain.Statistic.UseCases;

namespace Squirlish.ViewModels
{
    public class HomeViewModel : BaseViewModel
	{
        private readonly IMediator _mediator;

        public HomeViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Statistic = _mediator.Send(new GetStatisticRequest()).Result;
        }

        private ICollection<StatisticItem> _statistic = new List<StatisticItem>();

        public ICollection<StatisticItem> Statistic
        {
            get => _statistic;
            set => SetField(ref _statistic, value);
        }
    }
}
