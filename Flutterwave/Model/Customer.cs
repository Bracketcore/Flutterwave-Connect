namespace Flutterwave.Model
{
    public interface Customer
    {
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string name { get; set; }
        public string? username { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? CustomerId { get; set; }
    }
}