using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Cakeys_Fruity_Template.CMD
{
    public class Purge : ModuleBase<SocketCommandContext>
    {
        [Command("purge")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]

        public async Task PurgeChat(int amount)
        {
            IEnumerable<IMessage> messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
            await ((ITextChannel)Context.Channel).DeleteMessagesAsync(messages);
            const int delay = 3000;
            if (amount > 1)
            {
                IUserMessage m = await ReplyAsync($"Deleted {amount} messages!");
                await Task.Delay(delay);
                await m.DeleteAsync();
                return;
            }
            else
            {
                IUserMessage m = await ReplyAsync($"Deleted {amount} message!");
                await Task.Delay(delay);
                await m.DeleteAsync();
                return;
            }
        }
    }
}
