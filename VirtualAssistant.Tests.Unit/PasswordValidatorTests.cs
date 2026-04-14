namespace VirtualAssistant.Tests.Unit
{
    using NUnit.Framework;
    using VirtualAssistant.Services.Validators;

    [TestFixture]
    public class PasswordValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("PasswordValidator Tests Started");
        }

        [Test]
        public void ValidatePassword_NullInput_ReturnsFalse()
        {
            bool result = PasswordValidator.ValidatePassword(null);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidatePassword_EmptyInput_ReturnsFalse()
        {
            bool result = PasswordValidator.ValidatePassword("");
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidatePassword_ShortPassword_ReturnsFalse()
        {
            bool result = PasswordValidator.ValidatePassword("Ab1");
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidatePassword_NoDigit_ReturnsFalse()
        {
            bool result = PasswordValidator.ValidatePassword("NoDigitsHere");
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidatePassword_NoUpper_ReturnsFalse()
        {
            bool result = PasswordValidator.ValidatePassword("nouppercase123");
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidatePassword_NoLower_ReturnsFalse()
        {
            bool result = PasswordValidator.ValidatePassword("NOLOWERCASE123");
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidatePassword_ValidPassword_ReturnsTrue()
        {
            bool result = PasswordValidator.ValidatePassword("ValidPass123");
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidatePassword_ExactMinLength_ReturnsTrue()
        {
            bool result = PasswordValidator.ValidatePassword("Exact8L1");
            Assert.That(result, Is.True);
        }
    }
}