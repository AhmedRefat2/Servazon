using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servazon.Infrastructure.Data
{
    //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ServazonDbContext>
    //{
    //    public ServazonDbContext CreateDbContext(string[] args)
    //    {
    //        Debugger.Launch(); 

    //        var config = new ConfigurationBuilder()
    //        .SetBasePath(Directory.GetCurrentDirectory())
    //        .AddJsonFile("appsettings.json", optional: false)
    //        .Build();

    //        var optionsBuilder = new DbContextOptionsBuilder<ServazonDbContext>();
    //        optionsBuilder.UseSqlServer(config.GetConnectionString("ServazonLocalConnectionString"));

    //        return new ServazonDbContext(optionsBuilder.Options);
    //    }
    //}
}
