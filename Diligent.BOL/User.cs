using System.Collections.Generic;

namespace Diligent.BOL
{
    public class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
