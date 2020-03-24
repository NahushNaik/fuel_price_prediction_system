using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LoginInMVC4WithEF.Controllers;
using LoginInMVC4WithEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFuelProject
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void UsernameAndPassword_Valid_ReturnsTrue()
        {

        }

        [TestMethod]
        public void UsernameAndPassword_Invalid_ReturnsFalse()
        {
        }

        [TestMethod]
        public void UsernameAndPassword_Blank_ReturnsFalse()
        {
        }

        [TestMethod]
        public void Password_Astrisk_ReturnsTrue()
        {
        }
    }

    [TestClass]
    public class RegistrationTests
    {
        [TestMethod]
        public void PasswordLength_LessThan8_ReturnsFalse()
        {
        }

        [TestMethod]
        public void PasswordLength_GreaterThan16_ReturnsFalse()
        {
        }

        [TestMethod]
        public void PasswordLength_GreaterThan7LessThan17_ReturnsTrue()
        {

        }

        [TestMethod]
        public void Password_IsValid_ReturnsTrue()
        {
        }

        [TestMethod]
        public void Password_IsBlank_ReturnsFalse()
        {
        }

        [TestMethod]
        public void Username_IsValid_ReturnsTrue()
        {
        }

        [TestMethod]
        public void Username_IsBlank_ReturnsFalse()
        {
        }
    }
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }

    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Index()
        {
            UserController controller = new UserController();
            ViewResult result1 = controller.Index() as ViewResult;
            ViewResult result2 = controller.LogIn() as ViewResult;
            ViewResult result3 = controller.Register() as ViewResult;
            ViewResult result4 = controller.ClientProfile() as ViewResult;
            ViewResult result5 = controller.FuelQuoteHistory() as ViewResult;
            ViewResult result6 = controller.FuelQuoteForm() as ViewResult;

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.IsNotNull(result3);
            Assert.IsNotNull(result4);
            Assert.IsNotNull(result5);
            Assert.IsNotNull(result6);
        }
    }

    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void Index()
        {
            List<Registration> Login()
            {
                return new List<Registration>{
                                    new Registration{
                                                UserId = 1,
                                                UserName = "govindmaheshwari07",
                                                Password = "abc123",
                                                FullName = "Govind Rander",
                                                Address1 = "4047 Linkwood Drive",
                                                Address2 = "742",
                                                City = "Houston",
                                                State = "Texas",
                                                PinCode = "77025",
                                                IsActive = true,
                                                //CreatedBy = "",
                                                //CreatedDate = DateTime.Parse(DateTime.Today.ToString()),
                                                //ModifiedBy = "",
                                                //ModifiedDate = DateTime.Parse(DateTime.Today.ToString()),
                                            },
                                };
            }
            List<Registration>  reg = Login();
            LoginTestController controller = new LoginTestController();
            ViewResult result = controller.LoginTest() as ViewResult;
            var redirectResult = controller.LogInTest(reg[0]) as RedirectToRouteResult;
            //RedirectResult redirectResult = (RedirectResult)controller.LogInTest(reg[0]) as RedirectResult;
            Assert.IsNotNull(result);
            //Assert.AreEqual(redirectResult.Url, "/User/ClientProfile");
            Assert.AreEqual("ClientProfile", redirectResult.RouteValues["action"]);
            Assert.AreEqual("User", redirectResult.RouteValues["controller"]);
        }
    }
}