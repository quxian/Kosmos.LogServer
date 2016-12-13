using Kosmos.LogServer.Model;
using Kosmos.LogServer.ModelDbMapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmos.LogServer.DbContext
{
    public class AppDbContext : System.Data.Entity.DbContext
    {
        public AppDbContext() : base("LogServerDbConnection") { }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LogMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
