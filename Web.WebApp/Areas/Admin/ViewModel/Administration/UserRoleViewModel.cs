using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.WebApp.Areas.Admin.ViewModel.Administration
{
    public class UserRoleViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }

    }
}
