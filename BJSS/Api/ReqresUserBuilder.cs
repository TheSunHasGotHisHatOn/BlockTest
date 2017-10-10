using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJSS.Api
{
    public class ReqresUserBuilder
    {
        private readonly User _user;

        public ReqresUserBuilder()
        {
              _user = new User();  
        }

        public ReqresUserBuilder HasNonEnglishUnicodeCharacter()
        {
            _user.Avatar = "myAvatar";
            _user.FirstName = "Lula";
            _user.LastName = "Paloösa";
            return this;
        }

        public ReqresUserBuilder HasEscapeCharacter()
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
