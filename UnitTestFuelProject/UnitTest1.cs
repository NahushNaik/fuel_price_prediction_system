using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LoginInMVC4WithEF.Controllers;
using LoginInMVC4WithEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;

namespace UnitTestFuelProject
{
    
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
    public class FuelProjectControllerTest
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
                                                GallonsRequested = 50,
                                                SuggestedPrice = 5000,
                                                DeliveryDate = DateTime.Parse("2020-04-03")
                                                //CreatedBy = "",
                                                //CreatedDate = DateTime.Parse(DateTime.Today.ToString()),
                                                //ModifiedBy = "",
                                                //ModifiedDate = DateTime.Parse(DateTime.Today.ToString()),
                                            },
                                            new Registration{
                                                UserId = 2,
                                                UserName = "nahushmnaik",
                                                Password = "abcd1234",
                                                FullName = "Nahush Naik",
                                                Address1 = "4045 Linkwood Drive",
                                                Address2 = "641",
                                                City = "Houston",
                                                State = "Texas",
                                                PinCode = "77025",
                                                IsActive = true,
                                                GallonsRequested = 55,
                                                SuggestedPrice = 4000,
                                                DeliveryDate = DateTime.Parse("2020-04-02")
                                                //CreatedBy = "",
                                                //CreatedDate = DateTime.Parse(DateTime.Today.ToString()),
                                                //ModifiedBy = "",
                                                //ModifiedDate = DateTime.Parse(DateTime.Today.ToString()),
                                            }
                                };
            }
            List<Registration> reg = Login();
            FuelProjectController controller = new FuelProjectController();
            ViewResult result = controller.LoginTest() as ViewResult;

            var redirectResult1 = controller.LogInTest(reg[0]) as RedirectToRouteResult;

            var redirectResult2 = controller.ClientProfileTest(reg[0]) as RedirectToRouteResult;

            var redirectResult3 = controller.LogInTest(reg[1]) as RedirectToRouteResult;

            var redirectResult4 = controller.ClientProfileTest(reg[1]) as RedirectToRouteResult;

            var redirectResult5 = controller.FuelQuoteForm(reg[0]) as RedirectToRouteResult;

            var redirectResult6 = controller.FuelQuoteForm(reg[1]) as RedirectToRouteResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("ClientProfile", redirectResult1.RouteValues["action"]);
            Assert.AreEqual("User", redirectResult1.RouteValues["controller"]);

            Assert.AreEqual("FuelQuoteForm", redirectResult2.RouteValues["action"]);
            Assert.AreEqual("User", redirectResult2.RouteValues["controller"]);

            Assert.IsNull(redirectResult3);
            Assert.IsNull(redirectResult3);

            Assert.IsNull(redirectResult4);
            Assert.IsNull(redirectResult4);

            Assert.AreEqual("FuelQuoteHistory", redirectResult5.RouteValues["action"]);
            Assert.AreEqual("User", redirectResult5.RouteValues["controller"]);

            Assert.IsNull(redirectResult6);
            Assert.IsNull(redirectResult6);

        }
    }
}