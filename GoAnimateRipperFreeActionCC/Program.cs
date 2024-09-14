using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GoAnimateRipper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serverAddress = "https://d3v4eglovri8yt.cloudfront.net/store/3a981f5cb2739137/cc_store/";
            var httpClient = new HttpClient();

            XElement xmlDoc = XElement.Load(@".\theme\business.xml");

            var themeId = xmlDoc.Attributes().Where(a => a.Name == "id").Single().Value;
            Console.WriteLine(themeId);			
			
			var bodyshapes = xmlDoc.Elements("bodyshape");
            foreach (var bodyshape in bodyshapes)
            {
                var BodyId = bodyshape.Attributes().Where(a => a.Name == "id").Single().Value;

                var actionpacks = bodyshape.Elements("actionpack");
                foreach (var actionpack in actionpacks)
                    {
		        var actions = actionpack.Elements("action");
                foreach (var action in actions)
                    {
                    var ActionId = action.Attributes().Where(a => a.Name == "id").Single().Value;
                    var uri = $"{serverAddress}{themeId}/freeaction/{BodyId}/{ActionId}.swf";
                    Console.WriteLine(uri);


                    var localDir = $".\\{themeId}\\freeaction\\{BodyId}";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\freeaction\\{BodyId}\\{ActionId}.swf";
                    Console.WriteLine(localFileName);

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
                }
            }
}    
}
}
}



