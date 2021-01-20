using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Data.Entities
{
   public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTimeOffset? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public bool lockoutOnFailure { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string Url { get; set; }
        public ICollection<Participants> Participants { get; set; }
        public bool Lock { get; set; }
    }
}
