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
        public CreateTeamHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {

            var teacher = _dbContext.Teachers.FirstOrDefault(t => t.Id == request.TeacherId);

            var team = new Team();

            _dbContext.Teams.Add(team);
            await _dbContext.SaveChanges();
            return Unit.Value;
        }
    }
}
