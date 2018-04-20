using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using ApiAiSDK.Model;
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


        // Mapping Common Model to AlexaSDK

        internal static SkillResponse CommonModelToAlexa(CommonModel commonModel)
        {
            var response = new SkillResponse()
            {
                Version = "1.0",
                Response = new ResponseBody()
            };

            response.Response.OutputSpeech = new PlainTextOutputSpeech { Text = commonModel.Response.Text };

            return response;
        }


        // Mapping Dialogflow ApiAiSDK to Common Model

        internal static CommonModel DialogflowToCommonModel(AIResponse aiResponse)
        {
            var commonModel = new CommonModel()
            {
                Id = aiResponse.Id
            };

            commonModel.Session.Id = aiResponse.SessionId;
            commonModel.Request.Intent = aiResponse.Result.Metadata.IntentName;
            commonModel.Request.Parameters = aiResponse.Result.Parameters.ToList()
                .ConvertAll(p => new KeyValuePair<string, string>(p.Key, p.Value.ToString()));

            return commonModel;
        }


        // Mapping Common Model back to Dialogflow for Response

        internal static dynamic CommonModelToDialogflow(CommonModel commonModel)
        {
            return new
            {
                speech = commonModel.Response.Text,
                displayText = commonModel.Response.Text,
                source = "Azure Bootcamp Bots"
            };
        }

    }
}