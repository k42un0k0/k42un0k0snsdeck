using System;

namespace K42un0k0SnsDeck.Usecases
{
    public interface ICreateAccountWhenOAuthUsecase
    {
        public void exec(Uri redirectUrl);
    }
}
