using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using SimpleEchoBot.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEchoBot.Helpers
{
    public class CommonModelMapper
    {

        // Mapping Alexa SDK to Common Model

        internal static CommonModel AlexaToCommonModel(SkillRequest skillRequest)
        {
            var commonModel = new CommonModel()
            {
                Id = skillRequest.Request.RequestId
            };

            var requestType = skillRequest.GetRequestType();

            if (requestType == typeof(IntentRequest))
            {
                var intentRequest = skillRequest.Request as IntentRequest;
                commonModel.Request.Intent = intentRequest.Intent.Name;

                if (intentRequest.Intent.Slots != null)
                    commonModel.Request.Parameters = intentRequest.Intent.Slots.ToList()
                        .ConvertAll(s => new KeyValuePair<string, string>(s.Value.Name, s.Value.Value));
            }
            else if (requestType == typeof(LaunchRequest))
            {
                commonModel.Request.Intent = "WelcomeIntent";
            }
            else if (requestType == typeof(SessionEndedRequest))
            {
                return null;
            }

            return commonModel;
        }

    }
}