using System;
using System.Collections.Generic;
using System.Text;

namespace StaffHelper.Model.ViewModels
{
    public class UpdateCompanyDesignationViewModel:BaseModel
    {
        public string Name { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
