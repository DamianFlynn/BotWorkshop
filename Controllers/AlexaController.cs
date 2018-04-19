using Alexa.NET.Request;
using Alexa.NET.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleEchoBot.Controllers
{
    public class AlexaController : ApiController
    {
        public SkillResponse Post(SkillRequest skillRequest)
        {
            var response = new SkillResponse()
            {
                Version = "1.0",
                Response = new ResponseBody()
            };

            response.Response.OutputSpeech = new PlainTextOutputSpeech()
            {
                Text = "Hello Alexa!"
            };

            return response;
        }

        public string Get()
        {
            return "Hello Alexa!";
        }
    }
}
