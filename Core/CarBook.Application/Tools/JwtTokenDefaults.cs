using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer= "https://localhost";
        public const string Key= "CarBookAracKiralama!??1020304050.";
        public const int Expire = 3;

    }
}
