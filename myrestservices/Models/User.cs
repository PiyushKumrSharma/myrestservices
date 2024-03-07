namespace myrestservices.Models
{
    public class User
    {
        public string Gender { get; set; }
        public Name Name { get; set; }
        public string Email { get; set; }
    }

    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; }
    }
}
