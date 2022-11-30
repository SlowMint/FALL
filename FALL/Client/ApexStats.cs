using FALL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FALL.Client
{
    public class ApexStats
    {
        public ApexStats()
        {

        }

        public static Global DisplayStats(AddUserModel userInfo)
        {
            //Apex API Client
            var client = new HttpClient();

            try
            {

                //URL Assembly - Auth Key Does Not Expire
                var apiURL = $"https://api.mozambiquehe.re/bridge?auth=304c12dd29a264b48a99695f6e4389e5&player={userInfo.Name}&platform={userInfo.Platform}";

                //Covert Response to String
                var apiDisplay = client.GetStringAsync(apiURL).Result;

                //String > JSON
                var parsedApiDisplay = JObject.Parse(apiDisplay);

                //Null Exception for Request Errors
                var globalJson = parsedApiDisplay["global"];
                var legendsJson = parsedApiDisplay["legends"];
                if (legendsJson == null)
                {
                    return null;
                }

                //JSON > Deserialize to Objects - "Global"
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
            catch
            {
                return null;
            }

        }

    }
}
