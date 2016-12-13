using Kosmos.LogServer.DbContext;
using Kosmos.LogServer.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Kosmos.LogServer
{
    public static class LogCache
    {
        private static object _lock = new object();
        public static ConcurrentBag<Log> Logs { get; set; }

        static LogCache()
        {
            Logs = new ConcurrentBag<Log>();

            var task = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromMinutes(30));
                    try
                    {
                        using (var dbContext = new AppDbContext())
                        {
                            CacheToDb(dbContext);
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            });
        }

        public static void CacheToDb(AppDbContext dbContext)
        {
            lock (_lock)
            {
                try
                {
                    dbContext.Logs.AddRange(Logs);
                    dbContext.SaveChanges();
                    Logs = new ConcurrentBag<Log>();
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}