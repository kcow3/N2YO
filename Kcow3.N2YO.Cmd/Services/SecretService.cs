using Microsoft.Extensions.Options;
using System;

namespace Kcow3.N2YO.Cmd.Services
{
    public class SecretService : ISecretService
    {
        private readonly Secret _secret;

        public SecretService(IOptions<Secret> secret)
        {
            // We want to know if secrets is null so we throw an exception if it is
            _secret = secret.Value ?? throw new ArgumentNullException(nameof(secret));
        }

        public string GetApiKey()
        {
            return _secret.ApiKey;
        }
    }
}
