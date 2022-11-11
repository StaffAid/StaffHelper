using System;
using System.Collections.Generic;
using System.Text;

namespace StaffHelper.Model.ViewModels
{
    public class UpdateUserViewModel:BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PrimaryEmail { get; set; }

        public string PrimaryPhoneNumber { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string StateOfOrigin { get; set; }

        public string Gender { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
