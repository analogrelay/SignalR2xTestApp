using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR2xTestApp
{
    public class ChatHub : Hub
    {
        public void Join(string name)
        {
            Clients.All.broadcastMessage("<system>", $"{name} joined");
        }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}
