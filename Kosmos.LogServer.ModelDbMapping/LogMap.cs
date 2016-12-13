using Kosmos.LogServer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmos.LogServer.ModelDbMapping
{
    public class LogMap:EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Id)
                .HasMaxLength(32);
        }
    }
}
