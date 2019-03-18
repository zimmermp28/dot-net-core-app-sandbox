using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Sandbox.Controllers;
using Sandbox.Models;

namespace Sandbox.UnitTests
{
    public class HomeControllerTests
    {
        private HomeController _homeController;

        [SetUp]
        public void Setup()
        {
            var mockConfig = new Mock<IOptions<ReleaseOptions>>();
            mockConfig.Setup(x => x.Value).Returns(new ReleaseOptions {Version = "some version"});
            _homeController = new HomeController(mockConfig.Object);
        }

        [Test]
        public void Should_set_title_to_sandbox_for_the_homepage()
        {
            var viewResult = _homeController.Index() as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            var homeViewModel = (HomeViewModel) viewResult.Model;
            Assert.That(homeViewModel.Title, Is.EqualTo("Sandbox"));
        }

        [Test]
        public void Should_set_release_version_for_the_homepage()
        {
            var viewResult = _homeController.Index() as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            var homeViewModel = (HomeViewModel)viewResult.Model;
            Assert.That(homeViewModel.Release, Is.EqualTo("some version"));
        }
    }
}