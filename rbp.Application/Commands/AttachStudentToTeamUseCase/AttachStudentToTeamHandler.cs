using AutoMapper;
using Domain.Entities.Joint;
using MediatR;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.AttachStudentToTeam
{
    public class AttachStudentToTeamHandler : BaseContext, IRequestHandler<AttachStudentToTeamCommand>
    {
        public AttachStudentToTeamHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(AttachStudentToTeamCommand request, CancellationToken cancellationToken)
        {
            var team = _dbContext.Teams.FirstOrDefault(t => t.Id == request.TeamId);
            var studentTeams = request.Students.Select(st => new StudentTeam(st.Id, team.Id));

            team.AttachStudents(studentTeams);
            await _dbContext.SaveChanges();
            return Unit.Value;
        }
    }
}
