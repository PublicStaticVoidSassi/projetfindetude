using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Runtime.InteropServices;

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
        var builder = new DbContextOptionsBuilder<UniFlowCRMDbContext>();
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            builder.UseSqlServer(configuration.GetConnectionString("new"));
        }
        else
        {
            builder.UseSqlServer(configuration.GetConnectionString("Default"));
        }
            

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
