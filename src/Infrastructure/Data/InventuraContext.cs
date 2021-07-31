using ApplicationCore.Entities;
using ApplicationCore.Entities.DietPlanAggregate;
using ApplicationCore.Entities.MealAggregate;
using ApplicationCore.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class InventuraContext : DbContext
    {
        public InventuraContext(DbContextOptions<InventuraContext> options) : base(options)
        {
        }

        public DbSet<FoodProduct> FoodProducts { get; set; }
        public DbSet<FoodStock> FoodStocks { get; set; }
        public DbSet<NotificationRule> NotificationRules { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserContactInfo> UserContactInfos { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealItem> MealItems { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<DietPlanPeriod> DietPlanPeriods { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "Data Source=.;Integrated Security=true;Initial Catalog=Inventura.InventuraDb;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}