using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList3.Models;
using ToDoList3.Models.ViewModels;

namespace ToDoList3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ToDoListItem> ToDoListItems { get; set; }

        public DbSet<ToDoStatus> ToDoStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Create shopping items 
            modelBuilder.Entity<ToDoStatus>().HasData(
                new ToDoStatus()
                {
                    Id = 2,
                    Title = "To Do"
                },
                new ToDoStatus()
                {
                    Id = 3,
                    Title = "In Progress"
                },
                 new ToDoStatus()
                 {
                     Id = 4,
                     Title = "Done"
                 }

                 );
        }

        public DbSet<ToDoList3.Models.ViewModels.ToDoListItemFormViewModel> ToDoListItemAddViewModel { get; set; }
    }
}