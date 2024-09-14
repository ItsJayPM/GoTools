/*
GO4CC Source Code
ft. JANKKKKKKKKK
some notes contain outdated jokes, I wrote this very long ago
*/

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GO4CC
{
    class Program
    {
  public static byte[] Encrypt(byte[] pwd, byte[] data) {
    int a, i, j, k, tmp;
    int[] key, box;
    byte[] cipher;

    key = new int[256];
    box = new int[256];
    cipher = new byte[data.Length];

    for (i = 0; i < 256; i++) {
      key[i] = pwd[i % pwd.Length];
      box[i] = i;
    }
    for (j = i = 0; i < 256; i++) {
      j = (j + box[i] + key[i]) % 256;
      tmp = box[i];
      box[i] = box[j];
      box[j] = tmp;
    }
    for (a = j = i = 0; i < data.Length; i++) {
      a++;
      a %= 256;
      j += box[a];
      j %= 256;
      tmp = box[a];
      box[a] = box[j];
      box[j] = tmp;
      k = box[((box[a] + box[j]) % 256)];
      cipher[i] = (byte)(data[i] ^ k);
    }
    return cipher;
  }

 public static byte[] Decrypt(byte[] pwd, byte[] data) {
    return Encrypt(pwd, data);
  }
        static async Task Main(string[] args)
        {
			//Based on GoAnimateRipper CC
            byte[] key = Encoding.ASCII.GetBytes("**KEY**");
            var httpClient = new HttpClient();

            XElement xmlDoc = XElement.Load(@".\theme\family.xml"); //where we droppin bois

            var themeId = xmlDoc.Attributes().Where(a => a.Name == "id").Single().Value;
            Console.WriteLine(themeId); //test

             var components = xmlDoc.Descendants("component");
        
            foreach (var component in components) //:/
            {
                var ComponentId = component.Attributes().Where(a => a.Name == "id").SingleOrDefault()?.Value;
				var ComponentType = component.Attributes().Where(a => a.Name == "type").Single().Value;
                if (ComponentId == null) ComponentId = component.Attributes().Where(a => a.Name == "component_id").SingleOrDefault()?.Value;
					//get dem thumbnails :)
					if (ComponentType != "bodyshape")
					{
					var localDir = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\input\\{themeId}\\{ComponentType}\\{ComponentId}\\thumbnail.swf";
                    var localFileName2 = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}\\thumbnail.swf";
                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
					//do it now!
					
					if (ComponentType == "mouth")
					{
					var localDir2 = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}";
                    Directory.CreateDirectory(localDir2);

                    var localFileName3 = $".\\input\\{themeId}\\{ComponentType}\\{ComponentId}\\talk_sync.swf";
                    var localFileName4 = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}\\talk_sync.swf";
                    byte[] fileboi2 = File.ReadAllBytes(localFileName3);
					byte[] deCypheredText2 = Decrypt(key, fileboi2);
					File.WriteAllBytes(localFileName4, deCypheredText2);
					
					var localDir5 = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}";
                    Directory.CreateDirectory(localDir5);

                    var localFileName5 = $".\\input\\{themeId}\\{ComponentType}\\{ComponentId}\\talk_sync.swf";
                    var localFileName6 = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}\\talk_sync.swf";
                    byte[] fileboi3 = File.ReadAllBytes(localFileName5);
					byte[] deCypheredText3 = Decrypt(key, fileboi3);
					File.WriteAllBytes(localFileName6, deCypheredText3);
					}

                
                var states = component.Elements("state");

                foreach (var state in states)
                {
                    var StateId = state.Attributes().Where(a => a.Name == "filename").Single().Value;
                
                    var localDir4 = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}";
                    Directory.CreateDirectory(localDir4);

                    var localFileName7 = $".\\input\\{themeId}\\{ComponentType}\\{ComponentId}\\{StateId}";
                    var localFileName8 = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}\\{StateId}";
                    Console.WriteLine(localFileName7);
                    byte[] fileboi4 = File.ReadAllBytes(localFileName7);
					byte[] deCypheredText4 = Decrypt(key, fileboi4);
					File.WriteAllBytes(localFileName8, deCypheredText4);
					//get the stuff
					//lip the sync
					if (ComponentType == "mouth")
					{
						if (StateId.Contains("talk"))
						{
						string[] TEST1 = StateId.Split('.');
						string StateId2 = TEST1[0];
						var localDir5 = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}";
                        Directory.CreateDirectory(localDir5);
                        var localFileName9 = $".\\input\\{themeId}\\{ComponentType}\\{ComponentId}\\{StateId2}_sync.swf";
                        var localFileName10 = $".\\results\\{themeId}\\{ComponentType}\\{ComponentId}\\{StateId2}_sync.swf";
                    byte[] fileboi5 = File.ReadAllBytes(localFileName9);
					byte[] deCypheredText5 = Decrypt(key, fileboi5);
					File.WriteAllBytes(localFileName10, deCypheredText5);
                        Console.WriteLine(localFileName9);

					}
					}
						
				}
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


                    var localDir = $".\\results\\{themeId}\\freeaction\\{BodyId}";
                    Directory.CreateDirectory(localDir);


                    var localFileName = $".\\input\\{themeId}\\freeaction\\{BodyId}\\{ActionId}.swf";
                    var localFileName2 = $".\\results\\{themeId}\\freeaction\\{BodyId}\\{ActionId}.swf";
                    Console.WriteLine(localFileName);
                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
                        Console.WriteLine(localFileName2);
                }
            }
}    
}
}
}



