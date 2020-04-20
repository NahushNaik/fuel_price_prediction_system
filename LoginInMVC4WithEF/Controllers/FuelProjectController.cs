using LoginInMVC4WithEF.Models;
using ProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginInMVC4WithEF.Controllers
{
    public class FuelProjectController : Controller
    {

        public List<User> LoginUser()
        {
            return new List<User>{
                                    new User{
                                                UserId = 1,
                                                LoginId = "govindmaheshwari07",
                                                Password = "abc123",
                                                FullName = "Govind Rander",
                                                Address1 = "4047 Linkwood Drive",
                                                Address2 = "742",
                                                City = "Houston",
                                                State = "Texas",
                                                ZipCode = "77025",
                                                IsActive = true,                              
                                                //CreatedBy = "",
                                                //CreatedDate = DateTime.Parse(DateTime.Today.ToString()),
                                                //ModifiedBy = "",
                                                //ModifiedDate = DateTime.Parse(DateTime.Today.ToString()),
                                            },
                                };
        }
        public List<FuelQuoteForm> FuelQuoteFormUser()
        {
            return new List<FuelQuoteForm>{
                                    new FuelQuoteForm{
                                                GallonsRequested = 50,
                                                SuggestedPrice = 5000,
                                                //DeliveryDate = DateTime.Parse("2020-04-03")
                                                DeliveryDate = "2020-04-03"
                                            },
                                };
        }
        //
        // GET: /LoginTest/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginTest()
        {
            //var employees = from e in Login()
            //                orderby e.UserId
            //                select e;
            //LoginTestController l = new LoginTestController();
            //List<Registration> intList = l.Login();
            //l.LogInTest(intList[0]);
            //intList.ForEach(el => System.Diagnostics.Debug.WriteLine(el));
            //UserController u = new UserController();
            //u.LogIn(intList[0]);
            return View();
        }
        public ActionResult LogInTest(Registration reg)
        {
            ModelState.Remove("State");
            ModelState.Remove("City");
            ModelState.Remove("PinCode");
            ModelState.Remove("Address1");
            ModelState.Remove("Address2");
            ModelState.Remove("FullName");
            ModelState.Remove("GallonsRequested");
            ModelState.Remove("DeliveryAddress");
            ModelState.Remove("DeliveryDate");
            ModelState.Remove("SuggestedPrice");
            ModelState.Remove("TotalAmountDue");
            if (ModelState.IsValid)
            {
                bool IsValid = false;
                FuelProjectController l = new FuelProjectController();
                List<User> intList = l.LoginUser();
                User u = intList[0];
                if (u.LoginId == reg.UserName)
                {
                    if (u.Password == reg.Password)
                    {
                        IsValid = true;
                    }
                    if (IsValid == true)
                    {
                        RedirectToRouteResult url = RedirectToAction("ClientProfile", "User");
                        return url;
                    }
                }
            }
            return View(reg);
        }
        public ActionResult ClientProfileTest(Registration reg)
        {
            ModelState.Remove("Password");
            ModelState.Remove("UserName");
            ModelState.Remove("GallonsRequested");
            ModelState.Remove("DeliveryAddress");
            ModelState.Remove("DeliveryDate");
            ModelState.Remove("SuggestedPrice");
            ModelState.Remove("TotalAmountDue");
            if (ModelState.IsValid)
            {
                FuelProjectController l = new FuelProjectController();
                List<User> intList = l.LoginUser();
                User u = intList[0];
                if (u.LoginId == reg.UserName)
                {
                    if (u.FullName == reg.FullName && u.Address1 == reg.Address1 && u.Address2 == reg.Address2 && u.City == reg.City && u.State == reg.State && u.ZipCode == reg.ZipCode)
                    {
                        RedirectToRouteResult url = RedirectToAction("FuelQuoteForm", "User");
                        return url;
                    }
                }
            }
            return View(reg);
        }
        public ActionResult FuelQuoteForm(Registration reg)
        {
            ModelState.Remove("State");
            ModelState.Remove("City");
            ModelState.Remove("PinCode");
            ModelState.Remove("Address1");
            ModelState.Remove("Address2");
            ModelState.Remove("FullName");
            ModelState.Remove("Password");
            ModelState.Remove("UserName");
            if (ModelState.IsValid)
            {
                FuelProjectController l = new FuelProjectController();
                List<User> intListu = l.LoginUser();
                User u = intListu[0];
                List<FuelQuoteForm> intListf = l.FuelQuoteFormUser();
                FuelQuoteForm f = intListf[0];
                if (f.GallonsRequested == reg.GallonsRequested && f.SuggestedPrice == reg.SuggestedPrice && f.DeliveryDate.ToString() == reg.DeliveryDate.ToString() && u.Address1 == reg.Address1 && u.Address2 == reg.Address2)
                {
                    RedirectToRouteResult url = RedirectToAction("FuelQuoteHistory", "User");
                    return url;
                }
            }
            return View();
        }
    }
}