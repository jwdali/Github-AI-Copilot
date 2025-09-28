using System.Net.NetworkInformation;

namespace PortLib.Ports;

public enum ProtocolFilter
{
    All,
    Tcp,
    Udp
}

public sealed record ListenerInfo(string Protocol, string Address, int Port);

public sealed record ConnectionInfo(string LocalAddress, int LocalPort, string RemoteAddress, int RemotePort, TcpState State);

public sealed class PortSnapshot
{
    public DateTimeOffset GeneratedAt { get; init; } = DateTimeOffset.Now;
    public IReadOnlyList<ListenerInfo> Listeners { get; init; } = Array.Empty<ListenerInfo>();
    public IReadOnlyList<ConnectionInfo> Connections { get; init; } = Array.Empty<ConnectionInfo>();
}
