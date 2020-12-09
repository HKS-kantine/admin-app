using AdminAuth;
using AdminEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminFactory
{
    public class AuthFactory
    {
        public static IAuth GetAuth()
        {
            return new AuthController();
        }
    }
}
