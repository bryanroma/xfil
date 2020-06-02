using System;
using System.IO;
using Ionic.Zip;
using static xfil.info;


namespace xfil
{
    public class encode
    {

        public static void zippity_zap(string to_compress, string filename)
        {
            Console.WriteLine("[+] Preparing to digest ");

            if (filename.Contains(".zip"))
            {
                //pass
            }
            else
            {
                filename = filename + ".zip";
            }

            ZipFile zip = new ZipFile();
            string filename_b64 = filename + ".b64";

            Console.WriteLine("[+] Output filename: " + filename);
            Console.WriteLine("[+] Source to compress: " + to_compress);
            Console.WriteLine("[+] Base64 output: " + filename_b64);
            zip.AddDirectory(to_compress);
            zip.Save(filename);
            Console.WriteLine("[+] Zipped!");
            Console.WriteLine("[*] MD5SUM of .zip: " + CreateMD5(filename));
            Console.WriteLine("[+] Encoding in base64 . . .");

            byte[] AsBytes = File.ReadAllBytes(filename);
            String AsBase64String = Convert.ToBase64String(AsBytes);
            File.WriteAllText(filename_b64, AsBase64String);

            Console.WriteLine("[+] Done");


        }


    }
}
