namespace HCM.Data
{
    using HCM.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ApplicationDbContext(DbContextOptions options)
    : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /* To do:
                optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
                throws Value cannot be null. (Parameter 'connectionString')
                 */

                optionsBuilder.UseSqlServer("Server=.;Database=HCM;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyAddress> CompanyAddresses { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<DepartmentAddress> DepartmentAddresses { get; set; }

        public DbSet<EmployeeContract> EmployeeContracts { get; set; }

        public DbSet<EvaluationScore> EvaluationScores { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<IdentityRole> IdentityRoles { get; set; }

        public DbSet<IdentityUser> IdentityUsers { get; set; }

        public DbSet<MaritalStatus> MaritalStatuses { get; set; }

        public DbSet<ParentalStatus> ParentalStatuses { get; set; }

        public DbSet<PaymentInterval> PaymentIntervals { get; set; }

        public DbSet<PerformanceReview> PerformanceReviews { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectStatus> ProjectStatuses { get; set; }

        public DbSet<ProjectStatusCategory> ProjectStatusCategories { get; set; }

        public DbSet<RequestedLeave> RequestedLeaves { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<TrainingUser> TrainingUsers { get; set; }

        public DbSet<UsedLeave> UsedLeaves { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<UserMaritalStatus> UserMaritalStatuses { get; set; }

        public DbSet<UserParentalStatus> UserParentalStatuses { get; set; }

        public DbSet<ProjectUser> ProjectUsers { get; set; }
    }
}
