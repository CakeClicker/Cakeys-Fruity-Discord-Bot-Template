using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Discord;

namespace Cakeys_Fruity_Template
{
   public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("Ping")]

        public async Task PingAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle($"Pong! :ping_pong: - {Context.Client.Latency}ms")
                .WithDescription("Ping me again Daddy!!")
                .WithColor(Color.Green);

            await ReplyAsync("", false, builder.Build());
        }
    }
}
