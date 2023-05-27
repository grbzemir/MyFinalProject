using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        // Diğer kod parçacıklarının bu yönteme erişimine izin verildiği varsayılarak public erişilebilirlik seviyesi kullanıldı.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }

}
