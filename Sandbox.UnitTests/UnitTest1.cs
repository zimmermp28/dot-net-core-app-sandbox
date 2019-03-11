using Microsoft.AspNetCore.Mvc;
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
            _homeController = new HomeController();
        }

        [Test]
        public void Should_set_title_to_sandbox_for_the_homepage()
        {
            var viewResult = _homeController.Index() as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            var homeViewModel = (HomeViewModel) viewResult.Model;
            Assert.That(homeViewModel.Title, Is.EqualTo("Sandbox"));
        }
    }
}