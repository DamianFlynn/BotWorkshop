using System;
using System.Threading.Tasks;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;
using ApiAiSDK;
using SimpleEchoBot.Helpers;

namespace Microsoft.Bot.Sample.SimpleEchoBot
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        protected int count = 1;

        // Add the Reference to API AI Endpoint
        private const string clientAccessToken = "1bdb9a28b15d45f98994b71bc50010c0";
        private static AIConfiguration config = new AIConfiguration(clientAccessToken, SupportedLanguage.English);
        private static ApiAi apiAi = new ApiAi(config);

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            
            var activity = await argument as Activity;

            var aiResponse = apiAi.TextRequest(activity.Text);

            var commonModel = CommonModelMapper.DialogflowToCommonModel(aiResponse);
            commonModel = IntentRouter.Process(commonModel);

            await context.PostAsync(commonModel.Response.Text);

            /*
            var message = await argument;

            if (message.Text == "reset")
            {
                PromptDialog.Confirm(
                    context,
                    AfterResetAsync,
                    "Are you sure you want to reset the count?",
                    "Didn't get that!",
                    promptStyle: PromptStyle.Auto);
            }
            else
            {
                // calculate something for us to return
                int length = (message.Text ?? string.Empty).Length;

                await context.PostAsync($"{this.count++}: You said {message.Text} which was {length} characters");
                context.Wait(MessageReceivedAsync);
            }
            */
            context.Wait(MessageReceivedAsync);
        }

        public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                this.count = 1;
                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count.");
            }
            context.Wait(MessageReceivedAsync);
        }

    }
}