using Microsoft.Owin;
using Owin;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Webserver.ObjectTypes;

[assembly: OwinStartupAttribute(typeof(Webserver.Startup))]
namespace Webserver
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }  
    }
}
