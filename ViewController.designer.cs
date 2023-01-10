using Foundation;
using System.CodeDom.Compiler;

namespace PasswordGenerator
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField GeneratePasswordOutput { get; set; }

		[Outlet]
		AppKit.NSTextField PasswordLengthInput { get; set; }

		[Action ("ExcludeAmbiguousInput:")]
		partial void ExcludeAmbiguousInput (Foundation.NSObject sender);

		[Action ("ExcludeSimilarInput:")]
		partial void ExcludeSimilarInput (Foundation.NSObject sender);

		[Action ("GeneratePasswordButton:")]
		partial void GeneratePasswordButton (Foundation.NSObject sender);

		[Action ("GeneratePasswordCopy:")]
		partial void GeneratePasswordCopy (Foundation.NSObject sender);

		[Action ("IncludeLowercaseInput:")]
		partial void IncludeLowercaseInput (Foundation.NSObject sender);

		[Action ("IncludeNumbersInput:")]
		partial void IncludeNumbersInput (Foundation.NSObject sender);

		[Action ("IncludeSymbolsInput:")]
		partial void IncludeSymbolsInput (Foundation.NSObject sender);

		[Action ("IncludeUppercaseInput:")]
		partial void IncludeUppercaseInput (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (PasswordLengthInput != null) {
				PasswordLengthInput.Dispose ();
				PasswordLengthInput = null;
			}

			if (GeneratePasswordOutput != null) {
				GeneratePasswordOutput.Dispose ();
				GeneratePasswordOutput = null;
			}
		}
	}
}