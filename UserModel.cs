using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcCrudWithAdo.Models
{
    public class UserModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "name Is required")]
        [Display(Name = "user Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "email Is required")]
        [Display(Name = "email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "age Is required")]
        [Display(Name = "age")]
        [Range(18, 60, ErrorMessage = "age must be in between 18 to 60")]
        public string Age { get; set; }
    }
}