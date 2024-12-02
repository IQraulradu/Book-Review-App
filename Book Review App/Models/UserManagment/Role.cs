using System.Collections;

namespace Book_Review_App.Models.UserManagment
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
