using AutoMapper;
using Domain.Entities;
using MediatR;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateTeam
{
    internal class CreateTeamHandler : BaseContext, IRequestHandler<CreateTeamCommand>
    {
        public CreateTeamHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FindAsync(request.TeacherId);
            var name = Name.Create(request.TeamName);
            var team = new Team(name.Value, teacher);

            _dbContext.Teams.Add(team);
            await _dbContext.SaveChanges();
            return Unit.Value;
        }
    }
}
