using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HTTPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                // TODO: Call CreateRedirectionRulesFile() function to create the rules of redirection 
                //Start server
                // 1) Make server object on port 1000
                // 2) Start Server
            */
            CreateRedirectionRulesFile();
            Server server = new Server(1000,"redirectionRules.txt");
            Console.WriteLine("Server Has Started Successfully...");
            server.StartServer();  
            
        }
        static void CreateRedirectionRulesFile()
        {
            /*
                // TODO: Create file named redirectionRules.txt
                // each line in the file specify a redirection rule
                // example: "aboutus.html,aboutus2.html"
                // means that when making request to aboustus.html,, it redirects me to aboutus2
            */
            string File_Name = @"C:\Users\Dell\OneDrive - Faculty Of Computer and Information Technology (Ain Shams University)
                                  \Desktop\Data Communication & Computer Networks\Project\project networks\Template[2021-2022]
                                  \HTTPServer\bin\Debug\redirectionRules.txt";
            if (!File.Exists(File_Name))
            {
                StreamWriter sw = new StreamWriter("redirectionRules.txt");
                StreamReader sr = new StreamReader(File_Name);
                Console.WriteLine(sr);
            }
             
        }
    }
}
