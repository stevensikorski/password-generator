/*

   AppDelegate.cs
   Password Generator

   Created by Steven Sikorski on 12/29/2022.
   Copyright © 2022 Steven Sikorski. All rights reserved.

*/

using AppKit;
using Foundation;

namespace PasswordGenerator
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : NSApplicationDelegate
	{
		public AppDelegate ()
		{
		}

		public override void DidFinishLaunching (NSNotification notification)
		{
		}

		public override void WillTerminate (NSNotification notification)
		{
		}

        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
            return true;
        }
    }
}