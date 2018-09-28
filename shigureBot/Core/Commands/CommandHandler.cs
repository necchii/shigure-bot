using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

using Discord.Commands;
using Discord.WebSocket;

namespace shigureBot
{
    public class CommandHandler
    {
        private DiscordSocketClient Client;
        private CommandService Service;

        public CommandHandler(DiscordSocketClient client)
        {
            Client = client;

            Service = new CommandService();

            Service.AddModulesAsync(Assembly.GetEntryAssembly());

            Client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
                 
            if (msg == null) return;

            var context = new SocketCommandContext(Client, msg);

            int argPos = 0;
            if (msg.HasCharPrefix('~', ref argPos) || msg.HasMentionPrefix(Client.CurrentUser, ref argPos))
            {
                var result = await Service.ExecuteAsync(context, argPos);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }

        }
    }
}
