using System.Configuration;

namespace BJSS.TestObjects
{
    public class AppSettings
    {
        public static string CreateUserPathTemplate
        {
            get { return ConfigurationManager.AppSettings["CREATE_USER_PATH_TEMPLATE"]; }
        }

        public static string GetUserPathTemplate
        {
            get { return ConfigurationManager.AppSettings["GET_USER_PATH_TEMPLATE"]; }
        }

        public static string UpdateUserPathTemplate
        {
            get { return ConfigurationManager.AppSettings["UPDATE_USER_PATH_TEMPLATE"]; }
        }

        public static string DeleteUserPathTemplate
        {
            get { return ConfigurationManager.AppSettings["DELETE_USER_PATH_TEMPLATE"]; }
        }

        public static int TimeoutInSeconds
        {
            get { return int.Parse(ConfigurationManager.AppSettings["SECONDS_TIMEOUT"]); }
        }

        public static string ReqresBaseUri
        {
            get { return ConfigurationManager.AppSettings["REQRES_BASE_URI"]; }
        }

        public static string AutomationPracticeBaseUri
        {
            get { return ConfigurationManager.AppSettings["AUTOMATION_PRACTICE_BASE_URI"]; }
        }

        public static string HomepageTitle
        {
            get { return ConfigurationManager.AppSettings["HOMEPAGE_TITLE"]; }
        }

        public static string LoginpageTitle
        {
            get { return ConfigurationManager.AppSettings["LOGINPAGE_TITLE"]; }
        }

        public static string MyaccountpageTitle
        {
            get { return ConfigurationManager.AppSettings["MYACCOUNTPAGE_TITLE"]; }
        }
    }
}
