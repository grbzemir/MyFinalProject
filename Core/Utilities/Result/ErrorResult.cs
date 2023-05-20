using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class ErrorResult:Result

    {

        public ErrorResult(string message) : base(false, message) // base demek Result classı demek


        {


        }

        public ErrorResult() : base(false) // mesaj vermedik base'in tek parametreli olanını çalıştır demek

        {



        }
    }
}
