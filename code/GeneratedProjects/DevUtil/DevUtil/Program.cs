using System.Text.Json;
using PortLib.Ports;

namespace DevUtil
{
    internal class Program
    {
        private sealed class Options
        {
            public bool IncludeListeners { get; init; } = true;
            public bool IncludeConnections { get; init; } = false;
            public string Protocol { get; init; } = "all"; // all|tcp|udp
            public bool Json { get; init; } = false;
            public bool Help { get; init; } = false;
        }

        static void Main(string[] args)
        {
            var opts = Parse(args);
            if (opts.Help)
            {
                PrintHelp();
                return;
            }

            var filter = opts.Protocol.ToLowerInvariant() switch
            {
                "tcp" => ProtocolFilter.Tcp,
                "udp" => ProtocolFilter.Udp,
                _ => ProtocolFilter.All
            };

            var snapshot = PortScanner.GetSnapshot(
                includeListeners: opts.IncludeListeners,
                includeConnections: opts.IncludeConnections,
                filter: filter);

            if (opts.Json)
            {
                Console.WriteLine(JsonSerializer.Serialize(snapshot, new JsonSerializerOptions { WriteIndented = true }));
                return;
            }

            if (snapshot.Listeners.Count == 0 && (!opts.IncludeConnections || snapshot.Connections.Count == 0))
            {
                Console.WriteLine("No matching ports found.");
                return;
            }

            if (snapshot.Listeners.Count > 0)
            {
                Console.WriteLine("Listening Ports:");
                Console.WriteLine("Protocol  Address                          Port");
                Console.WriteLine("--------  -------------------------------  ----");
                foreach (var r in snapshot.Listeners
                    .OrderBy(r => r.Protocol)
                    .ThenBy(r => r.Port)
                    .ThenBy(r => r.Address))
                {
                    Console.WriteLine($"{r.Protocol,-8} {r.Address,-31} {r.Port,4}");
                }
                Console.WriteLine();
            }

            if (opts.IncludeConnections && snapshot.Connections.Count > 0)
            {
                Console.WriteLine("Active TCP Connections:");
                Console.WriteLine("Local                            Remote                           State");
                Console.WriteLine("-------------------------------- -------------------------------- -----------");
                foreach (var c in snapshot.Connections
                    .OrderBy(c => c.State)
                    .ThenBy(c => c.LocalPort)
                    .ThenBy(c => c.RemotePort))
                {
                    var local = $"{c.LocalAddress}:{c.LocalPort}";
                    var remote = $"{c.RemoteAddress}:{c.RemotePort}";
                    Console.WriteLine($"{local,-32} {remote,-32} {c.State,-11}");
                }
            }
        }

        private static Options Parse(string[] args)
        {
            bool listeners = true;
            bool connections = false;
            bool json = false;
            string protocol = "all";
            bool help = false;

            for (int i = 0; i < args.Length; i++)
            {
                var a = args[i].ToLowerInvariant();
                switch (a)
                {
                    case "--listeners":
                        listeners = true; connections = false;
                        break;
                    case "--connections":
                        connections = true; listeners = false;
                        break;
                    case "--both":
                        listeners = true; connections = true;
                        break;
                    case "--json":
                        json = true;
                        break;
                    case "--protocol":
                    case "-p":
                        if (i + 1 < args.Length)
                        {
                            var next = args[++i].ToLowerInvariant();
                            if (next is "tcp" or "udp" or "all") protocol = next;
                        }
                        break;
                    case "--help":
                    case "-h":
                    case "-?":
                        help = true;
                        break;
                }
            }

            return new Options
            {
                IncludeListeners = listeners,
                IncludeConnections = connections,
                Protocol = protocol,
                Json = json,
                Help = help
            };
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  devutil [--listeners|--connections|--both] [--protocol tcp|udp|all] [--json]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  --listeners      Show listening ports (default).");
            Console.WriteLine("  --connections    Show active TCP connections.");
            Console.WriteLine("  --both           Show both listeners and connections.");
            Console.WriteLine("  -p, --protocol   Filter by protocol (tcp, udp, all). Default: all.");
            Console.WriteLine("  --json           Output JSON.");
            Console.WriteLine("  -h, --help       Show help.");
        }
    }
}
