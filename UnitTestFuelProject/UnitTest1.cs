using System;
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
}
