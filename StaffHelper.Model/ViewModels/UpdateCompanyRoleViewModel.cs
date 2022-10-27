using System;
using System.Collections.Generic;
using System.Text;

namespace StaffHelper.Model.ViewModels
{
    public class UpdateCompanyRoleViewModel:BaseModel
    {
        public string RoleId { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
