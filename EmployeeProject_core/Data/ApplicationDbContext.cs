using EmployeeProject_core.Models;
using EmployeeProject_core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject_core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeToProject> EmployeeToProject { get; set; }
        public DbSet<Project> Projects{ get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<EmployeeToProjectViewModel>();
        }

 
        public async Task<List<EmployeeToProjectViewModel>> GetData(string query, List<object> parameters)
        {
            List<EmployeeToProjectViewModel> getRanks = await this.Query<EmployeeToProjectViewModel>().FromSqlRaw(query,parameters.ToArray()).ToListAsync();

            return getRanks;
        }
    }
}
