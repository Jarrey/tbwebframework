using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealTimeCommunicationServer
{
    public class AuthenticatedClient : AspComet.Client 
    {
        public string username { get; set; }

        public AuthenticatedClient(string id) : base(id)
        {
        }

    }
}
