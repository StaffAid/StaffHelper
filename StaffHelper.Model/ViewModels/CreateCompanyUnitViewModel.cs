using System;
using System.Collections.Generic;
using System.Text;

namespace StaffHelper.Model.ViewModels
{
    public class CreateCompanyUnitViewModel:BaseModel
    {
        public string CompanyId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool SoftDelete { get; set; }

    }
}
