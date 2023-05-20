using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>

    {

        public ErrorDataResult(T data, string message) : base(data, true, message) // base demek Result classı demek


        {

        }
        public ErrorDataResult(T data) : base(data, true) // mesaj vermedik base'in tek parametreli olanını çalıştır demek
        {



        }

        public ErrorDataResult(string message) : base(default, true, message) // base demek Result classı demek


        {

            // bir şey döndürmek istemiyorum ama mesaj vermek istiyorum o yüzden default verdim

        }
        public ErrorDataResult() : base(default, true) // mesaj vermedik base'in tek parametreli olanını çalıştır demek
        {

            // mesaj vermiyorum ve bir şey döndürmek istemiyorum o yüzden default verdim


        }
    }

 }
