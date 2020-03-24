using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CreateTeam
{
    public class CreateTeamCommand : IRequest
    {
        public string TeamName { get; set; }
        public string CalendarName { get; set; }
        public Guid TeacherId { get; set; }

        public CreateTeamCommand(string teamName, string calendarName, Guid teacherId)
        {
            TeamName = teamName;
            CalendarName = calendarName;
            TeacherId = teacherId;
        }
    }
}
