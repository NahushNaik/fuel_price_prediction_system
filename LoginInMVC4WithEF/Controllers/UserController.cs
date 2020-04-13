using FinTech.DataAccess;
using ProjectDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Windows.Forms;

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
            return View();
        }
        [HttpGet]
        public ActionResult ClientProfile()
        {
            if (Session["ValidLogin"].Equals(false))
            {
                MessageBox.Show("Please login again");
                return RedirectToAction("LogIn", "User");
            }
            return View();
        }
        [HttpGet]
        public ActionResult FuelQuoteForm()
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
                }
            }
            catch { }
            return View();
        }
        [HttpGet]
        public ActionResult FuelQuoteHistory()
        {
            IEnumerable<FuelQuoteForm> list = null;


            using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
            {
                string username = null;
                string userid = null; 
                try
                {
                    if (Request.Cookies["userid"] != null)
                        userid = Request.Cookies["userid"].Value;
                    if (Request.Cookies["username"] != null)
                        username = Request.Cookies["username"].Value;
                    //var result = (from item1 in dbContext.FuelQuoteFormRepository.GetAll().Where(x => x.UserId.ToString() == userid) join item2 in dbContext.UserRepository)
                }
                catch (Exception ex)
                { 
                
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.Registration userr)
        {
            ModelState.Remove("Confirm");
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
                if (IsValid(userr.UserName, userr.Password))
                {
                    Session["ValidLogin"] = true;
                    FormsAuthentication.SetAuthCookie(userr.Email, false);
                    HttpCookie username = new HttpCookie("username");
                    username.Value = userr.UserName;
                    Response.Cookies.Add(username);
                    MessageBox.Show("Login Successful");
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
                    //MessageBox.Show("Login details are wrong");
                    //ViewBag.Message = "Login details are wrong";
                    ModelState.AddModelError("UserNamePassword", "Invalid username or password.");
                    //ModelState.AddModelError("Password", "");
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
                ModelState.Remove("PinCode");
                ModelState.Remove("Address1");
                ModelState.Remove("Address2");
                ModelState.Remove("FullName");
                //ModelState.Remove("Password");
                ModelState.Remove("GallonsRequested");
                ModelState.Remove("DeliveryAddress");
                ModelState.Remove("DeliveryDate");
                ModelState.Remove("SuggestedPrice");
                ModelState.Remove("TotalAmountDue");
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
                            userobj.Password = user.Password;
                            userobj.IsActive = true;
                            userobj.NewUser = true;
                            userobj.CreatedBy = User.Identity.Name;
                            userobj.ModifiedBy = User.Identity.Name;
                            userobj.CreatedDate = DateTime.Now;
                            userobj.ModifiedDate = DateTime.Now;
                            //MessageBox.Show("User already exists");
                        }
                        else
                        {
                            //ModelState.AddModelError("User already exist", "User already exist");
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
                ModelState.Remove("UserName");
                ModelState.Remove("GallonsRequested");
                ModelState.Remove("DeliveryAddress");
                ModelState.Remove("DeliveryDate");
                ModelState.Remove("SuggestedPrice");
                ModelState.Remove("TotalAmountDue");
                if (ModelState.IsValid)
                {
                    using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
                    {
                        if (Request.Cookies["username"] != null)
                            username = Request.Cookies["username"].Value;
                        //HttpCookie username = Request.Cookies["username"];
                        User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == username).FirstOrDefault();
                        //var crypto = new SimpleCrypto.PBKDF2();
                        //var encrypPass = crypto.Compute(user.Password);
                        //var newUser = db.Registrations.Create();
                        //newUser.Email = user.Email;
                        //newUser.Password = encrypPass;
                        //newUser.PasswordSalt = crypto.Salt;
                        //FirstName = User.FirstName;
                        //LastName = User.LastName;
                        userobj.FullName = users.FullName;
                        userobj.Address1 = users.Address1;
                        userobj.Address2 = users.Address2;
                        userobj.City = users.City;
                        userobj.State = users.State;
                        userobj.ZipCode = users.PinCode;
                        userobj.NewUser = false;
                        //newUser.UserType = "User";
                        //newUser.CreatedDate = DateTime.Now;
                        //newUser.IsActive = true;
                        //newUser.IPAddress = "642 White Hague Avenue";
                        //db.Registrations.Add(newUser);
                        dbContext.Commit();
                        return RedirectToAction("MainPage", "User");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Data is not correct");
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
                    //users.DeliveryAddress = userobj.Address1;
                    ViewData["DeliveryAddress"] = userobj.Address1 + "," + userobj.Address2 + "," + userobj.City + "," + userobj.State;
                    if (users.GallonsRequested <= 0) 
                    {
                        //ModelState.Remove("GallonsRequested");
                        ModelState.AddModelError("Gallons requested zero or negative", "Gallons requested can not be zero or negative.");
                    }
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
                        var obj = new FuelQuoteForm
                        {
                            UserId = Convert.ToInt16(userid),
                            GallonsRequested = users.GallonsRequested,
                            DeliveryDate = users.DeliveryDate,
                            DeliveryAddress = userobj.Address1 + "," + userobj.Address2 + "," + userobj.City + "," + userobj.State,
                            SuggestedPrice = users.SuggestedPrice,
                        };

                        dbContext.FuelQuoteFormRepository.Add(obj);
                        dbContext.Commit();
                        return RedirectToAction("FuelQuoteHistory", "User");
                    }
                    //var crypto = new SimpleCrypto.PBKDF2();
                    //var encrypPass = crypto.Compute(user.Password);
                    //var newUser = db.Registrations.Create();
                    //newUser.Email = user.Email;
                    //newUser.Password = encrypPass;
                    //newUser.PasswordSalt = crypto.Salt;
                    //newUser.FirstName = user.FirstName;
                    //newUser.LastName = user.LastName;
                    //newUser.UserType = "User";
                    //newUser.CreatedDate = DateTime.Now;
                    //newUser.IsActive = true;
                    //newUser.IPAddress = "642 White Hague Avenue";
                    //db.Registrations.Add(newUser);
                    //db.SaveChanges();
                    //return RedirectToAction("FuelQuoteHistory", "User");

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
        [HttpPost]
        public ActionResult GetQuote(Models.Registration users)
        {
            return View();
        }
            public ActionResult LogOut()
        {
            Session["ValidLogin"] = false;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        private bool IsValid(string email, string password)
        {
            //var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var dbContext = new UnitOfWorkFinance<FinTechFinanceDbContext>())
            {
                //var user = db.Registrations.FirstOrDefault(u => u.Email == email);
                User userobj = dbContext.UserRepository.GetAll().Where(x => x.LoginId == email).FirstOrDefault();
                if (userobj != null)
                {
                    //if (user.Password == crypto.Compute(password, user.PasswordSalt))
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
