using System;
using System.Diagnostics;
using Binarysharp.MemoryManagement;

namespace QuakeLive500FPS
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1
		private static void Main(string[] args)
		{
			Console.WriteLine("== Quake Live 500 FPS patcher ==");
			Process[] processesByName = Process.GetProcessesByName("quakelive_steam");
			if (processesByName.Length == 0)
			{
				Console.WriteLine("No Quake Live found running");
				Console.ReadLine();
				return;
			}
			Console.WriteLine(string.Format("Found QuakeLive running :{0}", processesByName[0].Id));
			MemorySharp memorySharp = new MemorySharp(processesByName[0]);
			IntPtr address = new IntPtr(17051800);
			int num = memorySharp.Read<int>(address, true);
			Console.WriteLine(string.Format("Current FPS is : {0}", num));
			if (num != 250 && num != 125)
			{
				Console.WriteLine("FPS readout missmatch, 250/125 expected, exiting");
				Console.ReadLine();
				return;
			}
			memorySharp.Write<int>(address, 400, true);
			Console.WriteLine("PATCHED");
			Console.ReadLine();
		}
	}
}
