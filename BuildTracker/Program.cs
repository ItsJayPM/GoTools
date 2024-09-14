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
            var serverAddress = "https://d3v4eglovri8yt.cloudfront.net/animation/";
            var httpClient = new HttpClient();
            var counter = 760;

		while (counter < 898)
		{ 
		            var uri = $"{serverAddress}{counter}/go_full.swf";
                    Console.WriteLine(uri);
					var localDir3 = $".\\swfdata\\{counter}\\";
                    Directory.CreateDirectory(localDir3);

                    var localFileName3 = $".\\swfdata\\{counter}\\go_full.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }
		counter = counter + 1;			
		} 
		counter = 760;
				while (counter < 898) 
		{ 
		var uri = $"{serverAddress}{counter}/cc.swf";
                    Console.WriteLine(uri);
					var localDir3 = $".\\swfdata\\{counter}\\";
                    Directory.CreateDirectory(localDir3);

                    var localFileName3 = $".\\swfdata\\{counter}\\cc.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }
		counter = counter + 1;			
		}
			counter = 760;
				while (counter < 898) 
		{ 
		var uri = $"{serverAddress}{counter}/cc_browser.swf";
                    Console.WriteLine(uri);
					var localDir3 = $".\\swfdata\\{counter}\\";
                    Directory.CreateDirectory(localDir3);

                    var localFileName3 = $".\\swfdata\\{counter}\\cc_browser.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }
		counter = counter + 1;			
		}
				var SERVER2 = "https://d3v4eglovri8yt.cloudfront.net/static/f0694094c5d27ed9/client_theme/go/en_US/";
		        var uri = $"{SERVER2}/frameworkResources_en_US.swf";
                    Console.WriteLine(uri);
					var localDir3 = $".\\staticswfdatago\\";
                    Directory.CreateDirectory(localDir3);

                    var localFileName3 = $".\\staticswfdatago\\frameworkResources_en_US.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }

				var SERVER3 = "https://d3v4eglovri8yt.cloudfront.net/static/f0694094c5d27ed9/client_theme/go/en_US/";
		        uri = $"{SERVER3}/go_full.swf";
                    Console.WriteLine(uri);
				localDir3 = $".\\staticswfdatago\\";
                    Directory.CreateDirectory(localDir3);

                localFileName3 = $".\\staticswfdatago\\go_full.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }
					
				var SERVER4 = "https://d3v4eglovri8yt.cloudfront.net/static/f0694094c5d27ed9/client_theme/silver/en_US/";
		        uri = $"{SERVER4}/go_full.swf";
                    Console.WriteLine(uri);
					localDir3 = $".\\staticswfdatasilver\\";
                    Directory.CreateDirectory(localDir3);

                    localFileName3 = $".\\staticswfdatasilver\\go_full.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }
					
				var SERVER5 = "https://d3v4eglovri8yt.cloudfront.net/static/f0694094c5d27ed9/client_theme/domo/en_US/";
		        uri = $"{SERVER5}/go_full.swf";
                    Console.WriteLine(uri);
					localDir3 = $".\\staticswfdatadomo\\";
                    Directory.CreateDirectory(localDir3);

                  localFileName3 = $".\\staticswfdatadomo\\go_full.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }
					
				var SERVER6 = "https://d3v4eglovri8yt.cloudfront.net/static/f0694094c5d27ed9/client_theme/school/en_US/";
		        uri = $"{SERVER6}/go_full.swf";
                    Console.WriteLine(uri);
					localDir3 = $".\\staticswfdataschool\\";
                    Directory.CreateDirectory(localDir3);

                   localFileName3 = $".\\staticswfdataschool\\go_full.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }
		
				var SERVER7 = "https://d3v4eglovri8yt.cloudfront.net/static/f0694094c5d27ed9/client_theme/cn/en_US/";
		        uri = $"{SERVER7}/go_full.swf";
                    Console.WriteLine(uri);
					localDir3 = $".\\staticswfdatacn\\";
                    Directory.CreateDirectory(localDir3);

                    localFileName3 = $".\\staticswfdatacn\\go_full.swf";
                    Console.WriteLine(localFileName3);
					
					//do it now!
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        var data = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(localFileName3, data);
                    }
		}
            }
	}

 






