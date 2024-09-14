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
            var serverAddress = "https://d3v4eglovri8yt.cloudfront.net/store/3a981f5cb2739137/";
            var httpClient = new HttpClient();
            
            XElement xmlDoc = XElement.Load(@".\themes\theme.xml");

            var themeId = xmlDoc.Attributes().Where(a => a.Name == "id").Single().Value;
            Console.WriteLine(themeId);


            var props = xmlDoc.Elements("prop");
			Console.WriteLine("Ripper ready! Now downloading!");
            foreach (var prop in props)
            {
				
                var propId = prop.Attributes().Where(a => a.Name == "id").Single().Value;

                var states = prop.Elements("state");
                if (states.Count() > 0)
                {
                foreach (var state in states)
                    {
                    var StateId = state.Attributes().Where(a => a.Name == "id").Single().Value;
                    var uri = $"{serverAddress}{themeId}/prop/{propId}/{StateId}";


                    var localDir = $".\\{themeId}\\prop\\{propId}";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\prop\\{propId}\\{StateId}";

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
                }
                }
                else
                {
                    var uri = $"{serverAddress}{themeId}/prop/{propId}";


                    var localDir = $".\\{themeId}\\prop";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\prop\\{propId}";

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
					
                }
            }
			Console.WriteLine("Props: OK");



            var effects = xmlDoc.Descendants("effect");
        
                    foreach (var effect in effects)
                    {
                    var EffectId = effect.Attributes().Where(a => a.Name == "id").Single().Value;
                    var uri = $"{serverAddress}{themeId}/effect/{EffectId}";


                    var localDir = $".\\{themeId}\\effect";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\effect\\{EffectId}";

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
                }
				Console.WriteLine("Effects: OK");

            var backgroundsthumb = xmlDoc.Descendants("compositebg");
        
                    foreach (var compositebg in backgroundsthumb)
                    {
                    var BGthumb = compositebg.Attributes().Where(a => a.Name == "thumb").Single().Value;
                    var uri = $"{serverAddress}{themeId}/bg/{BGthumb}";


                    var localDir = $".\\{themeId}\\bg";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\bg\\{BGthumb}";

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
                }
				Console.WriteLine("Background Thumbnails: OK");
		
            var backgrounds = xmlDoc.Descendants("background");
        
                    foreach (var background in backgrounds)
                    {
                    var BGId = background.Attributes().Where(a => a.Name == "id").Single().Value;
                    var uri = $"{serverAddress}{themeId}/bg/{BGId}";


                    var localDir = $".\\{themeId}\\bg";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\bg\\{BGId}";

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
                }
				Console.WriteLine("Backrounds: OK");

                var sounds = xmlDoc.Descendants("sound");
        
                    foreach (var sound in sounds)
                    {
                    var SoundId = sound.Attributes().Where(a => a.Name == "id").Single().Value;
                    var uri = $"{serverAddress}{themeId}/sound/{SoundId}";


                    var localDir = $".\\{themeId}\\sound";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\sound\\{SoundId}";

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
                }
				Console.WriteLine("Sounds: OK");

            var chars = xmlDoc.Descendants("char");
            foreach (var character in chars)
            {
                var charId = character.Attributes().Where(a => a.Name == "id").Single().Value;
                var actions = character.Descendants("action");
				var motions = character.Descendants("motion");

                foreach (var action in actions)
                {
                    var actionId = action.Attributes().Where(a => a.Name == "id").Single().Value;
                    var uri = $"{serverAddress}{themeId}/char/{charId}/{actionId}";


                    var localDir = $".\\{themeId}\\char\\{charId}";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\char\\{charId}\\{actionId}";

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
                }
            
			foreach (var motion in motions)
                {
                    var motionId = motion.Attributes().Where(a => a.Name == "id").Single().Value;
                    var uri = $"{serverAddress}{themeId}/char/{charId}/{motionId}";
                    Console.WriteLine(uri);


                    var localDir = $".\\{themeId}\\char\\{charId}";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\char\\{charId}\\{motionId}";

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
                }
				
                

                var facials = character.Descendants("facial");
                foreach (var facial in facials)
                {
                    var facialId = facial.Attributes().Where(a => a.Name == "id").Single().Value;
                    var uri = $"{serverAddress}{themeId}/char/{charId}/head/{facialId}";


                    var localDir = $".\\{themeId}\\char\\{charId}\\head";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\char\\{charId}\\head\\{facialId}";
                    Console.WriteLine(localFileName);

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
                }


            }
			Console.WriteLine("Characters: OK");
			Console.WriteLine("GoAnimateRipper V1.4");
			Console.WriteLine("Written by Poley Magik Animations");
			Console.WriteLine("Thanks for using this tool");
        }
    }
}
