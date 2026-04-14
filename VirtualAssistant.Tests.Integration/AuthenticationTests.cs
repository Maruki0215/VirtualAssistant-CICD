namespace VirtualAssistant.Tests.Integration
{
    using System;
    using NUnit.Framework;
    using VirtualAssistant.Core.Models;
    using VirtualAssistant.Services.Services;

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
            this.authService = new AuthenticationService();
            TestContext.WriteLine("Integration tests started");
        }

        /// <summary>
        /// Tests that admin can login successfully.
        /// </summary>
        [Test]
        public void Login_AdminCredentials_ReturnsTrue()
        {
            string username = "admin";
            string password = "admin123";

            bool result = this.authService!.Login(username, password);

            Assert.That(result, Is.True, "Admin should be able to login");
            TestContext.WriteLine($"Admin login test: {result}");
        }

        /// <summary>
        /// Tests that regular user can login successfully.
        /// </summary>
        [Test]
        public void Login_UserCredentials_ReturnsTrue()
        {
            string username = "user";
            string password = "user123";

            bool result = this.authService!.Login(username, password);

            Assert.That(result, Is.True, "User should be able to login");
            TestContext.WriteLine($"User login test: {result}");
        }

        /// <summary>
        /// Tests that login with invalid credentials returns false.
        /// </summary>
        [Test]
        public void Login_InvalidCredentials_ReturnsFalse()
        {
            string username = "fakeuser";
            string password = "fakepass";

            bool result = this.authService!.Login(username, password);

            Assert.That(result, Is.False, "Invalid credentials should not login");
            TestContext.WriteLine($"Invalid login test: {result}");
        }

        /// <summary>
        /// Tests that user registration works.
        /// </summary>
        [Test]
        public void RegisterUser_NewUser_ReturnsTrue()
        {
            string username = "newuser_" + DateTime.Now.Ticks;
            string password = "newpass123";
            string email = $"{username}@test.com";

            bool result = this.authService!.RegisterUser(username, password, email);

            Assert.That(result, Is.True, "New user should be registered");
            TestContext.WriteLine($"Registration test for {username}: {result}");
        }

        /// <summary>
        /// Tests that duplicate user registration fails.
        /// </summary>
        [Test]
        public void RegisterUser_DuplicateUser_ReturnsFalse()
        {
            string username = "admin";
            string password = "admin123";
            string email = "admin@test.com";

            bool result = this.authService!.RegisterUser(username, password, email);

            Assert.That(result, Is.False, "Duplicate user should not be registered");
            TestContext.WriteLine($"Duplicate registration test: {result}");
        }

        /// <summary>
        /// Tests that registered user can login.
        /// </summary>
        [Test]
        public void Login_AfterRegistration_ReturnsTrue()
        {
            string username = "reguser_" + DateTime.Now.Ticks;
            string password = "regpass123";
            string email = $"{username}@test.com";

            this.authService!.RegisterUser(username, password, email);

            bool result = this.authService.Login(username, password);

            Assert.That(result, Is.True, "Registered user should be able to login");
            TestContext.WriteLine($"Login after registration test: {result}");
        }

        /// <summary>
        /// Tests logout functionality.
        /// </summary>
        [Test]
        public void Logout_AfterLogin_CurrentUserIsNull()
        {
            this.authService!.Login("admin", "admin123");

            this.authService.Logout();
            User? currentUser = this.authService.GetCurrentUser();

            Assert.That(currentUser, Is.Null, "After logout, current user should be null");
            TestContext.WriteLine("Logout test passed");
        }

        /// <summary>
        /// Tests CheckUserExists returns true for existing user.
        /// </summary>
        [Test]
        public void CheckUserExists_ExistingUser_ReturnsTrue()
        {
            bool exists = this.authService!.CheckUserExists("admin");

            Assert.That(exists, Is.True, "Existing user should be found");
            TestContext.WriteLine($"CheckUserExists test: {exists}");
        }

        /// <summary>
        /// Tests CheckUserExists returns false for non-existing user.
        /// </summary>
        [Test]
        public void CheckUserExists_NonExistingUser_ReturnsFalse()
        {
            bool exists = this.authService!.CheckUserExists("nonexistent12345");

            Assert.That(exists, Is.False, "Non-existing user should not be found");
            TestContext.WriteLine($"CheckUserExists (non-existing) test: {exists}");
        }
    }
}