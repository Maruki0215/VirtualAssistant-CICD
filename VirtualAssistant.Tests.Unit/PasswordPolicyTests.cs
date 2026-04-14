namespace VirtualAssistant.Tests.Unit
{
    using NUnit.Framework;
    using VirtualAssistant.Services.Validators;

    /// <summary>
    /// Test class for password policy validation.
    /// </summary>
    [TestFixture]
    public class PasswordPolicyTests
    {
        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("TDD: Testing password policy validation");
        }

        /// <summary>
        /// Tests that a password shorter than 8 characters returns false.
        /// </summary>
        [Test]
        public void ValidatePassword_PasswordShorterThan8_ReturnsFalse()
        {
            string weakPassword = "short";
            TestContext.WriteLine($"\nTest 1: Password '{weakPassword}' (length: {weakPassword.Length})");

            bool result = PasswordValidator.ValidatePassword(weakPassword);

            TestContext.WriteLine($"Result: {result} (expected: False)");
            Assert.That(result, Is.False, "Password shorter than 8 characters should be rejected");
            TestContext.WriteLine("Test 1 passed\n");
        }

        /// <summary>
        /// Tests that an 8-character password without digits returns false.
        /// </summary>
        [Test]
        public void ValidatePassword_PasswordLength8ButNoDigit_ReturnsFalse()
        {
            string weakPassword = "NoDigitsX";
            TestContext.WriteLine($"\nTest 2: Password '{weakPassword}' (length: {weakPassword.Length})");

            bool result = PasswordValidator.ValidatePassword(weakPassword);

            TestContext.WriteLine($"Result: {result} (expected: False)");
            Assert.That(result, Is.False, "Password without digits should be rejected");
            TestContext.WriteLine("Test 2 passed\n");
        }

        /// <summary>
        /// Tests that a strong password with digit and sufficient length returns true.
        /// </summary>
        [Test]
        public void ValidatePassword_StrongPassword_ReturnsTrue()
        {
            string strongPassword = "StrongPass123";
            TestContext.WriteLine($"\nTest 3: Password '{strongPassword}' (length: {strongPassword.Length})");

            bool result = PasswordValidator.ValidatePassword(strongPassword);

            TestContext.WriteLine($"Result: {result} (expected: True)");
            Assert.That(result, Is.True, "Strong password should be accepted");
            TestContext.WriteLine("Test 3 passed\n");
        }

        /// <summary>
        /// Tests that a null password returns false.
        /// </summary>
        [Test]
        public void ValidatePassword_NullPassword_ReturnsFalse()
        {
            string? nullPassword = null;
            TestContext.WriteLine("\nTest 4: Password = null");

            bool result = PasswordValidator.ValidatePassword(nullPassword!);

            TestContext.WriteLine($"Result: {result} (expected: False)");
            Assert.That(result, Is.False, "Null password should be rejected");
            TestContext.WriteLine("Test 4 passed\n");
        }

        /// <summary>
        /// Tests that an empty password returns false.
        /// </summary>
        [Test]
        public void ValidatePassword_EmptyPassword_ReturnsFalse()
        {
            string emptyPassword = string.Empty;
            TestContext.WriteLine("\nTest 5: Password = empty string");

            bool result = PasswordValidator.ValidatePassword(emptyPassword);

            TestContext.WriteLine($"Result: {result} (expected: False)");
            Assert.That(result, Is.False, "Empty password should be rejected");
            TestContext.WriteLine("Test 5 passed\n");
        }

        /// <summary>
        /// Tests that a password with digit but insufficient length returns false.
        /// </summary>
        [Test]
        public void ValidatePassword_ShortPasswordWithDigit_ReturnsFalse()
        {
            string weakPassword = "Short1";
            TestContext.WriteLine($"\nTest 6: Password '{weakPassword}' (length: {weakPassword.Length})");

            bool result = PasswordValidator.ValidatePassword(weakPassword);

            TestContext.WriteLine($"Result: {result} (expected: False)");
            Assert.That(result, Is.False, "Short password even with digit should be rejected");
            TestContext.WriteLine("Test 6 passed\n");
        }
    }
}