using SecurityPlayground.Application.Common.Interfaces;

namespace SecurityPlayground.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
