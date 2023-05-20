using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T data,bool success,string message):base(success,message) // base demek Result classı demek
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success) // mesaj vermedik base'in tek parametreli olanını çalıştır demek
        {
            Data = data;
        }
        public T Data { get; }
    }

  }

