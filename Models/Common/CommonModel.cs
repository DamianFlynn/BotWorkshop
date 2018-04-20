using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEchoBot.Models.Common
{

    public class CommonModel
    {
        public CommonModel()
        {
            Id = "";
            Session = new Session();
            Request = new Request();
            Response = new Response();
        }

        public string Id { get; set; }
        internal Session Session { get; set; }
        internal Request Request { get; set; }
        internal Response Response { get; set; }
    }

    internal class Response
    {
        public string Text { get; set; }
    }

    internal class Request
    {
        public string Id { get; set; }
        public string Intent { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }
    }

    internal class Session
    {
        public string Id { get; set; }
    }
}