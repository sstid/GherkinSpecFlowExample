﻿using System;
using System.Diagnostics;
using System.Threading;

namespace GherkinDemo2.Tests
{
	public static class WebServer
	{
		private static Process _iisProcess;

		public static void StartIis()
		{
			if (_iisProcess == null)
			{
				var thread = new Thread(StartIisExpress) { IsBackground = true };

				thread.Start();
			}
		}

		private static void StartIisExpress()
		{
			var startInfo = new ProcessStartInfo
			{
				WindowStyle = ProcessWindowStyle.Normal,
				ErrorDialog = true,
				LoadUserProfile = true,
				CreateNoWindow = false,
				UseShellExecute = false,
				Arguments = string.Format("/path:\"{0}\" /port:{1}", @"C:\Users\david.welling\Documents\Visual Studio 2013\Projects\GherkinDemo2\GherkinDemo2", "1316")
			};

			var programfiles = string.IsNullOrEmpty(startInfo.EnvironmentVariables["programfiles"])
								? startInfo.EnvironmentVariables["programfiles(x86)"]
								: startInfo.EnvironmentVariables["programfiles"];

			startInfo.FileName = programfiles + "\\IIS Express\\iisexpress.exe";

			try
			{
				_iisProcess = new Process { StartInfo = startInfo };

				_iisProcess.Start();
				_iisProcess.WaitForExit();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Failed to start IIS Express");
				Debug.WriteLine("Failure: {0}", ex);
				_iisProcess.CloseMainWindow();
				_iisProcess.Dispose();
			}
		}

		public static void StopIis()
		{
			if (_iisProcess != null)
			{
				_iisProcess.CloseMainWindow();
				_iisProcess.Dispose();
			}
		}
	}
}
