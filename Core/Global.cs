using System;
using System.Collections.Generic;
using System.Text;
using Discord.WebSocket;

namespace Cakeys_Fruity_Bot.Core
{
    internal static class Global
    {
        internal static DiscordSocketClient client { get; set; }
        internal static ulong MessageIdToTrack { get; set; }

        public static List<string> UserRoles = new List<string>();

        public static readonly List<string> RESPONSES = new List<string>
        {
            "Response 1",
            "Response 2",
            "Respinse 3"
        };

        public static string GetRandomResponse() // Get A Random Response from the string-list above
        {
            Random random = new Random();
            int randomNumber = random.Next(RESPONSES.Count);
            return RESPONSES[randomNumber];
        }
    }
}
