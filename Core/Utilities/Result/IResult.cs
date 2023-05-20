using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public interface IResult

    {
        // get sadece okunabilir demek get al set yazdır!

        bool Success { get; }
        string Message { get; }


    }
}
