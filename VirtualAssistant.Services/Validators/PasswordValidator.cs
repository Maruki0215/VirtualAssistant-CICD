namespace VirtualAssistant.Services.Validators
{
    using System;
    using System.Linq;

    public static class PasswordValidator
    {
        private const int MinPasswordLength = 8;

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