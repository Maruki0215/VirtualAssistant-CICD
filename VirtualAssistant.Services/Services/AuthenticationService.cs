using System;
using System.Collections.Generic;
using System.Linq;
using VirtualAssistant.Core.Models;

namespace VirtualAssistant.Services.Services
{
    /// <summary>
    /// Provides authentication services for the virtual assistant.
    /// </summary>
    public class AuthenticationService
    {
        private readonly List<User> users;
        private User? currentUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        public AuthenticationService()
        {
            this.users = new List<User>();
            this.InitializeDefaultUsers();
        }

        private void InitializeDefaultUsers()
        {
            var admin = new User("admin", "admin123", "admin@test.com");
            admin.Role = "Admin";
            this.users.Add(admin);

            var regularUser = new User("user", "user123", "user@test.com");
            this.users.Add(regularUser);

            var testUser = new User("test", "test123", "test@test.com");
            this.users.Add(testUser);

            var demoUser = new User("demo", "demo123", "demo@test.com");
            this.users.Add(demoUser);
        }

        /// <summary>
        /// Logs in a user with the specified credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>True if login is successful, otherwise false.</returns>
        public bool Login(string username, string password)
        {
            if (username is null || password is null)
            {
                return false;
            }

            var user = this.users.FirstOrDefault(u => u.Username == username);

            if (user is not null && user.Password == password)
            {
                this.currentUser = user;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the count of users divided by a specified divisor.
        /// </summary>
        /// <param name="divider">The divisor.</param>
        /// <returns>The result of division, or -1 if division by zero.</returns>
        public int GetUserCountDivider(int divider)
        {
            if (divider == 0)
            {
                return -1;
            }

            return this.users.Count / divider;
        }

        /// <summary>
        /// Checks if a user exists in the system.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if user exists, otherwise false.</returns>
        public bool CheckUserExists(string username)
        {
            for (int i = 0; i < this.users.Count; i++)
            {
                if (this.users[i].Username == username)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Calculates user statistics.
        /// </summary>
        /// <returns>The calculated statistics value.</returns>
        public double CalculateUserStats()
        {
            const double pi = 3.14159;
            const double e = 2.71828;

            if (this.users.Count == 0)
            {
                return 0;
            }

            double total = 0;
            for (int i = 0; i < this.users.Count; i++)
            {
                total += this.users[i].Username.Length * pi;
            }

            double average = total / this.users.Count;
            return average * e;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The email address.</param>
        /// <returns>True if registration is successful, otherwise false.</returns>
        public bool RegisterUser(string username, string password, string email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                return false;
            }

            if (this.users.Any(u => u.Username == username))
            {
                return false;
            }

            var newUser = new User(username, password, email);
            this.users.Add(newUser);
            return true;
        }

        /// <summary>
        /// Gets the currently logged-in user.
        /// </summary>
        /// <returns>The current user, or null if no user is logged in.</returns>
        public User? GetCurrentUser()
        {
            return this.currentUser;
        }

        /// <summary>
        /// Logs out the current user.
        /// </summary>
        public void Logout()
        {
            this.currentUser = null;
        }
    }
}