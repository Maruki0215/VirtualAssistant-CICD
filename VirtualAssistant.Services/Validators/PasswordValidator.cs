namespace VirtualAssistant.Services.Validators
{
    using System;
    using System.Linq;

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
        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (!CheckLength(password))
            {
                return false;
            }

            if (!CheckHasDigit(password))
            {
                return false;
            }

            if (!CheckHasUpper(password))
            {
                return false;
            }

            if (!CheckHasLower(password))
            {
                return false;
            }

            return true;
        }

        private static bool CheckLength(string password)
        {
            return password.Length >= MinPasswordLength;
        }

        private static bool CheckHasDigit(string password)
        {
            return password.Any(char.IsDigit);
        }

        private static bool CheckHasUpper(string password)
        {
            return password.Any(char.IsUpper);
        }

        private static bool CheckHasLower(string password)
        {
            return password.Any(char.IsLower);
        }
    }
}