namespace Managment_SYS.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public RoleType Role { get; set; }
        public ICollection<Models.Task> Tasks { get; set; } = new HashSet<Models.Task>();
    }
    public enum RoleType
    {
        Admin,
        User
    }
}
