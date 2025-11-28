namespace Managment_SYS.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Models.Task> Tasks { get; set; } = new HashSet<Models.Task>();
    }
}
