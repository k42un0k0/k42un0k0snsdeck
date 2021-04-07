using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace K42un0k0SnsDeck.Views.OAuthContext
{
    public enum OAuthProviderEnum
    {
        Twitter,
        Facebook,
    }
    public class OAuthContextProvider
    {
        [Dependency]
        public IContainerProvider Container { get; set; }

        public IOAuthContext GetContext(OAuthProviderEnum oauthProviderEnum)
        {
            switch (oauthProviderEnum)
            {
                case OAuthProviderEnum.Twitter:
                    return Container.Resolve<TwitterOAuthContext>();
                case OAuthProviderEnum.Facebook:
                    return Container.Resolve<FacebookOAuthContext>();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
