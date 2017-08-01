using System.Collections.Generic;

namespace Diligent.API.Dtos
{
    public class ProjectDto
    {
        public ProjectDto()
        {
            Tasks = new HashSet<TaskDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TaskDto> Tasks { get; set; }
    }
}