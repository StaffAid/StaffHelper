using System;

namespace StaffHelper.Model.Entities
{
    public class Employee: BaseEntity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string EmployeeIdentity { get; set; }
        public string OfficialMail { get; set; }
        public string OfficialPhoneNumber { get; set; }
        public CompanyRole CompanyRole { get; set; }
        public Guid CompanyRoleId { get; set; }
        public CompanyUnit CompanyUnit { get; set; }
        public Guid CompanyUnitId { get; set; }
        public CompanyDesignation CompanyDesignation { get; set; }
        public Guid CompanyDesignationId { get; set; }
       
    }
}
