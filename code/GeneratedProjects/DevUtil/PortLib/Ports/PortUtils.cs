using System.Net;
using System.Net.Sockets;

namespace PortLib.Ports;

public static class PortUtils
{
    /// <summary>
    /// Checks if a TCP port is free on the specified IP address.
    /// </summary>
    public static bool IsPortFree(int port, IPAddress address)
        => IsTcpPortFree(port, address);

    public static bool IsTcpPortFree(int port, IPAddress address)
    {
        try
        {
            using var l = new TcpListener(address, port);
            l.Start();
            return true;
        }
        catch (SocketException)
        {
            return false;
        }
    }

    public static int GetFreeTcpPort()
    {
        var l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        var port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }
}
