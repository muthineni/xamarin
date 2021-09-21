using System;
using UIKit;
using Foundation;
using CharterUsers.Utilities;
using CharterUsers.Model;
namespace CharterUsers
{
    public partial class DetailViewController : UIViewController
    {
        public User UserDetails { get; set; }
        public int EditingIndex { get; set; }

        public DetailViewController(IntPtr handle) : base(handle)
        {
        }

    
        void AddUserAction(object sender, EventArgs args)
        {
            var errorMessage = "";
            //empty fields validation
            if (StringValidator.isStringEmpty(this.usernameField.Text) ||
                StringValidator.isStringEmpty(this.firstNameField.Text) ||
                StringValidator.isStringEmpty(this.lastNameField.Text) ||
                StringValidator.isStringEmpty(this.passwordField.Text))
            {
                this.errorMessageLabel.Text = "Please enter all fields.";
                this.errorMessageLabel.Hidden = false;
                return;
            }

            //Password rules validation
            if(!StringValidator.isValidPassword(this.passwordField.Text, out errorMessage))
            {
                this.errorMessageLabel.Text = errorMessage;
                this.errorMessageLabel.Hidden = false;
                return;
            }

            this.errorMessageLabel.Hidden = true;

            //Save the user.
            var user = new User(first: this.firstNameField.Text, last: this.lastNameField.Text, username: this.usernameField.Text, pwd: this.passwordField.Text);
            DataManager.Instance.SaveUser(user,this.EditingIndex);
            this.NavigationController.PopViewController(false);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            addUserButton.TouchUpInside += AddUserAction;
            this.Title = "Add User";
            this.errorMessageLabel.Hidden = true;

            this.firstNameField.Text = this.UserDetails?.FirstName;
            this.lastNameField.Text = this.UserDetails?.LastName;
            this.usernameField.Text = this.UserDetails?.UserName;
            this.passwordField.Text = this.UserDetails?.Password;

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


