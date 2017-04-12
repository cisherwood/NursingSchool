using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _420Project.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Advisor> Advisor { get; set; }
        public virtual DbSet<Campus> Campus { get; set; }
        public virtual DbSet<Compliance> Compliance { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<GroupFilter> GroupFilters { get; set; }

        public virtual DbSet<Petition> Petition { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<ProgramCourse> ProgramCourse { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCompliance> StudentCompliance { get; set; }
        public virtual DbSet<StudentPetition> StudentPetition { get; set; }
        public virtual DbSet<StudentProgram> StudentProgram { get; set; }
        public virtual DbSet<StudentNote> StudentNote { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<ToDo> To_Dos { get; set; }
        public virtual DbSet<UserEvent> UserEvents { get; set; }
        public virtual DbSet<UserNotification> UserNotifications { get; set; }
        public virtual DbSet<UserToDo> UserToDos { get; set; }
        public virtual DbSet<GroupFilterCompliance> GroupFilterCompliance { get; set; }
        public virtual DbSet<GroupFilterProgram> GroupFilterProgram { get; set; }
        public virtual DbSet<StudentPlan> StudentPlans { get; set; }


        public System.Data.Entity.DbSet<_420Project.Models.Notification> Notifications { get; set; }
    }
}