using FinTech.DataAccess;
using LoginInMVC4WithEF.Entity;
using ProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace LoginInMVC4WithEF.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MainPage()
        {
            if (Session["ValidLogin"].Equals(false))
            {
                MessageBox.Show("Please login again");
                return RedirectToAction("LogIn", "User");
            }
            string username = null;
            string userid = null;
            if (Request.Cookies["userid"] != null)
                userid = Request.Cookies["userid"].Value;
            if (Request.Cookies["username"] != null)
                username = Request.Cookies["username"].Value;
            using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
            {
                User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == username).FirstOrDefault();
                return View(userobj);
            }
        }

        [HttpGet]
        public ActionResult ClientProfile()
        {
            if (Session["ValidLogin"].Equals(false))
            {
                MessageBox.Show("Please login again");
                return RedirectToAction("LogIn", "User");
            }
            using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
            {
                User userobj = null;
                string username = null;
                string userid = null;
                
                try
                {  
                    if (Request.Cookies["userid"] != null)
                        userid = Request.Cookies["userid"].Value;
                    if (Request.Cookies["username"] != null)
                        username = Request.Cookies["username"].Value;
                    userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == username).FirstOrDefault();
                    userobj.SDL = new List<SelectListItem>
                    {
                        new SelectListItem() {Text="Alabama", Value="AL"},
                        new SelectListItem() { Text="Alaska", Value="AK"},
                        new SelectListItem() { Text="Arizona", Value="AZ"},
                        new SelectListItem() { Text="Arkansas", Value="AR"},
                        new SelectListItem() { Text="California", Value="CA"},
                        new SelectListItem() { Text="Colorado", Value="CO"},
                        new SelectListItem() { Text="Connecticut", Value="CT"},
                        new SelectListItem() { Text="District of Columbia", Value="DC"},
                        new SelectListItem() { Text="Delaware", Value="DE"},
                        new SelectListItem() { Text="Florida", Value="FL"},
                        new SelectListItem() { Text="Georgia", Value="GA"},
                        new SelectListItem() { Text="Hawaii", Value="HI"},
                        new SelectListItem() { Text="Idaho", Value="ID"},
                        new SelectListItem() { Text="Illinois", Value="IL"},
                        new SelectListItem() { Text="Indiana", Value="IN"},
                        new SelectListItem() { Text="Iowa", Value="IA"},
                        new SelectListItem() { Text="Kansas", Value="KS"},
                        new SelectListItem() { Text="Kentucky", Value="KY"},
                        new SelectListItem() { Text="Louisiana", Value="LA"},
                        new SelectListItem() { Text="Maine", Value="ME"},
                        new SelectListItem() { Text="Maryland", Value="MD"},
                        new SelectListItem() { Text="Massachusetts", Value="MA"},
                        new SelectListItem() { Text="Michigan", Value="MI"},
                        new SelectListItem() { Text="Minnesota", Value="MN"},
                        new SelectListItem() { Text="Mississippi", Value="MS"},
                        new SelectListItem() { Text="Missouri", Value="MO"},
                        new SelectListItem() { Text="Montana", Value="MT"},
                        new SelectListItem() { Text="Nebraska", Value="NE"},
                        new SelectListItem() { Text="Nevada", Value="NV"},
                        new SelectListItem() { Text="New Hampshire", Value="NH"},
                        new SelectListItem() { Text="New Jersey", Value="NJ"},
                        new SelectListItem() { Text="New Mexico", Value="NM"},
                        new SelectListItem() { Text="New York", Value="NY"},
                        new SelectListItem() { Text="North Carolina", Value="NC"},
                        new SelectListItem() { Text="North Dakota", Value="ND"},
                        new SelectListItem() { Text="Ohio", Value="OH"},
                        new SelectListItem() { Text="Oklahoma", Value="OK"},
                        new SelectListItem() { Text="Oregon", Value="OR"},
                        new SelectListItem() { Text="Pennsylvania", Value="PA"},
                        new SelectListItem() { Text="Rhode Island", Value="RI"},
                        new SelectListItem() { Text="South Carolina", Value="SC"},
                        new SelectListItem() { Text="South Dakota", Value="SD"},
                        new SelectListItem() { Text="Tennessee", Value="TN"},
                        new SelectListItem() { Text="Texas", Value="TX"},
                        new SelectListItem() { Text="Utah", Value="UT"},
                        new SelectListItem() { Text="Vermont", Value="VT"},
                        new SelectListItem() { Text="Virginia", Value="VA"},
                        new SelectListItem() { Text="Washington", Value="WA"},
                        new SelectListItem() { Text="West Virginia", Value="WV"},
                        new SelectListItem() { Text="Wisconsin", Value="WI"},
                        new SelectListItem() { Text="Wyoming", Value="WY"}
                    };
                    if (userobj.State == null)
                    {
                        userobj.SelectedItem = "AL";
                    }
                    else 
                    {
                        userobj.SelectedItem = userobj.State;
                    }
                    var x1 = userobj;
                    ViewData["ClientProfile"] = userobj;
                    ViewBag.User = userobj;
                }
                catch(DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return View(userobj);
            }
        }

        [HttpGet]
        public ActionResult FuelQuoteForm()
        {
            if (Session["ValidLogin"].Equals(false))
            {
                MessageBox.Show("Please login again");
                return RedirectToAction("LogIn", "User");
            }
            string username = null;
            string userid = null;
            try
            {
                using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
                {
                    if (Request.Cookies["userid"] != null)
                        userid = Request.Cookies["userid"].Value;
                    if (Request.Cookies["username"] != null)
                        username = Request.Cookies["username"].Value;
                    User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == username).FirstOrDefault();
                    ViewData["DeliveryAddress"] = userobj.Address1 + "," + userobj.Address2 + "," + userobj.City + "," + userobj.State;
                }
            }
            catch(DbEntityValidationException e) 
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
        }

        [HttpGet]
        public ActionResult FuelQuoteHistory()
        {
            if (Session["ValidLogin"].Equals(false))
            {
                MessageBox.Show("Please login again");
                return RedirectToAction("LogIn", "User");
            }
            IEnumerable<FuelQuoteForm> list = null;
            using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
            {
                string username = null;
                short userid=0; 
                try
                {
                    if (Request.Cookies["userid"] != null)
                        userid = Convert.ToInt16(Request.Cookies["userid"].Value);
                    if (Request.Cookies["username"] != null)
                        username = Request.Cookies["username"].Value;
                    var result = (from item1 in dbContext.FuelQuoteFormRepository.GetAll().Where(x => x.UserId == userid) 
                                  select new 
                                  { 
                                    OrderId = item1.OrderId,
                                    GallonsRequested = item1.GallonsRequested,
                                    DeliveryDate = item1.DeliveryDate,
                                    DeliveryAddress = item1.DeliveryAddress,
                                    SuggestedPrice = item1.SuggestedPrice,
                                    TotalAmountDue = item1.TotalAmountDue
                                  }).ToList(); 
                   list = result.Select(x => new FuelQuoteForm
                   {
                        OrderId = x.OrderId,
                        GallonsRequested = x.GallonsRequested,
                        DeliveryDate = x.DeliveryDate,
                        DeliveryAddress = x.DeliveryAddress,
                        SuggestedPrice = x.SuggestedPrice,
                        TotalAmountDue = x.TotalAmountDue
                   });
                   ViewBag.MyList = list;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            Session["ValidLogin"] = false;
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult LogIn(Models.Registration userr)
        {
            ModelState.Remove("Confirm");
            ModelState.Remove("State");
            ModelState.Remove("City");
            ModelState.Remove("ZipCode");
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
                if (IsValid(userr.UserName, userr.Password))
                {
                    Session["ValidLogin"] = true;
                    FormsAuthentication.SetAuthCookie(userr.Email, false);
                    HttpCookie username = new HttpCookie("username");
                    username.Value = userr.UserName;
                    Response.Cookies.Add(username);
                    //MessageBox.Show("Login Successful");
                    //TempData["msg"] = "<script>alert('Recored inserted successfully');</script>";
                    //ViewBag.Message = "Recored inserted successfully";
                    using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
                    {
                        User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == userr.UserName).FirstOrDefault();
                        if (userobj.NewUser == true)
                        {
                            return RedirectToAction("ClientProfile", "User");
                        }
                        else
                        {
                            ViewData["DeliveryAddress"] = userobj.Address1;
                            return RedirectToAction("MainPage", "User");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("UserNamePassword", "Invalid username or password.");
                }
            }
            else
            { 
                ModelState.AddModelError("Model Invalid", "");
            }
            return View(userr);
        }

        [HttpPost]
        public ActionResult Register(Models.Registration user)
        {
            try
            {
                ModelState.Remove("State");
                ModelState.Remove("City");
                ModelState.Remove("ZipCode");
                ModelState.Remove("Address1");
                ModelState.Remove("Address2");
                ModelState.Remove("FullName");
                ModelState.Remove("GallonsRequested");
                ModelState.Remove("DeliveryAddress");
                ModelState.Remove("DeliveryDate");
                ModelState.Remove("SuggestedPrice");
                ModelState.Remove("TotalAmountDue");
                string MatchPasswordPattern = @"(?=^.{8,15}$)(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?!.*\s).*$";
                if ((user.Password != null) && (!(Regex.IsMatch(user.Password, MatchPasswordPattern))))
                {
                    ModelState.AddModelError("Password Length Check", "Password should be minimum 8 charcters long");
                    ModelState.AddModelError("Password Regex Check", "Password should contain atleast 1 lowercase, 1 uppercase, 1 special character");
                }

                if (ModelState.IsValid)
                {
                    using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
                    {
                        User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == user.UserName).FirstOrDefault();
                        bool isExist = true;
                        
                        if (userobj == null)
                        {
                            userobj = new User();
                            isExist = false;
                            userobj.LoginId = user.UserName;
                            //var crypto = new SimpleCrypto.PBKDF2();
                            userobj.Password = user.Password;
                            userobj.IsActive = true;
                            userobj.NewUser = true;
                            userobj.CreatedBy = "Admin";
                            userobj.ModifiedBy = "Admin";
                            userobj.CreatedDate = DateTime.Now;
                            userobj.ModifiedDate = DateTime.Now;
                        }
                        else if (userobj != null)
                        {
                            MessageBox.Show("User already exist");
                            return RedirectToAction("Login", "User");
                        }
                        if (!isExist)
                            dbContext.UserRepository.Add(userobj);

                        dbContext.Commit();
                        return RedirectToAction("Login", "User");
                    }
                }
                else
                {
                    using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
                    {
                        User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == user.UserName).FirstOrDefault();
                        if (userobj != null)
                        {
                            MessageBox.Show("User already exist");
                            return RedirectToAction("Login", "User");
                        }
                    }
                    ModelState.AddModelError("", "");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
        }

        [HttpPost]
        public ActionResult ClientProfile(Models.Registration users)
        {
            if (Session["ValidLogin"].Equals(false))
            {
                return RedirectToAction("LogIn", "User");
            }
            string username = null;
            try
            {

                ModelState.Remove("Password");
                //ModelState.Remove("ConfirmPassword");
                ModelState.Remove("UserName");
                ModelState.Remove("GallonsRequested");
                ModelState.Remove("DeliveryAddress");
                ModelState.Remove("DeliveryDate");
                ModelState.Remove("SuggestedPrice");
                ModelState.Remove("TotalAmountDue");
                using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
                {
                    if (Request.Cookies["username"] != null)
                        username = Request.Cookies["username"].Value;
                    User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == username).FirstOrDefault();
                    if (ModelState.IsValid)
                    {
                        userobj.FullName = users.FullName;
                        userobj.Address1 = users.Address1;
                        userobj.Address2 = users.Address2;
                        userobj.City = users.City;
                        userobj.State = users.State;
                        userobj.ZipCode = users.ZipCode;
                        //if (users.ChangePassword != null)
                        //{
                        //    userobj.Password = users.ChangePassword;
                        //}
                        userobj.NewUser = false;
                        dbContext.Commit();
                        return RedirectToAction("MainPage", "User");
                    }
                    else
                    {
                        userobj.SDL = new List<SelectListItem>
                        {
                        new SelectListItem() {Text="Alabama", Value="AL"},
                        new SelectListItem() { Text="Alaska", Value="AK"},
                        new SelectListItem() { Text="Arizona", Value="AZ"},
                        new SelectListItem() { Text="Arkansas", Value="AR"},
                        new SelectListItem() { Text="California", Value="CA"},
                        new SelectListItem() { Text="Colorado", Value="CO"},
                        new SelectListItem() { Text="Connecticut", Value="CT"},
                        new SelectListItem() { Text="District of Columbia", Value="DC"},
                        new SelectListItem() { Text="Delaware", Value="DE"},
                        new SelectListItem() { Text="Florida", Value="FL"},
                        new SelectListItem() { Text="Georgia", Value="GA"},
                        new SelectListItem() { Text="Hawaii", Value="HI"},
                        new SelectListItem() { Text="Idaho", Value="ID"},
                        new SelectListItem() { Text="Illinois", Value="IL"},
                        new SelectListItem() { Text="Indiana", Value="IN"},
                        new SelectListItem() { Text="Iowa", Value="IA"},
                        new SelectListItem() { Text="Kansas", Value="KS"},
                        new SelectListItem() { Text="Kentucky", Value="KY"},
                        new SelectListItem() { Text="Louisiana", Value="LA"},
                        new SelectListItem() { Text="Maine", Value="ME"},
                        new SelectListItem() { Text="Maryland", Value="MD"},
                        new SelectListItem() { Text="Massachusetts", Value="MA"},
                        new SelectListItem() { Text="Michigan", Value="MI"},
                        new SelectListItem() { Text="Minnesota", Value="MN"},
                        new SelectListItem() { Text="Mississippi", Value="MS"},
                        new SelectListItem() { Text="Missouri", Value="MO"},
                        new SelectListItem() { Text="Montana", Value="MT"},
                        new SelectListItem() { Text="Nebraska", Value="NE"},
                        new SelectListItem() { Text="Nevada", Value="NV"},
                        new SelectListItem() { Text="New Hampshire", Value="NH"},
                        new SelectListItem() { Text="New Jersey", Value="NJ"},
                        new SelectListItem() { Text="New Mexico", Value="NM"},
                        new SelectListItem() { Text="New York", Value="NY"},
                        new SelectListItem() { Text="North Carolina", Value="NC"},
                        new SelectListItem() { Text="North Dakota", Value="ND"},
                        new SelectListItem() { Text="Ohio", Value="OH"},
                        new SelectListItem() { Text="Oklahoma", Value="OK"},
                        new SelectListItem() { Text="Oregon", Value="OR"},
                        new SelectListItem() { Text="Pennsylvania", Value="PA"},
                        new SelectListItem() { Text="Rhode Island", Value="RI"},
                        new SelectListItem() { Text="South Carolina", Value="SC"},
                        new SelectListItem() { Text="South Dakota", Value="SD"},
                        new SelectListItem() { Text="Tennessee", Value="TN"},
                        new SelectListItem() { Text="Texas", Value="TX"},
                        new SelectListItem() { Text="Utah", Value="UT"},
                        new SelectListItem() { Text="Vermont", Value="VT"},
                        new SelectListItem() { Text="Virginia", Value="VA"},
                        new SelectListItem() { Text="Washington", Value="WA"},
                        new SelectListItem() { Text="West Virginia", Value="WV"},
                        new SelectListItem() { Text="Wisconsin", Value="WI"},
                        new SelectListItem() { Text="Wyoming", Value="WY"}
                        };
                        if (userobj.State == null)
                        {
                            userobj.SelectedItem = "AL";
                            ViewBag.User = userobj;
                        }
                        else
                        {
                            userobj.SelectedItem = userobj.State;
                            ViewBag.User = userobj;
                        }
                        ModelState.AddModelError("", "");
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
        }


        [HttpPost]
        public ActionResult FuelQuoteForm(Models.Registration users)
        {
            if (Session["ValidLogin"].Equals(false))
            {
                return RedirectToAction("LogIn", "User");
            }
            string username = null;
            string userid = null;
            try
            {
                using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
                {
                    if (Request.Cookies["userid"] != null)
                        userid = Request.Cookies["userid"].Value;
                    if (Request.Cookies["username"] != null)
                        username = Request.Cookies["username"].Value;
                    User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == username).FirstOrDefault();
                    ViewData["DeliveryAddress"] = userobj.Address1 + "," + userobj.Address2 + "," + userobj.City + "," + userobj.State;
                    if (users.GallonsRequested <= 0) 
                    {
                        ModelState.AddModelError("Gallons requested zero or negative", "Gallons requested can not be zero or negative.");
                    }
                    ModelState.Remove("State");
                    ModelState.Remove("City");
                    ModelState.Remove("ZipCode");
                    ModelState.Remove("Address1");
                    ModelState.Remove("Address2");
                    ModelState.Remove("FullName");
                    ModelState.Remove("Password");
                    ModelState.Remove("UserName");
 
                    if (ModelState.IsValid)
                    {
                        Models.Registration u = (Models.Registration)Session["QuoteDetails"];
                        var obj = new FuelQuoteForm
                        {
                            UserId = Convert.ToInt16(userid),
                            GallonsRequested = users.GallonsRequested,
                            DeliveryDate = users.DeliveryDate.Date.ToString("d"),
                            DeliveryAddress = userobj.Address1 + "," + userobj.Address2 + "," + userobj.City + "," + userobj.State,
                            SuggestedPrice = u.SuggestedPrice,
                            TotalAmountDue = u.TotalAmountDue
                        };
                        dbContext.FuelQuoteFormRepository.Add(obj);
                        dbContext.Commit();
                        //MessageBox.Show("Thank You! Your order has been placed successfully.");
                        return RedirectToAction("ThankYou", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return View();
        }
        public ActionResult ThankYou() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPrice(Models.Registration users)
        {
            string username = null;
            short userid = 0;
            try
            {
                ModelState.Remove("State");
                ModelState.Remove("City");
                ModelState.Remove("ZipCode");
                ModelState.Remove("Address1");
                ModelState.Remove("Address2");
                ModelState.Remove("FullName");
                ModelState.Remove("Password");
                ModelState.Remove("UserName");
                using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
                {
                    if (Request.Cookies["userid"] != null)
                        userid = Convert.ToInt16(Request.Cookies["userid"].Value);
                    if (Request.Cookies["username"] != null)
                        username = Request.Cookies["username"].Value;
                    
                    if (Convert.ToString(users.GallonsRequested)==String.Empty)
                    {
                        ModelState.AddModelError("Please enter gallons requested", "Please enter gallons requested");
                    }
                    else if (users.GallonsRequested <= 0)
                    {
                        ModelState.AddModelError("Gallons requested zero or negative", "Gallons requested can not be zero or negative.");
                    }
                    if (Convert.ToDateTime(users.DeliveryDate).Date == new DateTime(0001, 01, 01))
                    {
                        ModelState.AddModelError("Delivery Date Null", "");
                    }
                    else if (Convert.ToDateTime(users.DeliveryDate).Date < DateTime.Today )
                    {
                        ModelState.AddModelError("Delivery Date can not be in past", "Delivery Date can not be in past");
                    }
                    
                    User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == username).FirstOrDefault();
                    users.DeliveryAddress = userobj.Address1 + "," + userobj.Address2 + "," + userobj.City + "," + userobj.State;
                    ViewData["DeliveryAddress"] = users.DeliveryAddress;
                    var count = dbContext.FuelQuoteFormRepository.GetAll().Where(x => x.UserId == userid).ToList().Count();
                    
                    if (ModelState.IsValid)
                    {
                        double SG; double CP = 1.50; double MP; double LF; double RHF; double GRF; double CPF = .10; double RF;
                        LF = userobj.State == "TX" ? .02 : .04;
                        RHF = count!= 0 ? .01 : 0.0;
                        GRF = users.GallonsRequested > 1000 ? 0.02 : 0.03;
                        var d = Convert.ToDateTime(users.DeliveryDate).Date;
                        //string dd = users.DeliveryDate.ToString();
                        //string[] arrdd = dd.Split('/');
                        int day = d.Day;//Convert.ToInt16(arrdd[0]);
                        int month = d.Month; //Convert.ToInt16(arrdd[1]);
                        RF = (day > 21 && day  < 23 && month >= 6 && month <=9) ?.04:.03;
                        MP = CP * (LF - RHF + GRF + CPF + RF);
                        SG = CP + MP;
                        users.SuggestedPrice = SG;
                        users.TotalAmountDue = Convert.ToDouble(users.GallonsRequested) * users.SuggestedPrice;
                        Session["QuoteDetails"] = users;
                        return RedirectToAction("SubmitQuote");
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
                    }
                }
            }
            catch (Exception ex)
            { 
            
            }
            return View("FuelQuoteForm");
        }

        public ActionResult SubmitQuote()
        {
            Models.Registration u = (Models.Registration)Session["QuoteDetails"];
            return View(u);
        }

        


        private bool IsValid(string email, string password)
        {
            bool IsValid = false;
            var crypto = new SimpleCrypto.PBKDF2();
            string decrypto = crypto.Compute(password);
            using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
            {
                User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == email).FirstOrDefault();
                if (userobj != null)
                {
                    if (userobj.Password == password)
                    {
                        IsValid = true;
                        HttpCookie userid = new HttpCookie("userid");
                        userid.Value = userobj.UserId.ToString();
                        Response.Cookies.Add(userid);
                    }
                }
            }
            return IsValid;
        }

    }
}
