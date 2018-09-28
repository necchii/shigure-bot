using System;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace shigureBot
{
    public class Program
    {
        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient Client;
        private CommandService Commands;
        private CommandHandler Handler;

        public async Task StartAsync()
        {
            Client = new DiscordSocketClient();

            Commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
            });

            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());

            Client.Ready += Client_Ready;

            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();
           
            Handler = new CommandHandler(Client);

            await Task.Delay(-1);
        }

        private async Task Client_Ready()
        {
            await Client.SetGameAsync("@Shigure | (✿╹◡╹)");
        }       
       
    }
}
