using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Cakeys_Fruity_Template.CMD
{
    public class Debug_Update : ModuleBase<SocketCommandContext>
    {
        [Command("debug")]

        public async Task DebugAsync()
        {
            var message = Context.Message;
            var serverId = (message.Channel as SocketGuildChannel)?.Guild.Id.ToString() ?? "n/a";
            var botVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
            await ReplyAsync($"```Server ID: { serverId} | Channel ID: { message.Channel.Id} | Your ID: { message.Author.Id} | Shard ID: { Context.Client.ShardId} | Version: { botVersion} | Discord.NET Version: { DiscordSocketConfig.Version}```");
        }

        [Command("BotInfo", RunMode = RunMode.Async)]
        public async Task StatsAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();
            var ramUsages = Math.Round((decimal)Process.GetCurrentProcess().PrivateMemorySize64 / 1000000000, 2);
            var upTime = DateTime.Now.Subtract(Process.GetCurrentProcess().StartTime);
            var upTimeString = $"{upTime.Days}D:{upTime.Hours}H:{upTime.Minutes}M:{upTime.Seconds}S";
            builder.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
            builder.WithTitle("Bot info for " + Context.User.Username);
            builder.AddField("Bot:", $"{Context.Client.CurrentUser.Username}#{Context.Client.CurrentUser.Discriminator}", true);
            builder.AddField("Bot id:", Context.Client.CurrentUser.Id, true);
            builder.AddField("Owner:", "CakeClicker#0288", true);
            builder.AddField("Owner id:", "473700353980760074", true);
            builder.AddField("RAM Usage:", $"{ramUsages}GB", true);
            builder.AddField("Shard ID:", Context.Client.ShardId, true);
            builder.AddField("Servers:", Context.Client.Guilds.Count, true);
            builder.AddField("Up time:", upTimeString, true);
            builder.WithColor(new Color(255, 255, 255));
            builder.WithCurrentTimestamp();
            await ReplyAsync("", false, builder.Build()).ConfigureAwait(false);
        }
    }
}
