using sel_12.Utils;

namespace sel_12.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User
    {
        public string TaxId { get; set; }

        public string Company { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MainAddress { get; set; }

        public string AdditionalAddress { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        private string _userName;

        public string UserName
        {
            get => _userName.IsNullOrEmpty() ? Email : _userName;
            set => _userName = value;
        }

        public string Password { get; set; }

        public bool SubscribedToNewsletter { get; set; }

        public User()
        {
        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public static User RandomizeUser()
        {
            return new User
            {
                TaxId = RandomUtils.RandomNumericWord(4),
                Company = RandomUtils.RandomEnglishWord(10),
                Country = "United States",
                Email = RandomUtils.RandomEmail(),
                MainAddress = RandomUtils.RandomEnglishWord(10),
                AdditionalAddress = RandomUtils.RandomEnglishWord(10),
                City = RandomUtils.RandomEnglishWord(10),
                FirstName = RandomUtils.RandomEnglishWord(5),
                LastName = RandomUtils.RandomEnglishWord(10),
                PostCode = RandomUtils.RandomNumericWord(5),
                Phone = RandomUtils.RandomNumericWord(10),
                Password = RandomUtils.RandomEnglishWord(10)
            };
        }
    }
}
