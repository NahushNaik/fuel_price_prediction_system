//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginInMVC4WithEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;

    public partial class Registration
    {
        public int UserId { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address ")]
        public string Email { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Username must be atleast 6 characters long and no more than 25")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "State ")]
        public string State { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        [Display(Name = "City ")]
        public string City { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 5, ErrorMessage = "ZIP Code must be atleast 5 characters long and no more than 9")]
        [Display(Name = "ZIP Code ")]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        [Display(Name = "Address 1 ")]
        public string Address1 { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        [Display(Name = "Address 2 ")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Please enter your full name")]
        [StringLength(50, ErrorMessage = "Full Name cannot exceed 50 characters")]
        [Display(Name = "Full Name ")]
        public string FullName { get; set; }

        //[Required]
        [Display(Name = "Gallons Requested ")]
        public double? GallonsRequested { get; set; }


        [StringLength(100)]
        [Display(Name = "Delivery Address ")]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Delivery Date ")]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [Display(Name = "Suggested Price ")]
        public double SuggestedPrice { get; set; }

        [Required]
        [Display(Name = "Total Amount Due ")]
        public double TotalAmountDue { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        //[MinLength(8, ErrorMessage = "Password must be atleast 8 characters long")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match, please try again")]
        [Display(Name = "Confirm Password")]
        public string Confirm { get; set; }

        public string PasswordSalt { get; set; }

        [Display(Name = "First Name ")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name ")]
        public string LastName { get; set; }
        public string UserType { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public string SecurityAnswer { get; set; }
        public string SecurityQuestion { get; set; }

        public string UserImage { get; set; }
    }
}
