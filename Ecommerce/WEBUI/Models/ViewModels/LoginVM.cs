using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBUI.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "can not empty username" )]
        public string Username { get; set; }
        [Required(ErrorMessage = "can not empty password")]

        public string Password { get; set; }
    }
}