using System;
using Cares.Interfaces.Security;

namespace Cares.WebBase.Mvc
{
    public sealed class WebApiAuthenticationChecker : IWebApiAuthenticationChecker
    {
        public WebApiAuthenticationChecker()
        {
            
        }
        public bool Check(string userName, string password)
        {
            return true;
        }
    }
}
