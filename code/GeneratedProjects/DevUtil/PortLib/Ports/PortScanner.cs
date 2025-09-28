using System.Net;
using System.Net.NetworkInformation;

namespace PortLib.Ports;

public static class PortScanner
{
    public static IEnumerable<ListenerInfo> GetListeners(ProtocolFilter filter = ProtocolFilter.All)
    {
        var ip = IPGlobalProperties.GetIPGlobalProperties();

        if (filter is ProtocolFilter.All or ProtocolFilter.Tcp)
        {
            foreach (var ep in ip.GetActiveTcpListeners())
                yield return new ListenerInfo("TCP", AddressToString(ep.Address), ep.Port);
        }

        if (filter is ProtocolFilter.All or ProtocolFilter.Udp)
        {
            foreach (var ep in ip.GetActiveUdpListeners())
                yield return new ListenerInfo("UDP", AddressToString(ep.Address), ep.Port);
        }
    }

    public static IEnumerable<ConnectionInfo> GetTcpConnections()
    {
        var ip = IPGlobalProperties.GetIPGlobalProperties();
        foreach (var c in ip.GetActiveTcpConnections())
        {
            yield return new ConnectionInfo(
                AddressToString(c.LocalEndPoint.Address),
                c.LocalEndPoint.Port,
                AddressToString(c.RemoteEndPoint.Address),
                c.RemoteEndPoint.Port,
                c.State);
        }
    }

    public static PortSnapshot GetSnapshot(bool includeListeners = true, bool includeConnections = false, ProtocolFilter filter = ProtocolFilter.All)
    {
        var listeners = includeListeners ? GetListeners(filter).ToArray() : Array.Empty<ListenerInfo>();
        var connections = includeConnections ? GetTcpConnections().ToArray() : Array.Empty<ConnectionInfo>();

        return new PortSnapshot
        {
            GeneratedAt = DateTimeOffset.Now,
            Listeners = listeners,
            Connections = connections
        };
    }

    private static string AddressToString(IPAddress ip)
    {
        if (ip.Equals(IPAddress.IPv6Any)) return "::";
        if (ip.Equals(IPAddress.Any)) return "0.0.0.0";
        if (ip.Equals(IPAddress.IPv6Loopback)) return "::1";
        if (ip.Equals(IPAddress.Loopback)) return "127.0.0.1";
        return ip.ToString();
    }
}
