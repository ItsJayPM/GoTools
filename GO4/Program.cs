/*
GO4 Source Code
ft. Snagged GO4 stuff
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

namespace GO4
{
    class Program
    {
  public static byte[] Encrypt(byte[] pwd, byte[] data) { //Not gonna notate this RC4 stuff
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

        static async Task Main(string[] args) //Here we go.
        {
			byte[] key = Encoding.ASCII.GetBytes("**KEY**"); //DECRYPTION KEY GOES HERE!!!
            var httpClient = new HttpClient();
            
            XElement xmlDoc = XElement.Load(@".\themes\**THEMENAME**.xml"); //Theme stuff :P

            var themeId = xmlDoc.Attributes().Where(a => a.Name == "id").Single().Value;
            Console.WriteLine(themeId);


            var props = xmlDoc.Elements("prop"); //PROP STUFF
            foreach (var prop in props)
            {
				
                var propId = prop.Attributes().Where(a => a.Name == "id").Single().Value;

                var states = prop.Elements("state");
                if (states.Count() > 0)
                {
                foreach (var state in states)
                    {
                    var StateId = state.Attributes().Where(a => a.Name == "id").Single().Value;

                    var localDir = $".\\results\\{themeId}\\prop\\{propId}";
                    Directory.CreateDirectory(localDir);
           
                    var localFileName = $".\\input\\{themeId}\\prop\\{propId}\\{StateId}";
                    var localFileName2 = $".\\results\\{themeId}\\prop\\{propId}\\{StateId}";
                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
					
                }
                }
                else
                {

                    var localDir = $".\\results\\{themeId}\\prop";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\input\\{themeId}\\prop\\{propId}";
                    var localFileName2 = $".\\results\\{themeId}\\prop\\{propId}";
                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
                }
            }
			Console.WriteLine("Props: OK");



            var effects = xmlDoc.Descendants("effect"); //EFFECT STUFF
        
                    foreach (var effect in effects)
                    {
                    var EffectId = effect.Attributes().Where(a => a.Name == "id").Single().Value;
                    if (EffectId.Contains(".swf"))
                    {
                    var localDir = $".\\results\\{themeId}\\effect";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\input\\{themeId}\\effect\\{EffectId}";
                    var localFileName2 = $".\\results\\{themeId}\\effect\\{EffectId}";
                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
                   }
                }
				Console.WriteLine("Effects: OK");
		
            var backgrounds = xmlDoc.Descendants("background"); //BG STUFF
        
                    foreach (var background in backgrounds)
                    {
                    var BGId = background.Attributes().Where(a => a.Name == "id").Single().Value;

                    var localDir = $".\\results\\{themeId}\\bg";
                    Directory.CreateDirectory(localDir);
                    var localFileName = $".\\input\\{themeId}\\bg\\{BGId}";
                    var localFileName2 = $".\\results\\{themeId}\\bg\\{BGId}";
                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
                }
				Console.WriteLine("Backrounds: OK");

                var sounds = xmlDoc.Descendants("sound"); //SOUND STUFF
                    foreach (var sound in sounds)
                    {
                    var SoundId = sound.Attributes().Where(a => a.Name == "id").Single().Value;
					if (SoundId.Contains(".swf"))
                    {						

                    var localDir = $".\\results\\{themeId}\\sound";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\input\\{themeId}\\sound\\{SoundId}";
                    var localFileName2 = $".\\results\\{themeId}\\sound\\{SoundId}";

                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
					}
                }
				Console.WriteLine("Sounds: OK");

            var chars = xmlDoc.Descendants("char"); //BIG CHAR BLOCK
            foreach (var character in chars)
            {
                var charId = character.Attributes().Where(a => a.Name == "id").Single().Value;
                var actions = character.Descendants("action");
				var motions = character.Descendants("motion");

                foreach (var action in actions) //ACTIONS
                {
                    var actionId = action.Attributes().Where(a => a.Name == "id").Single().Value;

                    var localDir = $".\\results\\{themeId}\\char\\{charId}";
                    Directory.CreateDirectory(localDir);

                    var localFileName = $".\\input\\{themeId}\\char\\{charId}\\{actionId}";
                    var localFileName2 = $".\\results\\{themeId}\\char\\{charId}\\{actionId}";
                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
                }
            
			foreach (var motion in motions) //MOTIONS
                {
                    var motionId = motion.Attributes().Where(a => a.Name == "id").Single().Value;

                    var localDir = $".\\results\\{themeId}\\char\\{charId}";

                    var localFileName = $".\\input\\{themeId}\\char\\{charId}\\{motionId}";
                    var localFileName2 = $".\\results\\{themeId}\\char\\{charId}\\{motionId}";
                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
                }
				
                

                var facials = character.Descendants("facial"); //FACIAL EXPRESSIONS
                foreach (var facial in facials)
                {
                    var facialId = facial.Attributes().Where(a => a.Name == "id").Single().Value;

                    var localDir = $".\\results\\{themeId}\\char\\{charId}\\head";
                    Directory.CreateDirectory(localDir);
                    var localFileName = $".\\input\\{themeId}\\char\\{charId}\\head\\{facialId}";
                    var localFileName2 = $".\\results\\{themeId}\\char\\{charId}\\head\\{facialId}";

                    byte[] fileboi = File.ReadAllBytes(localFileName);
					byte[] deCypheredText = Decrypt(key, fileboi);
					File.WriteAllBytes(localFileName2, deCypheredText);
                }


            }
			Console.WriteLine("Characters: OK");
			Console.WriteLine("GO4");
			Console.WriteLine("Written by Poley Magik Animations");
			Console.WriteLine("Thanks for using this tool");
        }
    }
}
