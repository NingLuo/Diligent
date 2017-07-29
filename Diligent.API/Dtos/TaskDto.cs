using System;
using System.Collections.Generic;

namespace Diligent.API.Dtos
{
    public class TaskDto
    {
        public TaskDto()
        {
            ReviewMissions = new HashSet<ReviewMissionDto>();
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public byte StatusId { get; set; }

        public UserDto User { get; set; }
        public CategoryDto Category { get; set; }
        public StatusDto Status { get; set; }
        public ICollection<ReviewMissionDto> ReviewMissions { get; set; }
    }
}