using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework
{
    public class ChatClient
    {
        Socket _socket;
        String _clientName;

        public Socket Socket { get => _socket; set => _socket = value; }
        public string ClientName { get => _clientName; set => _clientName = value; }

        public ChatClient(Socket socket, string clientName)
        {
            _socket = socket;
            _clientName = clientName;
        }
    }
}
