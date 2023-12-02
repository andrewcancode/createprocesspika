using System.Runtime.InteropServices;
using System;
using System.Diagnostics;
using System.Security;
using System.ComponentModel;
using System.Threading;

namespace createProcess
{
	class Program
	{
	[DllImportAttribute("Kernel32.dll", CharSet=CharSet.Auto, SetLastError = true, ExactSpelling = false)]
	public static extern bool IsDebuggerPresent();
	
	public static void Main(string[] args)
		{
			bool debugPresent = IsDebuggerPresent();
			if (!debugPresent)
			{
				Process startWhoami = new Process();
				Process startIpconfig = new Process();
				Process startNetstat = new Process();
				
/* 				Console.Write("Enter executable to launch: ");
				string exeName = Console.ReadLine();
				
				Console.Write("Enter arguments to pass: ");
				string exeArgs = Console.ReadLine();
				
				if (exeArgs == "")
				{
					exeArgs = null;
				} */
				
				try
				{

				startWhoami.StartInfo.FileName = "whoami.exe";
				startWhoami.StartInfo.Arguments = "/all";
				startWhoami.StartInfo.UseShellExecute = false;
				startWhoami.StartInfo.RedirectStandardOutput = true;
				startWhoami.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
				
				startWhoami.Start();
				
				string output = startWhoami.StandardOutput.ReadToEnd();
				//Thread.Sleep(5000);
				startWhoami.WaitForExit();
				Console.WriteLine("Printing to stdout whoami details ... ");
				Console.WriteLine(output);					
				}
				catch (Win32Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				try
				{

				startIpconfig.StartInfo.FileName = "ipconfig.exe";
				startIpconfig.StartInfo.Arguments = "/all";
				startIpconfig.StartInfo.UseShellExecute = false;
				startIpconfig.StartInfo.RedirectStandardOutput = true;
				startIpconfig.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
				
				startIpconfig.Start();
				
				string output = startIpconfig.StandardOutput.ReadToEnd();
				startIpconfig.WaitForExit();
				Console.WriteLine("Printing to stdout ipconfig details ... ");
				Console.WriteLine(output);				
				}
				catch (Win32Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				try
				{

				startNetstat.StartInfo.FileName = "netstat.exe";
				startNetstat.StartInfo.Arguments = "-aon";
				startNetstat.StartInfo.UseShellExecute = false;
				startNetstat.StartInfo.RedirectStandardOutput = true;
				startNetstat.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
				
				startNetstat.Start();
				
				string output = startNetstat.StandardOutput.ReadToEnd();
				startNetstat.WaitForExit();
				Console.WriteLine("Printing to stdout netstat details ... ");
				Console.WriteLine(output);				
				}
				catch (Win32Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			else
			{
				Console.WriteLine("Debugger Present");
				return;
			}
		}
	}
}