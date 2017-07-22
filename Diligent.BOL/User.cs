using System.Collections.Generic;

namespace Diligent.BOL
{
    public class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
