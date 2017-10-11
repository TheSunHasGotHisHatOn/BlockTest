namespace BJSS.ReqresApi
{
    public class UserBuilder
    {
        private readonly User _user;

        public UserBuilder()
        {
              _user = new User();  
        }

        public UserBuilder HasNonEnglishUnicodeCharacter()
        {
            _user.Avatar = "myAvatar";
            _user.FirstName = "Lula";
            _user.LastName = "Paloösa";
            return this;
        }

        public UserBuilder HasEscapeCharacter()
        {
            _user.Avatar = "myAvatar";
            _user.FirstName = @"Lula\";
            _user.LastName = "Paloosa";
            return this;
        }

        public User Build()
        {
           return _user;
        }
    }
}
