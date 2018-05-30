using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BusinessLogic
{
    public class AuthorizationTokenVerifier
    {
        private Dictionary<TokenScope, string> ScopeToTokenMap { get; }

        public AuthorizationTokenVerifier()
        {
            ScopeToTokenMap = new Dictionary<TokenScope, string>
            {
                { TokenScope.LOGIN, Constants.LOGIN },
                { TokenScope.REGISTER, Constants.REGISTER },
                { TokenScope.TAX, Constants.TAX },
                { TokenScope.FINE, Constants.FINE },
                { TokenScope.VEHICLE_REGISTRATION, Constants.VEHICLE_REGISTRATION },
                { TokenScope.TRANSFER, Constants.Transfer }

            };
        }

        public bool VerifyToken(TokenScope Scope, String token)
        {
            string Token = ScopeToTokenMap[Scope];
            return token == Token;
        }
    }
}
