using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webserver.ObjectTypes
{
    public class ServerBasedSportsObject
    {
        public string title { get; set; }
        public string text { get; set; }
        public string desc { get; set; }
        public string link { get; set; }
        public string image { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public int locationId { get; set; }
        //List 
        public string tags { get; set; }
    }
}