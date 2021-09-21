// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CharterUsers
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.UIButton addUserButton { get; set; }

		[Outlet]
		UIKit.UILabel errorMessageLabel { get; set; }

		[Outlet]
		UIKit.UITextField firstNameField { get; set; }

		[Outlet]
		UIKit.UITextField lastNameField { get; set; }

		[Outlet]
		UIKit.UITextField passwordField { get; set; }

		[Outlet]
		UIKit.UITextField usernameField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (addUserButton != null) {
				addUserButton.Dispose ();
				addUserButton = null;
			}

			if (firstNameField != null) {
				firstNameField.Dispose ();
				firstNameField = null;
			}

			if (lastNameField != null) {
				lastNameField.Dispose ();
				lastNameField = null;
			}

			if (passwordField != null) {
				passwordField.Dispose ();
				passwordField = null;
			}

			if (usernameField != null) {
				usernameField.Dispose ();
				usernameField = null;
			}

			if (errorMessageLabel != null) {
				errorMessageLabel.Dispose ();
				errorMessageLabel = null;
			}
		}
	}
}
