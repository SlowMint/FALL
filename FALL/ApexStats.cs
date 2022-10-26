namespace FALL
{
    public class ApexStats
    {
        public ApexStats()
        {

        }

        public static void DisplayStats()
        {
            var client = new HttpClient();

            var apiURL = "https://api.mozambiquehe.re/bridge?auth=304c12dd29a264b48a99695f6e4389e5&player=AlienRift6782&platform=X1";

            var apiDisplay = client.GetStringAsync(apiURL).Result;

            Console.WriteLine(apiDisplay);
        }
    }


}
