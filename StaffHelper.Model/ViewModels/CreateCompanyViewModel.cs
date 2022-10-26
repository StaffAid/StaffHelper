using System;
using System.Collections.Generic;
using System.Text;

namespace StaffHelper.Model.ViewModels
{
    public class CreateCompanyViewModel : BaseModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int RcNo { get; set; }

        public string Website { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool SoftDelete { get; set; }
    }
}   