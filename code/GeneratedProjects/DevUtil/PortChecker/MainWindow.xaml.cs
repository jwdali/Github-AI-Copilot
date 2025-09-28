using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PortLib.Ports;

namespace PortChecker {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
            Loaded += MainWindow_Loaded;
		}

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Set default selection after InitializeComponent to avoid early SelectionChanged firing
            ProtocolFilterCombo.SelectedIndex = 0;
            RefreshPorts();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPorts();
        }

        private void ProtocolFilterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshPorts();
        }

        private void IncludeConnectionsCheckbox_Changed(object sender, RoutedEventArgs e)
        {
            RefreshPorts();
        }

        private void RefreshPorts()
        {
            var filter = ProtocolFilter.All;
            var tag = (ProtocolFilterCombo.SelectedItem as ComboBoxItem)?.Tag as string;
            filter = tag switch
            {
                "Tcp" => ProtocolFilter.Tcp,
                "Udp" => ProtocolFilter.Udp,
                _ => ProtocolFilter.All
            };

            bool includeConnections = IncludeConnectionsCheckbox.IsChecked == true;

            var snapshot = PortScanner.GetSnapshot(includeListeners: true, includeConnections: includeConnections, filter: filter);

            var listenerRows = snapshot.Listeners
                .OrderBy(r => r.Protocol)
                .ThenBy(r => r.Port)
                .ThenBy(r => r.Address)
                .ToList();
            ListenersGrid.ItemsSource = listenerRows;

            if (includeConnections)
            {
                ConnectionsHeader.Visibility = Visibility.Visible;
                ConnectionsGrid.Visibility = Visibility.Visible;
                var connRows = snapshot.Connections
                    .Select(c => new
                    {
                        Local = $"{c.LocalAddress}:{c.LocalPort}",
                        Remote = $"{c.RemoteAddress}:{c.RemotePort}",
                        State = c.State.ToString()
                    })
                    .OrderBy(x => x.State)
                    .ThenBy(x => x.Local)
                    .ThenBy(x => x.Remote)
                    .ToList();
                ConnectionsGrid.ItemsSource = connRows;
            }
            else
            {
                ConnectionsHeader.Visibility = Visibility.Collapsed;
                ConnectionsGrid.Visibility = Visibility.Collapsed;
                ConnectionsGrid.ItemsSource = null;
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(PortTextBox.Text, out int port) || port is < 1 or > 65535)
            {
                ShowResult($"Invalid port: '{PortTextBox.Text}'. Enter 1-65535.", Colors.DarkRed);
                return;
            }

            var addr = ResolveSelectedAddress();
            bool free = PortUtils.IsPortFree(port, addr);

            if (free)
            {
                ShowResult($"Port {port} is available on {addr}.", Colors.DarkGreen);
            }
            else
            {
                ShowResult($"Port {port} is in use on {addr}. Close the owning process or choose another port.", Colors.DarkRed);
            }
        }

        private IPAddress ResolveSelectedAddress()
        {
            var tag = (AddressCombo.SelectedItem as ComboBoxItem)?.Tag as string;
            return tag switch
            {
                "Any" => IPAddress.Any,
                "IPv6Loopback" => IPAddress.IPv6Loopback,
                "IPv6Any" => IPAddress.IPv6Any,
                _ => IPAddress.Loopback
            };
        }

        private void ShowResult(string message, System.Windows.Media.Color color)
        {
            ResultText.Text = message;
            ResultBorder.BorderBrush = new SolidColorBrush(color);
        }
	}
}