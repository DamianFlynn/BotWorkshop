using ApiAiSDK.Model;
using SimpleEchoBot.Helpers;
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
            var commonModel = CommonModelMapper.DialogflowToCommonModel(aiResponse);
            if (commonModel == null)
                return null;

            commonModel = IntentRouter.Process(commonModel);

            return CommonModelMapper.CommonModelToDialogflow(commonModel);

            /*
            var response = new
            {
                speech = "Hello Dialogflow",
                text = "Hello Dialogflow"

            };

            return response;
            */
        }

        public string Get()
        {
            return "Hello Dialogflow!";
        }
    }
}