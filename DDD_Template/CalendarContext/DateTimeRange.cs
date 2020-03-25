using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace rbp.Domain.CalendarContext
{
    public class DateTimeRange : ValueObject
    {
        public DateTime From { get;}
        public DateTime To { get;}

        protected DateTimeRange()
        {

        }

        private DateTimeRange(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public static Result<DateTimeRange> Create(DateTime from, DateTime to)
        {
            if(from > to) return Result.Failure<DateTimeRange>("Startoint must be greater than endpoint");
            if (to < from) return Result.Failure<DateTimeRange>("Endpoint must be greater than Startpoint");

            return Result.Success(new DateTimeRange(from, to));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return From;
            yield return To;
        }
    }
}
