using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhuk.University.Tachka.Core.Constants
{
    public enum StatusCode
    {
        UserNotFound = 0,
        UserAlreadyExists = 1,

        CarNotFound = 10,

        OK=200,
       InternalServerError=500
    }
}
