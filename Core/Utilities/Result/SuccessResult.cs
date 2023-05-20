using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class SuccessResult:Result

    {

        public SuccessResult(string message) : base(true, message) // base demek Result classı demek
        
        
        {
        
        }

        public SuccessResult() : base(true) // mesaj vermedik base'in tek parametreli olanını çalıştır demek

        {



        }
    }
}
