using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectSolution.Data.EF
{
    public class ProjectSolutionDbContextFactory : IDesignTimeDbContextFactory<ProjectSolutionDbContext>
    {
        public ProjectSolutionDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ProjectSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<ProjectSolutionDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ProjectSolutionDbContext(optionsBuilder.Options);
        }
    }
}
