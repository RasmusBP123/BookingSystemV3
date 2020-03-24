using AutoMapper;
using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Application.Commands
{
    public class BaseContext
    {
        protected readonly ICalendarContext _dbContext;
        protected readonly IMapper _mapper;

        protected BaseContext(ICalendarContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
