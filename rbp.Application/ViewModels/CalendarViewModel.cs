using rbp.Domain.CalendarContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Application.ViewModels
{
    public class CalendarViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TimeslotViewModel> TimeSlots { get; set; }
    }
}
