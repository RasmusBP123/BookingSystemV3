using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.AttachStudentToTeam
{
    public class AttachStudentToTeamCommand : IRequest
    {
        public Guid TeamId { get; set; }
        public List<Student> Students { get; set; }
        public AttachStudentToTeamCommand(Guid teamId, List<Student> students)
        {
            TeamId = teamId;
            Students = students;
        }
    }
}
