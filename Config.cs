using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Cakeys_Fruity_Template
{
    class Config
    {
        private const string configFolder = "Resources";
        private const string configFile = "config.json";

        public static BotConfig bot;


        static Config()
        {
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);

            if (!File.Exists(configFolder + "/" + configFile))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText(configFolder + "/" + configFile, json);
            }
            else
            {
                string json = File.ReadAllText(configFolder + "/" + configFile);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }
    }
    }

    public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
        public string statustext;
    }
}
