using System;
using System.Collections.Generic;
using System.Text;

namespace StaffHelper.Model.ViewModels
{
    public class UpdateCompanyViewModel: BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
