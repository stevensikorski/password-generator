/*

   ViewController.cs
   Password Generator

   Created by Steven Sikorski on 12/29/2022.
   Copyright © 2022 Steven Sikorski. All rights reserved.

*/

using System;
using AppKit;
using Foundation;

namespace PasswordGenerator
{
	public partial class ViewController : NSViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		public override NSObject RepresentedObject {
			get {
				return base.RepresentedObject;
			}
			set {
				base.RepresentedObject = value;
			}
		}

        partial void IncludeSymbolsInput(NSObject sender)
        {
            IncludeSymbols = IncludeSymbols ? false : true;
        }

        partial void IncludeNumbersInput(NSObject sender)
        {
            IncludeNumbers = IncludeNumbers ? false : true;
        }

        partial void IncludeUppercaseInput(NSObject sender)
        {
            IncludeUppercase = IncludeUppercase ? false : true;
        }

        partial void IncludeLowercaseInput(NSObject sender)
        {
            IncludeLowercase = IncludeLowercase ? false : true;
        }

        partial void ExcludeSimilarInput(NSObject sender)
        {
            ExcludeSimilar = ExcludeSimilar ? false : true;
        }

        partial void ExcludeAmbiguousInput(NSObject sender)
        {
            ExcludeAmbiguous = ExcludeAmbiguous ? false : true;
        }

        partial void GeneratePasswordButton(NSObject sender)
        {
            GeneratePasswordOutput.StringValue = GeneratePassword();
        }

        partial void GeneratePasswordCopy(NSObject sender)
        {
            if (password == "") return;

            GeneratePasswordOutput.StringValue = "";
            var pasteboard = NSPasteboard.GeneralPasteboard;
            pasteboard.ClearContents();
            pasteboard.WriteObjects(new NSString[] { (NSString)password });
        }

        private string characters;
        private string password;

        private int PasswordLength = 0;
        private bool IncludeSymbols = true;
        private bool IncludeNumbers = true;
        private bool IncludeUppercase = true;
        private bool IncludeLowercase = true;
        private bool ExcludeSimilar = false;
        private bool ExcludeAmbiguous = false;

        public string GeneratePassword()
        {
            PasswordLength = Convert.ToInt16(PasswordLengthInput.StringValue);
            characters = "";
            password = "";
            if (IncludeSymbols && ExcludeAmbiguous) characters = String.Concat(characters, "!@#$%^&*-=_+");
            if (IncludeSymbols && !ExcludeAmbiguous) characters = String.Concat(characters, "!@#$%^&*-=_+(){}[]/'`~,;:.<>");
            if (IncludeNumbers && !ExcludeSimilar) characters = String.Concat(characters, "1234567890");
            else if (IncludeNumbers && ExcludeSimilar) characters = String.Concat(characters, "23456789");
            if (IncludeUppercase && !ExcludeSimilar) characters = String.Concat(characters, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            else if (IncludeUppercase && ExcludeSimilar) characters = String.Concat(characters, "ABCDEFGHJKMNPQRSTUVWXYZ");
            if (IncludeLowercase && !ExcludeSimilar) characters = String.Concat(characters, "abcdefghijklmnopqrstuvwxyz");
            else if (IncludeLowercase && ExcludeSimilar) characters = String.Concat(characters, "abcdefghjkmnpqrstuvwxyz");

            if (characters == "") return "Select password settings";
            if (PasswordLength <= 0) return "Invalid password length";

            for (int i = 0; i < PasswordLength; i++)
            {
                Random random = new Random();

                char letter = characters[random.Next(0, characters.Length)];
                password = String.Concat(password, letter);
            }

            password = password.Substring(0, PasswordLength);

            return password;
        }
    }
}