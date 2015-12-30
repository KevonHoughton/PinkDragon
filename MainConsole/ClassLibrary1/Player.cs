using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Objects
{
    class Player : Being  //we say that a Player derives from (is a) Being 
    {
        //Since the Flee method is Abstract, we have to implement it, or it will not compile.
        public override bool Flee()
        {
            throw new NotImplementedException();
        }

    }
}
