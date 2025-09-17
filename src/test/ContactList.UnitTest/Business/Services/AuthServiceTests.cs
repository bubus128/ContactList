using ContactList.Business.Services;
using ContactList.Business.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using FakeItEasy;
using Microsoft.AspNetCore.Http;

namespace ContactList.UnitTest.Business.Services;

public class AuthServiceTests
{
    private UserManager<IdentityUser> _userManager;
    private SignInManager<IdentityUser> _signInManager;
    private ILogger<AuthService> _logger;
    private IAuthService _authService;

    [SetUp]
    public void Setup()
    {
        _userManager = A.Fake<UserManager<IdentityUser>>(
            options => options.WithArgumentsForConstructor(() =>
                new UserManager<IdentityUser>(
                    A.Fake<IUserStore<IdentityUser>>(),
                    null, null, null, null, null, null, null, null)));

        _signInManager = A.Fake<SignInManager<IdentityUser>>(
            options => options.WithArgumentsForConstructor(() =>
                new SignInManager<IdentityUser>(
                    _userManager,
                    A.Fake<IHttpContextAccessor>(),
                    A.Fake<IUserClaimsPrincipalFactory<IdentityUser>>(),
                    null, null, null)));

        _logger = A.Fake<ILogger<AuthService>>();
        _authService = new AuthService(_userManager, _signInManager, _logger);
    }

    [TearDown]
    public void Teardown()
    {
        _userManager?.Dispose();
    }

    [TestCase("", "password", false, "Email and password are required")]
    [TestCase("test@test.com", "", false, "Email and password are required")]
    public async Task RegisterAsync_InvalidInput_ReturnsError(string email, string password, bool expectedSuccess, string expectedMessage)
    {
        var result = await _authService.RegisterAsync(email, password);

        Assert.That(result.Success, Is.EqualTo(expectedSuccess));
        Assert.That(result.Message, Is.EqualTo(expectedMessage));
    }

    [Test]
    public async Task RegisterAsync_UserCreationFails_ReturnsErrors()
    {
        var identityResult = IdentityResult.Failed(new IdentityError { Description = "Weak password" });
        A.CallTo(() => _userManager.CreateAsync(A<IdentityUser>._, A<string>._))
            .Returns(Task.FromResult(identityResult));

        var result = await _authService.RegisterAsync("test@test.com", "password");

        Assert.That(result.Success, Is.False);
        Assert.That(result.Message, Does.Contain("Weak password"));
    }

    [Test]
    public async Task RegisterAsync_Success_ReturnsSuccessMessage()
    {
        A.CallTo(() => _userManager.CreateAsync(A<IdentityUser>._, A<string>._))
            .Returns(Task.FromResult(IdentityResult.Success));

        var result = await _authService.RegisterAsync("test@test.com", "password");

        Assert.That(result.Success, Is.True);
        Assert.That(result.Message, Is.EqualTo("Registration successful"));
    }

    [TestCase("", "password", false, "Email and password are required")]
    [TestCase("test@test.com", "", false, "Email and password are required")]
    public async Task LoginAsync_InvalidInput_ReturnsError(string email, string password, bool expectedSuccess, string expectedMessage)
    {
        var result = await _authService.LoginAsync(email, password);

        Assert.That(result.Success, Is.EqualTo(expectedSuccess));
        Assert.That(result.Message, Is.EqualTo(expectedMessage));
    }

    [Test]
    public async Task LoginAsync_InvalidCredentials_ReturnsError()
    {
        A.CallTo(() => _signInManager.PasswordSignInAsync("test@test.com", "wrong", false, false))
            .Returns(Task.FromResult(SignInResult.Failed));

        var result = await _authService.LoginAsync("test@test.com", "wrong");

        Assert.That(result.Success, Is.False);
        Assert.That(result.Message, Is.EqualTo("Invalid email or password"));
    }

    [Test]
    public async Task LoginAsync_Success_ReturnsSuccessMessage()
    {
        A.CallTo(() => _signInManager.PasswordSignInAsync("test@test.com", "password", false, false))
            .Returns(Task.FromResult(SignInResult.Success));

        var result = await _authService.LoginAsync("test@test.com", "password");

        Assert.That(result.Success, Is.True);
        Assert.That(result.Message, Is.EqualTo("Login successful"));
    }
}