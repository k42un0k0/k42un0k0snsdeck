using System;
using System.Configuration;
using System.IO;

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
        public virtual string FacebookAppId
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("FacebookAppId");
            }
        }
        public virtual string FacebookAppSecret
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("FacebookAppSecret");
            }
        }
        public virtual string FacebookCallbackUrl
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("FacebookCallbackUrl");
            }
        }

        public virtual string JsonPath
        {
            get
            {
                var fileName = ConfigurationManager.AppSettings.Get("JsonFile");
                System.Diagnostics.Debug.Print(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName));
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            }
        }
    }
}
