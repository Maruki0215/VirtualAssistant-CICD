using System;
using System.Linq;

namespace VirtualAssistant.Services.Validators
{
    /// <summary>
    /// Validates passwords according to security policies.
    /// </summary>
    public class PasswordValidator
    {
        private const int MinPasswordLength = 8;

        /// <summary>
        /// Validates a password against security policies.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>True if the password meets all requirements, otherwise false.</returns>
        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return this.CheckLength(password) &&
                   this.CheckHasDigit(password) &&
                   this.CheckHasUpper(password) &&
                   this.CheckHasLower(password);
        }

        private bool CheckLength(string password)
        {
            return password.Length >= MinPasswordLength;
        }

        private bool CheckHasDigit(string password)
        {
            return password.Any(char.IsDigit);
        }

        private bool CheckHasUpper(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool CheckHasLower(string password)
        {
            return password.Any(char.IsLower);
        }
    }
}