using System;

namespace CharterUsers.Model
{
    public class User
    {
        public User()
        {
        }
        public User(string first, string last, string username, string pwd)
        {
            this.FirstName = first;
            this.LastName = last;
            this.UserName = username;
            this.Password = pwd;
        }


        /// <summary>
        /// Gets or sets the name of the FirstName.
        /// </summary>
        /// <value>The FirstName.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the LastName.
        /// </summary>
        /// <value>The LastName.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the UserName.
		/// </summary>
        /// <value>The UserName.</value>
		public string UserName { get; set; }


        /// <summary>
        /// Gets or sets Password
        /// </summary>
        /// <value>The Password.</value>
        public string Password { get; set; }

       
    }
}
