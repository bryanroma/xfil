using System;
using static xfil.info;
using static xfil.HttpTransfer;
using static xfil.encode;
using static xfil.dns_exfil;



namespace xfil
{
    class MainClass
    {
        static void Main(string[] args)
        {
            
            banner();
            
           

            if (args.Length == 0) {
                Console.WriteLine("[!] Missing args! ");
                HelpRequired();

            } else if (args[0] == "/h" || args[0] == "/help" || args[0] == "/?") {

                HelpRequired();

            } else if (args[0] == "/http") {
                try
                {
                    Transfer(args[1], args[2]);

                }
                catch
                {
                    HelpRequired();
                }


            }

            else if (args[0] == "/encode")
            {
                try
                {
                    zippity_zap(args[1], args[2]);

                }
                catch
                {
                    HelpRequired();
                }
            }

            else if (args[0] == "/dns")
            {
                
                    dns_exfiltration(args[1], args[2]);

            }

            else {
                HelpRequired();
            }


        }


    }
}





