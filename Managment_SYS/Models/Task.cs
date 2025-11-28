namespace Managment_SYS.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public StatusType Status { get; set; }
        public PriorityType Priority { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; } = null!;

    }
    public enum StatusType
    {
        Pending,
        InProgress,
        Completed
    }
    public enum PriorityType
    {
        Low,
        Medium,
        High
    }
}