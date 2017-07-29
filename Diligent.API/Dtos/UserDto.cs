using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diligent.API.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            Tasks = new HashSet<TaskDto>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(30)]
        public string Username { get; set; }

        public virtual ICollection<TaskDto> Tasks { get; set; }
    }
}