/*

   Main.cs
   Password Generator

   Created by Steven Sikorski on 12/29/2022.
   Copyright © 2022 Steven Sikorski. All rights reserved.

*/

using AppKit;

namespace PasswordGenerator
{
	static class MainClass
	{
		static void Main (string [] args)
		{
			NSApplication.Init ();
			NSApplication.Main (args);
		}
	}
}