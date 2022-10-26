using System;
using System.Collections.Generic;
using System.Text;

namespace StaffHelper.Model.ViewModels
{
    public class CreateCompanyRoleViewModel:BaseModel
    {
        public string CompanyId { get; set; }

        public string RoleId { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool SoftDelete { get; set; }
    }
}
