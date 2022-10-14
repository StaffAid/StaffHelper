using System;

namespace StaffHelper.Model.Entities
{
    public class CompanyRole: BaseEntity
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
