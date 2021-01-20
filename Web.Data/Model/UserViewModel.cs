using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Data.Model
{
 public   class UserViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

    }
}
