using ApiAiSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleEchoBot.Controllers
{
    public class DialogflowController : ApiController
    {
        public dynamic Post(AIResponse aiResponse)
        {

            var response = new
            {
                speech = "Hello Dialogflow",
                text = "Hello Dialogflow"

            };

            return response;
        }

        public string Get()
        {
            return "Hello Dialogflow!";
        }
    }
}