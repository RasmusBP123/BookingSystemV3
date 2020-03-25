using AutoMapper;
using MediatR;
using rbp.Domain.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace rbp.Application.Commands.DeleteTimeslotUseCase
{
    public class DeleteTimeslotHandler : BaseContext, IRequestHandler<DeleteTimeslotCommand>
    {
        public DeleteTimeslotHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteTimeslotCommand request, CancellationToken cancellationToken)
        {
            var timeslot = await _dbContext.Timeslots.FindAsync(request.TimeslotId);
            _dbContext.Timeslots.Remove(timeslot);
            await _dbContext.SaveChanges();

            return Unit.Value;
        }
    }
}
