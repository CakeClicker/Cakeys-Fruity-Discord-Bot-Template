using System;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cakeys_Fruity_Bot.Core;
using static System.Environment;
using System.Threading;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace Cakeys_Fruity_Template
{
   public sealed class Program : ModuleBase<SocketCommandContext>
    {
        DiscordSocketClient _client;
        CommandHandler _Handler;
        static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Cakeys Fruity Template";

            if (Config.bot.token == "" || Config.bot.token == null) return;
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Error
            });
            //Extra _client
            PrintIntro();
            _client.Log += Log;
            _client.Connected += LogConnected;
            //_client.UserIsTyping += LogTyping;

            //_client
            _client.MessageReceived += LogMsg;

            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            if (Config.bot.statustext != null) await _client.SetGameAsync(Config.bot.statustext);

            Global.client = _client;
            _Handler = new CommandHandler();
            await _Handler.InitialiseAsync(_client);
            ConsoleInput();
            await Task.Delay(-1);

        }

        private Task LogConnected()
        {
            string time = string.Format("{0:T}", DateTime.Now);
            // PrintLogMsg(_client.CurrentUser + " is now connected to Discord! " + "Ping: " + _client.Latency + "ms" + NewLine);
            ColoredLogWrite("{", ConsoleColor.Yellow, name, ConsoleColor.White, "}", "  [", ConsoleColor.DarkGreen, string.Format("{0:T}", DateTime.Now), ConsoleColor.White, "]  ", _client.CurrentUser + " connected to API! " + "Ping: " + _client.Latency + "ms" + NewLine);
            return Task.CompletedTask;
        }
        string name = "Cakeys Template";
       // string time = string.Format("{0:T}", DateTime.Now);
        
        private void PrintIntro()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"

   ____      _                    _____           _ _           ____        _   
  / ___|__ _| | _____ _   _ ___  |  ___| __ _   _(_) |_ _   _  | __ )  ___ | |_ 
 | |   / _` | |/ / _ \ | | / __| | |_ | '__| | | | | __| | | | |  _ \ / _ \| __|
 | |__| (_| |   <  __/ |_| \__ \ |  _|| |  | |_| | | |_| |_| | | |_) | (_) | |_ 
  \____\__,_|_|\_\___|\__, |___/ |_|  |_|   \__,_|_|\__|\__, | |____/ \___/ \__|
                      |___/                             |___/                   

");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
            ColoredLogWrite("{", ConsoleColor.Yellow, name, ConsoleColor.White,"}", "  [", ConsoleColor.DarkGreen, string.Format("{0:T}", DateTime.Now), ConsoleColor.White, "]  ", "Initialising..." + NewLine);
            Thread.Sleep(600);
            ColoredLogWrite("{", ConsoleColor.Yellow, name, ConsoleColor.White,"}", "  [", ConsoleColor.DarkGreen, string.Format("{0:T}", DateTime.Now), ConsoleColor.White, "]  ", "Log Mode: " + LogSeverity.Warning.ToString() + NewLine);
            Thread.Sleep(400);
            ColoredLogWrite("{", ConsoleColor.Yellow, name, ConsoleColor.White,"}", "  [", ConsoleColor.DarkGreen, string.Format("{0:T}", DateTime.Now), ConsoleColor.White, "]  ", "User Status: " + Discord.UserStatus.Online + NewLine);
            Thread.Sleep(700);
            ColoredLogWrite("{", ConsoleColor.Yellow, name, ConsoleColor.White,"}", "  [", ConsoleColor.DarkGreen, string.Format("{0:T}", DateTime.Now), ConsoleColor.White, "]  ", "Startup finished!" + NewLine);
        }

        private void ConsoleInput() //changed from async to void, keeping an eye on it
        {
            var input = string.Empty;
            while (input.Trim().ToLower() != "block")
            {
                input = Console.ReadLine();
                if (input.Trim().ToLower() == 
                    "message")
                    ConsoleSendMessage();
            }
        }
        public void PrintLogMsg(string Message)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("{" + name + "} " + "[" + string.Format("{0:T}", dt) + "] " + Message);
        }
        public void ColoredLogWrite(string one, ConsoleColor yellowname, string name, ConsoleColor whiteone, string two, string three, ConsoleColor timecolor, string time, ConsoleColor whitetwo, string four, string loggedmsg)
        {
            Console.Write(one);
            Console.ForegroundColor = yellowname;
            Console.Write(name);
            Console.ForegroundColor = whiteone;
            Console.Write(two);
            Console.Write(three);
            Console.ForegroundColor = timecolor;
            Console.Write(time);
            Console.ForegroundColor = whitetwo;
            Console.Write(four);
            Console.Write(loggedmsg);
        }

        public void ColoredLogWriteUserSentMsg(string one, ConsoleColor yellowname, string name, ConsoleColor whiteone, string two, string three, ConsoleColor timecolor, string time, ConsoleColor whitetwo, string four, string UserClam1, ConsoleColor UserColor, string User, ConsoleColor whiteclam2user, string userclosedclam, string hasSent, string msgclam1, ConsoleColor greenmsg, string loggedmsg, ConsoleColor whiteclamuser2, string whiteclamfromuser2, string insideofchannel, string channelclam1, ConsoleColor channelcolor, string channel, ConsoleColor whitethelast, string channelclam2 )
        {
            Console.Write(one);
            Console.ForegroundColor = yellowname;
            Console.Write(name);
            Console.ForegroundColor = whiteone;
            Console.Write(two);
            Console.Write(three);
            Console.ForegroundColor = timecolor;
            Console.Write(time);
            Console.ForegroundColor = whitetwo;
            Console.Write(four);
            Console.Write(UserClam1);
            Console.ForegroundColor = UserColor;
            Console.Write(User);
            Console.ForegroundColor = whiteclam2user;
            Console.Write(userclosedclam);
            Console.Write(hasSent);
            Console.Write(msgclam1);
            Console.ForegroundColor = greenmsg;
            Console.Write(loggedmsg);
            Console.ForegroundColor = whiteclamuser2;
            Console.Write(whiteclamfromuser2);
            Console.Write(insideofchannel);
            Console.Write(channelclam1);
            Console.ForegroundColor = channelcolor;
            Console.Write(channel);
            Console.ForegroundColor = whitethelast;
            Console.Write(channelclam2);

        }
        private async Task LogMsg(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
            {
                ColoredLogWriteUserSentMsg("{", ConsoleColor.Yellow, name, ConsoleColor.White, "}", "  [", ConsoleColor.DarkGreen, string.Format("{0:T}", DateTime.Now), ConsoleColor.White, "]  ", "{", ConsoleColor.Yellow, msg.Author.ToString(), ConsoleColor.White, "} ", "sent: ", "[", ConsoleColor.Green, msg.ToString(), ConsoleColor.White, "] ", "in", " {", ConsoleColor.DarkMagenta, msg.Channel.Name, ConsoleColor.White, "}" + NewLine);
            }
        }
        public void ColoredConsoleWrite(ConsoleColor yellow, string Author, ConsoleColor white, string hasSent, ConsoleColor green, string MESSAGE, ConsoleColor whiteagain, string InDateTime)
        {
            Console.ForegroundColor = yellow;
            Console.Write(Author);
            Console.ForegroundColor = white;
            Console.Write(hasSent);
            Console.ForegroundColor = green;
            Console.WriteLine(MESSAGE);
            Console.ForegroundColor = whiteagain;
            Console.WriteLine(InDateTime);
        }

        private async Task ConsoleSendMessage()
        {
            Console.WriteLine("Select the guild:");
            var guild = GetSelectedGuild(_client.Guilds);
            var textChannel = GetSelectedTextChannel(guild.TextChannels);
            var msg = string.Empty;
            while (msg.Trim() == string.Empty)
            {
                Console.WriteLine("Your Message:");
                msg = Console.ReadLine();
            }
            await textChannel.SendMessageAsync(msg);
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }

        private SocketTextChannel GetSelectedTextChannel(IEnumerable<SocketTextChannel> channels)
        {
            var textChannels = channels.ToList();
            var maxIndex = textChannels.Count - 1;
            for (var i = 0; i <= maxIndex; i++)
            {
                Console.WriteLine($"{i} - {textChannels[i].Name}");
            }

            var selectedIndex = -1;
            while (selectedIndex < 0 || selectedIndex > maxIndex)
            {
                var success = int.TryParse(Console.ReadLine().Trim(), out selectedIndex);
                if (!success)
                {
                    Console.WriteLine("That was an invalid index, try again.");
                    selectedIndex = -1;
                }
            }

            return textChannels[selectedIndex];
        }

        private SocketGuild GetSelectedGuild(IEnumerable<SocketGuild> guilds)
        {
            var socketGuilds = guilds.ToList();
            var maxIndex = socketGuilds.Count - 1;
            for (var i = 0; i <= maxIndex; i++)
            {
                Console.WriteLine($"{i} - {socketGuilds[i].Name}");
            }

            var selectedIndex = -1;
            while (selectedIndex < 0 || selectedIndex > maxIndex)
            {
                var success = int.TryParse(Console.ReadLine().Trim(), out selectedIndex);
                if (!success)
                {
                    Console.WriteLine("That was an invalid index, try again.");
                    selectedIndex = -1;
                }
            }

            return socketGuilds[selectedIndex];
        }
    }
}
