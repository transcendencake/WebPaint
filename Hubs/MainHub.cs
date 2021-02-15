using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Hubs
{
    public class MainHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}