using System;
using System.ComponentModel.DataAnnotations;

namespace Brog.ViewModels
{
    public class RegisterUserViewModel
    {
        public RegisterUserViewModel()
        {
        }
        [Required, MaxLength(256)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
