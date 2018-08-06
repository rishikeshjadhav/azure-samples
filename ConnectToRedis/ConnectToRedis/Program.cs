
namespace ConnectToRedis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StackExchange.Redis;

    public class Program
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("");
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        private static IDatabase cache { get; set; }

        Program()
        {
            cache = Connection.GetDatabase();
        }

        static void Main(string[] args)
        {
            cache.StringSet("key1", "value1");
            cache.StringSet("key2", 25);
            cache.StringSet("key3", "value1", TimeSpan.FromMinutes(5));

            string key1 = cache.StringGet("key1");
            int key2 = (int)cache.StringGet("key2");
            string key3 = cache.StringGet("key3");
        }
    }
}
