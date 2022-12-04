using MediatR;
using Squirlish.Domain.Statistic.Model;

namespace Squirlish.Domain.Statistic.UseCases;

public class GetStatisticRequest : IRequest<ICollection<StatisticItem>>
{
}