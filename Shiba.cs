using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using System.IO;
using System.Net;
using static System.Environment;

namespace Cakeys_Fruity_Template
{
    public class Shiba : ModuleBase<SocketCommandContext> 
    {
        string name = "Shibe API";

        [Command("Shiba")]
        public async Task ShibaAsync()
        {
            const string url = "http://shibe.online/api/shibes?count=1&urls=true&httpsUrls=false";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();
            var response2 = response.Replace("[", "");
            var response3 = response2.Replace("]", "");
            var response4 = response3.Replace("\"", "");

            ColoredLogWrite("{", ConsoleColor.Yellow, name, ConsoleColor.White, "}  ", " [", ConsoleColor.DarkGreen, string.Format("{0:T}", DateTime.Now), ConsoleColor.White, "]  ", "[", "Response: ", ConsoleColor.Green, response4, ConsoleColor.White, "]" + NewLine);
            responseReader.Close();
            await ReplyAsync(response4);
            
        }

        public void ColoredLogWrite(string one, ConsoleColor yellowname, string name, ConsoleColor whiteone, string two, string three, ConsoleColor timecolor, string time, ConsoleColor whitetwo, string four, string clam1, string Responsemsg, ConsoleColor green, string loggedmsg, ConsoleColor whitethelast, string clam2)
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
            Console.Write(clam1);
            Console.Write(Responsemsg);
            Console.ForegroundColor = green;
            Console.Write(loggedmsg);
            Console.ForegroundColor = whitethelast;
            Console.Write(clam2);
        }
    }
}
