
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class SimpleViewModel : IValidatableObject
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        // 可自訂模型驗證
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}