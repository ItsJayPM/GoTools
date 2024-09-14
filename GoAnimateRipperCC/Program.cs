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
			//GoAnimateRipper CC
			//AKA Gamer Girl yay
			//Written by Poley Magik Animations
			//Thanks to Google
			//Stay in school
			//GoTest334
            var serverAddress = "https://d3v4eglovri8yt.cloudfront.net/store/3a981f5cb2739137/cc_store/";
            var httpClient = new HttpClient();

            XElement xmlDoc = XElement.Load(@".\theme\whiteboard.xml"); //where we droppin bois

            var themeId = xmlDoc.Attributes().Where(a => a.Name == "id").Single().Value;
            Console.WriteLine(themeId); //test

             var components = xmlDoc.Descendants("component"); //lets get this head
        
            foreach (var component in components) //:/
            {
                var ComponentId = component.Attributes().Where(a => a.Name == "id").SingleOrDefault()?.Value;
				var ComponentType = component.Attributes().Where(a => a.Name == "type").Single().Value;
                if (ComponentId == null) ComponentId = component.Attributes().Where(a => a.Name == "component_id").SingleOrDefault()?.Value;
					//get dem thumbnails :)
                    var uri2 = $"{serverAddress}{themeId}/{ComponentType}/{ComponentId}/thumbnail.swf";
                    Console.WriteLine(uri2);
					var localDir3 = $".\\{themeId}\\{ComponentType}\\{ComponentId}";
                    Directory.CreateDirectory(localDir3);

                    var localFileName3 = $".\\{themeId}\\{ComponentType}\\{ComponentId}\\thumbnail.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri2))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }
					
					if (ComponentType == "mouth")
					{
				    var uri4 = $"{serverAddress}{themeId}/{ComponentType}/{ComponentId}/talk_sync.swf";
                    Console.WriteLine(uri4);
					var localDir4 = $".\\{themeId}\\{ComponentType}\\{ComponentId}";
                    Directory.CreateDirectory(localDir4);

                    var localFileName4 = $".\\{themeId}\\{ComponentType}\\{ComponentId}\\talk_sync.swf";
                    Console.WriteLine(localFileName4);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri4))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName4, data);
                    }
					var uri5 = $"{serverAddress}{themeId}/{ComponentType}/{ComponentId}/talk.swf";
                    Console.WriteLine(uri5);
					var localDir5 = $".\\{themeId}\\{ComponentType}\\{ComponentId}";
                    Directory.CreateDirectory(localDir5);

                    var localFileName5 = $".\\{themeId}\\{ComponentType}\\{ComponentId}\\talk.swf";
                    Console.WriteLine(localFileName5);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri5))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName5, data);
                    }
					}

                
                var states = component.Elements("state");

                foreach (var state in states)
                {
                    var StateId = state.Attributes().Where(a => a.Name == "filename").Single().Value;
                    var uri = $"{serverAddress}{themeId}/{ComponentType}/{ComponentId}/{StateId}";
                    Console.WriteLine(uri);
                
                    var localDir = $".\\{themeId}\\{ComponentType}\\{ComponentId}";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\{ComponentType}\\{ComponentId}\\{StateId}";
                    Console.WriteLine(localFileName);
					//get the stuff
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }

					//lip the sync
					if (ComponentType == "mouth")
					{
						if (StateId.Contains("talk"))
						{
						string[] TEST1 = StateId.Split('.');
						string StateId2 = TEST1[0];
						var localDir2 = $".\\{themeId}\\{ComponentType}\\{ComponentId}";
                        Directory.CreateDirectory(localDir2);
                        var uri3 = $"{serverAddress}{themeId}/{ComponentType}/{ComponentId}/{StateId2}_sync.swf";
                        Console.WriteLine(uri3);
                        var localFileName2 = $".\\{themeId}\\{ComponentType}\\{ComponentId}\\{StateId2}_sync.swf";
                        Console.WriteLine(localFileName2);
					 using (var response = await httpClient.GetAsync(uri3))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName2, data);
                    }
					}
					}
						
				}

                }
				

            var libraries = xmlDoc.Descendants("library");
        
                    foreach (var library in libraries)
                    {
                    var LibraryType = library.Attributes().Where(a => a.Name == "type").Single().Value;
                    var LibraryId = library.Attributes().Where(a => a.Name == "path").Single().Value;
					var LibraryThumb = library.Attributes().Where(a => a.Name == "thumb").Single().Value;
					if (LibraryId == null) LibraryId = library.Attributes().Where(a => a.Name == "component_id").SingleOrDefault()?.Value;
                    var uri = $"{serverAddress}{themeId}/{LibraryType}/{LibraryId}.swf";
                    Console.WriteLine(uri);


                    var localDir = $".\\{themeId}\\{LibraryType}\\";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\{themeId}\\{LibraryType}\\{LibraryId}.swf";
                    Console.WriteLine(localFileName);

                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName, data);
                    }
				 var uri2 = $"{serverAddress}{themeId}/{LibraryType}/{LibraryThumb}";
                    Console.WriteLine(uri);


                    var localDir2 = $".\\{themeId}\\{LibraryType}\\";
                    Directory.CreateDirectory(localDir2);

                    var localFileName2 = $".\\{themeId}\\{LibraryType}\\{LibraryThumb}";
                    Console.WriteLine(localFileName2);

                    using (var response = await httpClient.GetAsync(uri2))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName2, data);
                    }
                }
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



