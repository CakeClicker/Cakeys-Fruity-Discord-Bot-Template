using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Cakeys_Fruity_Template.CMD
{
    public class Swag : ModuleBase<SocketCommandContext>
    {
        [Command("swag"), Summary("Swags the chat")]
        public async Task SwagAsync()
        {
            
                var msg = await ReplyAsync("( ͡° ͜ʖ ͡°)>⌐■-■");
                await Task.Delay(1500);
                await msg.ModifyAsync(x => { x.Content = "( ͡⌐■ ͜ʖ ͡-■)"; });
            }
        }
}
