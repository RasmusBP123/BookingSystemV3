using AutoMapper;
using rbp.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Application.Queries
{
    public class BaseQuery
    {
        public readonly ConnectionString _connectionString;
        protected readonly IMapper _mapper;

        public BaseQuery(ConnectionString connectionString, IMapper mapper)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }
    }
}
