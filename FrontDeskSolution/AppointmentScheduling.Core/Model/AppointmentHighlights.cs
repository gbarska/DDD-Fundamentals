using System;

namespace AppointmentScheduling.Core.Model
{
    public class AppointmentHighlights
        {
            public Guid Id { get; set; }
            public String Title { get; set; }
            public Guid ScheduleId {get;set;}
            public DateTime TimeRangeStart { get; set; }
        }
}