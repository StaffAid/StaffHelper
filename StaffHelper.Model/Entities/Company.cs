namespace StaffHelper.Model.Entities
{
    public class Company: BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string RcNo { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
    }
}
