using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SharpRDPCheck
{
    class Program
    {
        static void ShowUsage()
        {
            string Usage = @"
SharpRDPCheck
Use to check the valid account of the Remote Desktop Protocol.
Support plaintext and ntlmhash.

Author:3gstudent
Reference:https://github.com/RDPUploader/RDPUploader

Note:
The .NET Framework must support TLSv1.2.

Usage:
      SharpRDPBrute.exe <RDP ServerIP> <RDP ServerPort> <mode> <user> <password>
      <mode>:
      - plaintext
      - ntlmhash

Eg:
      SharpRDPBrute.exe 192.168.1.1 3389 plaintext user1 password1
      SharpRDPBrute.exe 192.168.1.1 3389 ntlmhash user1 c5a237b7e9d8e708d8436b6148a25fa1

";
            Console.WriteLine(Usage);
        }

        static void Main(string[] args)
        {
            if (args.Length != 5)
                ShowUsage();
            else
            {
                try
                {
                    Options.Host = args[0];
                    Options.Port = Convert.ToInt32(args[1]);
                    Options.Username = args[3];
                    if (args[2] == "plaintext")
                        Options.Password = args[4];
                    else if (args[2] == "ntlmhash")
                        Options.hash = args[4];
                    else
                    {
                        Console.WriteLine("[!] Wrong parameter");
                        System.Environment.Exit(0);
                    }
                    Network.Connect(Options.Host, Options.Port);
                    MCS.sendConnectionRequest(null, false);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("[!] " + exception.Message);
                    Console.WriteLine("InnerException: " + exception.InnerException);
                }
            }
        }
    }
}