using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HelloWorldBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        protected int count = 1;

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            int length = 0;

            if (string.Equals(activity.Text, "reset", StringComparison.OrdinalIgnoreCase))
            {
                PromptDialog.Confirm(context, AfterResetAsync, "Are you sure you want to reset the count?", "Didn't get that!", promptStyle: PromptStyle.None);
            }
            else
            {
                // calculate something for us to return
                length = (activity.Text ?? string.Empty).Length;

                // return our reply to the user
                await context.PostAsync($"{this.count++}. You sent {activity.Text} which was {length} characters");

                context.Wait(MessageReceivedAsync);
            }
        }

        private async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> result)
        {
            var confirm = await result;
            if (confirm)
            {
                this.count = 1;
                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count.");
            }
        }
    }
}