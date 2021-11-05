using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Discord;
using Newtonsoft.Json;

namespace Cakeys_Fruity_Template.CMD
{
    public class GameChanger : ModuleBase<SocketCommandContext>
    {
        [Command("playgame")]

        public async Task StatusAsync(string statustext)
        {
            if (Context.User.Id == 112233445566778899)//YOUR ID
            {
                await Context.Client.SetGameAsync(statustext);
            }

            await Task.CompletedTask;
        }
    }
}
