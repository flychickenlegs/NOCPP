using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NOCPP.Interfaces
{
    public interface ICentralSystem
    {

        Task StartAsync();
        Task StopAsync();
        Task SendAsync(string message);
        Task ReceiveAsync();
        Action<string> OnMessageReceived { get; set; }
        Action<string> OnMessageSent { get; set; }
    }
}
