using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace xfil
{
    public class info
    {
        public static void banner()
        {

            Console.WriteLine("\r\n");
            Console.WriteLine("    .o88o.                               o8o                 .");
            Console.WriteLine("    888 ``                               ``'`              .o8");
            Console.WriteLine("   o888oo   .oooo.o  .ooooo.   .ooooo.  oooo   .ooooo.  .o888oo oooo    ooo");
            Console.WriteLine("    888    d88(  `8 d88' `88b d88' ``Y8 `888  d88' `88b   888    `88.  .8'");
            Console.WriteLine("    888    `Y88b.  888   888 888        888  888ooo888   888     `88..8'");
            Console.WriteLine("    888    o.  )88b 888   888 888   .o8  888  888    .o   888 .    `888'");
            Console.WriteLine("   o888o   8``888P' `Y8bod8P' `Y8bod8P' o888o `Y8bod8P'   `888`      d8'");
            Console.WriteLine("                                                                .o...P'");
            Console.WriteLine("                         xfil @ v0.1                            @tr3mb0");

        }

        

        public static void HelpRequired()
        {

            Console.WriteLine("Usage: xfil.exe /http ARG1 ARG2");
            Console.WriteLine("Available options: \r\n");
            Console.WriteLine(" /h or /help or /?  ---- [ Shows this message ]");
            Console.WriteLine(" /encode path_to_encode output_filename.zip ---- [ Compress and encode in base64 ]");
            Console.WriteLine(" /http  IP:PORT exfil.zip.b64 ---- [ Exfiltrate data through HTTP ]");
            Console.WriteLine(" /dns ip exfil.zip.b64 ---- [ Exfiltrate data through DNS ]");



        }





        public static String CreateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    string x = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "‌​").ToLower();
                    x= Regex.Replace(x, @"[^\u0000-\u007F]", string.Empty);
                    return x;
                }
            }
        }


    }
}
