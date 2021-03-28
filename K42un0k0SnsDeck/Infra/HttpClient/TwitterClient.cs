
namespace K42un0k0SnsDeck.Infra.HttpClient
{
    public interface ITwitterClient
    {
        void ConfigureFromRedirectUrl(System.Uri redirectUrl);
        string GetAccountName();
        string GetIconPath();
    }

    public class TwitterClient : ITwitterClient
    {

        public void ConfigureFromRedirectUrl(System.Uri redirectUrl)
        {
            throw new System.NotImplementedException();
        }

        public string GetAccountName()
        {
            throw new System.NotImplementedException();
        }
        public string GetIconPath()
        {
            throw new System.NotImplementedException();
        }
    }
}
