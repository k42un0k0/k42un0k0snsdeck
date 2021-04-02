using System.Configuration;

namespace K42un0k0SnsDeck.Constants
{
    public class AppConfig
    {
        public static AppConfig Singleton = new AppConfig();
        public virtual string TwitterApiSecretKey
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("TwitterApiSecretKey");
            }
        }
        public virtual string TwitterApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("TwitterApiKey");
            }
        }
        public virtual string TwitterAccessToken
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("TwitterAccessToken");
            }
        }
        public virtual string TwitterAccessTokenSecret
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("TwitterAccessTokenSecret");
            }
        }
        public virtual string TwitterCallbackUrl
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("TwitterCallbackUrl");
            }
        }
    }
}
