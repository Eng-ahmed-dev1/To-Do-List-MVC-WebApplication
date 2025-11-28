using Managment_SYS.Models;
using Microsoft.EntityFrameworkCore;
using Managment_SYS.ViewModel;
namespace Managment_SYS.Data
{
    public class TaskManagementSystemDB : DbContext
    {
        public TaskManagementSystemDB(DbContextOptions<TaskManagementSystemDB> options):base(options){}

        public DbSet <Models.Task> Tasks { get; set; }
        public DbSet <TeamMember>  TeamMembers { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ETask = modelBuilder.Entity<Models.Task>();
            var ETeamMem = modelBuilder.Entity<TeamMember>();
            var EProject = modelBuilder.Entity<Project>();

            ETask.HasKey(x => x.Id);
            ETask
                .Property(x => x.Title)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
            ETask.Property(x => x.Description)
                .HasColumnType("nvarchar(500)")
                .IsRequired();
            ETask
                .Property(x => x.Deadline)
                .HasDefaultValueSql("GetDate()")
                .IsRequired();
            ETask
                .Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>();
            ETask
                .Property(x => x.Priority)
                .IsRequired()
                .HasConversion<string>();
           

            EProject.HasKey(x => x.Id);
            EProject
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
            EProject
               .Property(x => x.Description)
               .HasColumnType("nvarchar(500)")
               .IsRequired();
            EProject
             .Property(x => x.StartDate)
             .IsRequired()
             .HasDefaultValueSql("GetDate()");

            EProject
             .Property(x => x.EndDate)
             .IsRequired()
             .HasDefaultValueSql("GetDate()");
            //Relation between the project and the tasks
            EProject
                .HasMany(x=>x.Tasks)
                .WithOne(x=>x.Project)
                .HasForeignKey(x=>x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);


            ETeamMem
                .HasKey(x => x.Id);
            ETeamMem
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
            ETeamMem
                .Property(x=>x.Email)
                .HasColumnType("nvarchar(100)")
                .IsRequired ();
            ETeamMem
                .HasIndex(x=>x.Email)
                .IsUnique();
            ETeamMem
                .Property(x => x.Role)
                .HasConversion<string>()
                .IsRequired();
            //Relations between the task and the team member
            ETeamMem
                .HasMany(x=>x.Tasks)
                .WithOne(x=>x.TeamMember)
                .HasForeignKey(x=>x.TeamMemberId)
                .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Managment_SYS.ViewModel.TaskDeleteVM> TaskDeleteVM { get; set; } = default!;
        public DbSet<Managment_SYS.ViewModel.TeamMemberDeleteVM> TeamMemberDeleteVM { get; set; } = default!;
    }
}
