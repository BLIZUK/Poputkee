namespace Poputkee.Core.Models
{
    public class Account
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }

        public string AvatarUrl { get; set; } = "https://example.com/default-avatar.png";

        // Дополнительные свойства
        public string PhoneNumber { get; set; }
        public string ProfileImageUrl { get; set; }

        public Account Clone()
        {
            return new Account
            {
                Email = Email,
                Name = Name,
                BirthDate = BirthDate,
                Bio = Bio,
                PhoneNumber = PhoneNumber,
                ProfileImageUrl = ProfileImageUrl
            };
        }
    }
}