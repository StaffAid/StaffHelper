using System;

namespace StaffHelper.Model.Entities
{
    public class EmploymentHistory: BaseEntity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
