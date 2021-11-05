using System;
using System.Collections.Generic;
using System.Text;
using Discord.WebSocket;
using Discord.Commands;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Cakeys_Fruity_Bot;

namespace Cakeys_Fruity_Template
{
   public  class Minesweeper : ModuleBase<SocketCommandContext>
    {
        private static Random rand = new Random();

        [Command("minesweeper")]
        [Summary("Minesweeper minigame")]

        public async Task MinesweeperAsync([Summary("width")] int width, [Summary("height")] int height, [Summary("bomb count")] int bombs)
        {
            if (width < 1 || height < 1 || bombs < 0)
            {
                await Context.Channel.SendMessageAsync("Ungültige Rastergröße oder Bombenzahl");
            }
            else if (width > 10 || height > 10)
            {
                await Context.Channel.SendMessageAsync("Max. Rastegröße: 10 x 10");
            }
            else if (bombs >= height * width)
            {
                await Context.Channel.SendMessageAsync("Zu viele Bomben!");
            }
            else
            {
                MinesweeperBoard game = new MinesweeperBoard(height, width, bombs);
                EmbedBuilder builder = new EmbedBuilder();
                builder.Title = ":bomb: Minesweeper";
                builder.Color = Color.DarkerGrey;
                builder.Description = game.ToString();
                await SendEmbed(builder.Build());
            }
        }

        private async Task SendEmbed(Embed embed)
        {
            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
