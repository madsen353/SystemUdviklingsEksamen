using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabaseServer
{
    public class RequestBody
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string Tags { get; set; }
        public int Customlist { get; set; }
        public string Syntax { get; set; }

        public RequestBody(string type, string tags)
        {
            this.Type = type;
            this.Tags = tags;
            Syntax = $"{{\"type\":\"{Type}\",\"id\":\"map_1c91f0b8-3c0b-4d94-940b-7b2b9c32df3a\",\"tags\":\"{Tags}\",\"customlist\":0}}";
        }
    }
}
