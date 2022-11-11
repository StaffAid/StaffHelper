using System;

namespace StaffHelper.Model.ViewModels
{
    public class CreateUserViewModel:BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PrimaryEmail { get; set; }

        public string PrimaryPhoneNumber { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string StateOfOrigin { get; set; }

        public string Gender { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool SoftDelete { get; set; }
    }
}
