using FALL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FALL
{
    public class ApexStats
    {
        public ApexStats()
        {

        }

        public static Global DisplayStats(AddUserModel userInfo)
        {
            var client = new HttpClient();

            var apiURL = $"https://api.mozambiquehe.re/bridge?auth=304c12dd29a264b48a99695f6e4389e5&player={userInfo.Name}&platform={userInfo.Platform}";


            var apiDisplay = client.GetStringAsync(apiURL).Result;

            var parsedApiDisplay = JObject.Parse(apiDisplay);

            var globalJson = parsedApiDisplay["global"];
            var legendsJson = parsedApiDisplay["legends"];

            var global = JsonConvert.DeserializeObject<Global>(globalJson.ToString());
            var legends = JsonConvert.DeserializeObject<Legends>(legendsJson.ToString());

            return new Global
            {
                UID = global.UID,
                Name = global.Name,
                Level = global.Level,
                SelectedLegend = legends.selected.LegendName,
                Skin = legends.selected.gameInfo.skin,
                SkinRarity = legends.selected.gameInfo.skinRarity,
                Platform = global.Platform
            };

        }

    }
}
