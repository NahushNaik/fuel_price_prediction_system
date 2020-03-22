using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FinTech.DataAccess;
using LoginInMVC4WithEF.Models;
using ProjectDataAccess;

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
        public ActionResult ClientProfile()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Models.Registration userr)
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
                if (IsValid(userr.UserName, userr.Password))
                {
                    FormsAuthentication.SetAuthCookie(userr.Email, false);
                    return RedirectToAction("ClientProfile", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Login details are wrong.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error, Check data");
            }
            return View(userr);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FuelQuoteHistory()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FuelQuoteForm()
        {
            return View();
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
                        }
             
                        userobj.Password = user.Password;
                        userobj.IsActive = true;
                        userobj.CreatedBy = User.Identity.Name;
                        userobj.ModifiedBy = User.Identity.Name;
                        userobj.CreatedDate = DateTime.Now;
                        userobj.ModifiedDate = DateTime.Now;
                        if(!isExist)
                            dbContext.UserRepository.Add(userobj);
                        dbContext.Commit();
                        return RedirectToAction("Login", "User");
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
        public ActionResult ClientProfile(Models.Registration users)
        {
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
                    using (var db = new LoginInMVC4WithEF.Models.UserEntities2())
                    {
                        var crypto = new SimpleCrypto.PBKDF2();
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
                        db.SaveChanges();
                        return RedirectToAction("FuelQuoteForm", "User");
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
            try
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
                    using (var db = new LoginInMVC4WithEF.Models.UserEntities2())
                    {
                        var crypto = new SimpleCrypto.PBKDF2();
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
                        db.SaveChanges();
                        return RedirectToAction("FuelQuoteHistory", "User");
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

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new LoginInMVC4WithEF.Models.UserEntities2())
            {
                //var user = db.Registrations.FirstOrDefault(u => u.Email == email);
                //if (user != null)
                //{
                //    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                //    {
                IsValid = true;
                //    }
                //}
            }
            return IsValid;
        }

    }
}
