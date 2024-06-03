using System.Net.Sockets;

namespace CSRemoteLog4net
{
    public partial class MainWin : Form
    {
        SocketLogServer server;
        public MainWin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButStartServer_Click(object sender, EventArgs e)
        {
            Uri uri;
            if (!Uri.TryCreate(inputServerAddr.Text, UriKind.Absolute, out uri) && uri.HostNameType == UriHostNameType.IPv4)
            {
                MessageBox.Show("Could not parse host:port", "Error");
                return;
            }

            server ??= new SocketLogServer(uri.Port);
            server.ClientConnected += (SocketLogServer.ClientConnectedHandler)((object _, TcpClient client)=>{ listBox1.DataSource = server.logs; });
            //server.LogUpdated += (SocketLogServer.LogUpdatedEventHandler)((object _, string msg) => { listBox1. });
            server.Start();
        }
    }
}
