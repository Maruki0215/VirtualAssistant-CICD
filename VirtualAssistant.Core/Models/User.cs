namespace VirtualAssistant.Core.Models
{
    /// <summary>
    /// Represents a user in the virtual assistant system.
    /// </summary>
    public class User
    {
        private readonly string username;
        private readonly string password;
        private readonly string email;
        private string role;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="email">The email address of the user.</param>
        public User(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.role = "User";
        }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username
        {
            get { return this.username; }
        }

        /// <summary>
        /// Gets the password hash of the user.
        /// </summary>
        public string Password
        {
            get { return this.password; }
        }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email
        {
            get { return this.email; }
        }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public string Role
        {
            get { return this.role; }
            set { this.role = value; }
        }

        /// <summary>
        /// Validates user credentials.
        /// </summary>
        /// <param name="inputUsername">The username to validate.</param>
        /// <param name="inputPassword">The password to validate.</param>
        /// <returns>True if credentials are valid, otherwise false.</returns>
        public bool ValidateUser(string inputUsername, string inputPassword)
        {
            if (inputUsername is null || inputPassword is null)
            {
                return false;
            }

            return this.username == inputUsername && this.password == inputPassword;
        }

        /// <summary>
        /// Checks if the user's password is strong.
        /// </summary>
        /// <returns>True if password is strong, otherwise false.</returns>
        public bool IsStrongPassword()
        {
            const int minPasswordLength = 8;

            if (this.password.Length < minPasswordLength)
            {
                return false;
            }

            bool hasDigit = false;
            for (int i = 0; i < this.password.Length; i++)
            {
                if (char.IsDigit(this.password[i]))
                {
                    hasDigit = true;
                    break;
                }
            }

            return hasDigit;
        }
    }
}