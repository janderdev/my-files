using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infra.Data.Context;

// Classe usada durante operações de design-time (migrations)
public class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
{
    public SqlContext CreateDbContext(string[] args)
    {
        // Obtém a configuração do appsettings.json do projeto de inicialização (Api)
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Api"))
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new SqlContext(optionsBuilder.Options);
    }
}
