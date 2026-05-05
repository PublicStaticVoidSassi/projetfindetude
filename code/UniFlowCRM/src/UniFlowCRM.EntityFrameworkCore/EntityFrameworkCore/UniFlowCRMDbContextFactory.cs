using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UniFlowCRM.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class UniFlowCRMDbContextFactory : IDesignTimeDbContextFactory<UniFlowCRMDbContext>
{
    public UniFlowCRMDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        UniFlowCRMEfCoreEntityExtensionMappings.Configure();

        //TODO: UseSqlServer()
        var builder = new DbContextOptionsBuilder<UniFlowCRMDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));
        
        return new UniFlowCRMDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../UniFlowCRM.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}
