using AutoMapper;
using Domain.Entities;
using MediatR;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateTeam
{
    public class CreateTeamHandler : BaseContext, IRequestHandler<CreateTeamCommand>
    {
        public CreateTeamHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {

            var teacher = await _dbContext.Teachers.FindAsync(request.TeacherId);

            var team = new Team(request.TeamName, teacher);

            _dbContext.Teams.Add(team);
            await _dbContext.SaveChanges();
            return Unit.Value;
        }
    }
}
