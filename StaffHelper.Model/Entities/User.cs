using StaffHelper.Model.Enum;
using System;

namespace StaffHelper.Model.Entities
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string StateOfOrigin { get; set; }
        public Gender Gender { get; set; }
    }
}
