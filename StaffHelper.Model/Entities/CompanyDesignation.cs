using System;

namespace StaffHelper.Model.Entities
{
    public class CompanyDesignation: BaseEntity
    {
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
    }
}
