using System;
using System.Net;
using System.Threading.Tasks;
using Camelotia.Services.Interfaces;

namespace Blank.Services
{
    public sealed class AppleAuthenticator : IAuthenticator
    {
        public YandexAuthenticationType YandexAuthenticationType => YandexAuthenticationType.Token;

        public Task<string> ReceiveYandexCode(Uri uri, IPAddress address, int port) => throw new PlatformNotSupportedException();

        public Task<string> ReceiveYandexToken(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}