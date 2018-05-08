using Microsoft.Identity.Client;
using System.Configuration;
using System.Windows;

namespace active_directory_b2c_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string Tenant = ConfigurationManager.AppSettings["B2CTenant"];
        private static string ClientId = ConfigurationManager.AppSettings["ClientId"];
        public static string PolicySignUpSignIn = ConfigurationManager.AppSettings["PolicySignUpSignIn"];
        public static string PolicyEditProfile = ConfigurationManager.AppSettings["PolicyEditProfile"];
        public static string PolicyResetPassword = ConfigurationManager.AppSettings["PolicyResetPassword"];

        public static string[] ApiScopes =  ConfigurationManager.AppSettings["ApiScopes"].Split(',');
        public static string ApiEndpoint = ConfigurationManager.AppSettings["ApiEndpoint"];

        private static string BaseAuthority = "https://login.microsoftonline.com/tfp/{tenant}/{policy}/oauth2/v2.0/authorize";
        public static string Authority = BaseAuthority.Replace("{tenant}", Tenant).Replace("{policy}", PolicySignUpSignIn);
        public static string AuthorityEditProfile = BaseAuthority.Replace("{tenant}", Tenant).Replace("{policy}", PolicyEditProfile);
        public static string AuthorityResetPassword = BaseAuthority.Replace("{tenant}", Tenant).Replace("{policy}", PolicyResetPassword);

        private static PublicClientApplication _clientApp = new PublicClientApplication(ClientId, Authority, TokenCacheHelper.GetUserCache());
        
        public static PublicClientApplication PublicClientApp { get { return _clientApp; } }
    }
}
