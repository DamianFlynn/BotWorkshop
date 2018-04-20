using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using SimpleEchoBot.Helpers;
using SimpleEchoBot.Models.Common;
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
            var commonModel = CommonModelMapper.AlexaToCommonModel(skillRequest);
            if (commonModel == null)
                return null;

            commonModel = IntentRouter.Process(commonModel);

            return CommonModelMapper.CommonModelToAlexa(commonModel);

            /*
            var response = new SkillResponse()
            {
                Version = "1.0",
                Response = new ResponseBody()
            };

            var responseText = string.Empty;
            var intentRequest = skillRequest.Request as IntentRequest;

            switch (intentRequest.Intent.Name)
            {
                case "WelcomeIntent":
                    responseText = Handlers.WelcomeIntent.Process(new CommonModel()).Response.Text;
                    break;

                case "ReservationIntent":
                    responseText = Handlers.ReservationIntent.Process(new CommonModel()).Response.Text;
                    break;

            }


            response.Response.OutputSpeech = new PlainTextOutputSpeech()
            {
                //Text = "Hello Alexa!"
                Text = responseText
            };

            return response;
            */
        }

        public string Get()
        {
            return "Hello Alexa!";
        }
    }
}
