using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventura.PublicApi.Util.AuthEndpoints
{
    public class UserInfo
    {
        public static readonly UserInfo Anonymous = new UserInfo();
        public bool IsAuthenticated { get; set; }
        public string NameClaimType { get; set; }
        public string RoleClaimType { get; set; }
        public IEnumerable<ClaimValue> Claims { get; set; }
    }
}