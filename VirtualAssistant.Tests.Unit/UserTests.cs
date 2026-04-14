namespace VirtualAssistant.Tests.Unit
{
    using NUnit.Framework;
    using VirtualAssistant.Core.Models;

    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_ValidParameters_CreatesUser()
        {
            User user = new User("testuser", "password123", "test@test.com");
            
            Assert.That(user.Username, Is.EqualTo("testuser"));
            Assert.That(user.Password, Is.EqualTo("password123"));
            Assert.That(user.Email, Is.EqualTo("test@test.com"));
            Assert.That(user.Role, Is.EqualTo("User"));
        }

        [Test]
        public void ValidateUser_CorrectCredentials_ReturnsTrue()
        {
            User user = new User("testuser", "password123", "test@test.com");
            
            bool result = user.ValidateUser("testuser", "password123");
            
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateUser_WrongPassword_ReturnsFalse()
        {
            User user = new User("testuser", "password123", "test@test.com");
            
            bool result = user.ValidateUser("testuser", "wrongpassword");
            
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateUser_WrongUsername_ReturnsFalse()
        {
            User user = new User("testuser", "password123", "test@test.com");
            
            bool result = user.ValidateUser("wronguser", "password123");
            
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateUser_NullUsername_ReturnsFalse()
        {
            User user = new User("testuser", "password123", "test@test.com");
            
            bool result = user.ValidateUser(null, "password123");
            
            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateUser_NullPassword_ReturnsFalse()
        {
            User user = new User("testuser", "password123", "test@test.com");
            
            bool result = user.ValidateUser("testuser", null);
            
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsStrongPassword_WeakPassword_ReturnsFalse()
        {
            User user = new User("testuser", "weak", "test@test.com");
            
            bool result = user.IsStrongPassword();
            
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsStrongPassword_StrongPassword_ReturnsTrue()
        {
            User user = new User("testuser", "StrongPass123", "test@test.com");
            
            bool result = user.IsStrongPassword();
            
            Assert.That(result, Is.True);
        }

        [Test]
        public void Role_SetAndGet_WorksCorrectly()
        {
            User user = new User("testuser", "pass123", "test@test.com");
            
            user.Role = "Admin";
            
            Assert.That(user.Role, Is.EqualTo("Admin"));
        }
    }
}