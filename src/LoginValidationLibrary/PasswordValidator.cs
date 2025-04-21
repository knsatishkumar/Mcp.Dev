using System;
using System.Text.RegularExpressions;

namespace LoginValidationLibrary
{
    public class PasswordValidator
    {
        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            // Minimum 12 characters
            if (password.Length < 12)
                return false;

            // At least one uppercase letter
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // At least one lowercase letter
            if (!Regex.IsMatch(password, "[a-z]"))
                return false;

            // At least one digit
            if (!Regex.IsMatch(password, "[0-9]"))
                return false;

            // At least one special character
            if (!Regex.IsMatch(password, "[^a-zA-Z0-9]"))
                return false;

            return true;
        }
    }
}