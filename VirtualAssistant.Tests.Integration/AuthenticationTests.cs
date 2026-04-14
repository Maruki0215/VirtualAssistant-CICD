using NUnit.Framework;
using VirtualAssistant.Services.Services;

namespace VirtualAssistant.Tests.Integration
{
    /// <summary>
    /// Integration tests for AuthenticationService.
    /// </summary>
    [TestFixture]
    public class AuthenticationTests
    {
        private AuthenticationService? authService;

        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            authService = new AuthenticationService();
            TestContext.WriteLine("Integration tests started");
        }

        /// <summary>
        /// Tests that admin can login successfully.
        /// </summary>
        [Test]
        public void Login_AdminCredentials_ReturnsTrue()
        {
            // Arrange
            string username = "admin";
            string password = "admin123";

            // Act
            bool result = authService!.Login(username, password);

            // Assert
            Assert.That(result, Is.True, "Admin should be able to login");
            TestContext.WriteLine($"Admin login test: {result}");
        }

        /// <summary>
        /// Tests that regular user can login successfully.
        /// </summary>
        [Test]
        public void Login_UserCredentials_ReturnsTrue()
        {
            // Arrange
            string username = "user";
            string password = "user123";

            // Act
            bool result = authService!.Login(username, password);

            // Assert
            Assert.That(result, Is.True, "User should be able to login");
            TestContext.WriteLine($"User login test: {result}");
        }

        /// <summary>
        /// Tests that login with invalid credentials returns false.
        /// </summary>
        [Test]
        public void Login_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            string username = "fakeuser";
            string password = "fakepass";

            // Act
            bool result = authService!.Login(username, password);

            // Assert
            Assert.That(result, Is.False, "Invalid credentials should not login");
            TestContext.WriteLine($"Invalid login test: {result}");
        }

        /// <summary>
        /// Tests that user registration works.
        /// </summary>
        [Test]
        public void RegisterUser_NewUser_ReturnsTrue()
        {
            // Arrange
            string username = "newuser_" + DateTime.Now.Ticks;
            string password = "newpass123";
            string email = $"{username}@test.com";

            // Act
            bool result = authService!.RegisterUser(username, password, email);

            // Assert
            Assert.That(result, Is.True, "New user should be registered");
            TestContext.WriteLine($"Registration test for {username}: {result}");
        }

        /// <summary>
        /// Tests that duplicate user registration fails.
        /// </summary>
        [Test]
        public void RegisterUser_DuplicateUser_ReturnsFalse()
        {
            // Arrange
            string username = "admin";
            string password = "admin123";
            string email = "admin@test.com";

            // Act
            bool result = authService!.RegisterUser(username, password, email);

            // Assert
            Assert.That(result, Is.False, "Duplicate user should not be registered");
            TestContext.WriteLine($"Duplicate registration test: {result}");
        }

        /// <summary>
        /// Tests that registered user can login.
        /// </summary>
        [Test]
        public void Login_AfterRegistration_ReturnsTrue()
        {
            // Arrange
            string username = "reguser_" + DateTime.Now.Ticks;
            string password = "regpass123";
            string email = $"{username}@test.com";
            
            authService!.RegisterUser(username, password, email);

            // Act
            bool result = authService.Login(username, password);

            // Assert
            Assert.That(result, Is.True, "Registered user should be able to login");
            TestContext.WriteLine($"Login after registration test: {result}");
        }

        /// <summary>
        /// Tests logout functionality.
        /// </summary>
        [Test]
        public void Logout_AfterLogin_CurrentUserIsNull()
        {
            // Arrange
            authService!.Login("admin", "admin123");

            // Act
            authService.Logout();
            var currentUser = authService.GetCurrentUser();

            // Assert
            Assert.That(currentUser, Is.Null, "After logout, current user should be null");
            TestContext.WriteLine("Logout test passed");
        }

        /// <summary>
        /// Tests CheckUserExists returns true for existing user.
        /// </summary>
        [Test]
        public void CheckUserExists_ExistingUser_ReturnsTrue()
        {
            // Arrange & Act
            bool exists = authService!.CheckUserExists("admin");

            // Assert
            Assert.That(exists, Is.True, "Existing user should be found");
            TestContext.WriteLine($"CheckUserExists test: {exists}");
        }

        /// <summary>
        /// Tests CheckUserExists returns false for non-existing user.
        /// </summary>
        [Test]
        public void CheckUserExists_NonExistingUser_ReturnsFalse()
        {
            // Arrange & Act
            bool exists = authService!.CheckUserExists("nonexistent12345");

            // Assert
            Assert.That(exists, Is.False, "Non-existing user should not be found");
            TestContext.WriteLine($"CheckUserExists (non-existing) test: {exists}");
        }
    }
}