# OracleMvcTemplate
Oracle MVC EF Localization Template

Setup identity column
As modifying existing column to identify column is not supported. So we can use below query to add new column.

ALTER TABLE DIP.TRANSACTION ADD (S_ROLL_NEW NUMBER(3) GENERATED ALWAYS AS IDENTITY);

How to develop the Dot Net Core web application
1. Read and modify from here https://github.com/oracle/dotnet-db-samples/tree/master/samples/dotnet-core/ef-core/get-started. Create console program to generate table(s)
run add-migration first
update-database

2. Create a Mvc web application with
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.VisualStudio.Web.CodeGeneration.Design
Oracle.EntityFrameworkCore

Run this command
Scaffold-DbContext "User Id=dip;Password=Welcome1;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));" Oracle.EntityFrameworkCore -OutputDir Models -force

Modify appsettings.json
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User ID=dip;Password=Welcome1;Persist Security Info=True"
  },

Add file in Data folder

using Microsoft.EntityFrameworkCore;
using OracleWebApp.Models;

namespace OracleWebApp.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options)
          : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}

Modify ConfigureServices in Startup.cs

            services.AddDbContext<OracleDbContext>(options => options.UseOracle(Configuration.GetConnectionString("DefaultConnection")));

Run the queries below for user
Grant user to be able to view
GRANT CREATE VIEW TO "<Oracle User>"
GRANT CREATE MATERIALIZED VIEW TO "<Oracle User>"

Add controller with view


