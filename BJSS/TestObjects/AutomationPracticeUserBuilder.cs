namespace BJSS.TestObjects
{
    public class AutomationPracticeUserBuilder 
    {
        private readonly User _user;

        public AutomationPracticeUserBuilder()
        {
            _user = new User();
        }

        public AutomationPracticeUserBuilder HasAccount()
        {
            _user.Email = "katiecookson@hotmail.com";
            _user.Password = "BJSSTest";
            return this;
        }

        public AutomationPracticeUserBuilder HasNoAccount()
        {
            _user.Email = "noaccount@hotmail.com";
            _user.Password = "12345";
            return this;
        }

        public User Build()
        {
            return _user;
        }
    }
}
