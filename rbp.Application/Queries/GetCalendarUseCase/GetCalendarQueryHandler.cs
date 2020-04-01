using AutoMapper;
using Dapper;
using Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;
using rbp.Application.Commands;
using rbp.Application.ViewModels;
using rbp.Domain.Abstractions;
using rbp.Infrastructure.Utilities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static rbp.Application.Queries.GetCalendarUseCase.GetCalendarQueryHandler;

namespace rbp.Application.Queries.GetCalendarUseCase
{
    public class GetCalendarQueryHandler : BaseQuery, IRequestHandler<GetCalendarQuery, CalendarSQL>
    {
        public GetCalendarQueryHandler(ConnectionString connectionString, IMapper mapper) : base(connectionString, mapper)
        {
        }

        public async Task<CalendarSQL> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            var sql = $"Select * from Calendars where Id = '{request.CalendarId}'";
            CalendarSQL calendar;

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                calendar = connection.Query<CalendarSQL>(sql).FirstOrDefault();
            }
                return calendar;
        }
        public class CalendarSQL
        {
            public Guid Id { get; set; }
            public int Version { get; set; }
            public string Name { get; set; }
        }
    }
}
