using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Player : Being  //we say that a Player derives from (is a) Being 
    {
        //Since the Flee method is Abstract, we have to implement it, or it will not compile.
        public override bool Flee()
        {
            throw new NotImplementedException();
        }

        public override bool Attack()
        {
            bool retValue = true;
            //all of our players automatically hit every time, so we're going to override the base value and return our own.
            //obviously this will not work so well in an actual implementation.  Let's figure out some logic later.
            return retValue;
        }
    }
}
