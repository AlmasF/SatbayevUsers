namespace SatbayevUsers.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string IIN { get; set; }
    }
}
