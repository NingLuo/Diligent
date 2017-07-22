using System.Collections.Generic;

namespace Diligent.BOL
{
    public class Category
    {
        public Category()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }         
    }
}
