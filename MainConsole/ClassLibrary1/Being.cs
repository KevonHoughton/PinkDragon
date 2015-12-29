using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public abstract class Being
    {
        //Beings represent things one can interact with inside the game
        //Beings share certain characteristics, here are a few basic ones

        int _Turns;             //Turns taken today
        int _Level;
        int _ExperiencePoints;
        int _Strength;
        int _Dexterity;
        int _HealthPoints;
        int _ManaPoints;        //Magic juice for those that pursue magic
       

        //Beings can also DO things, again, here are a few basic ones

        //Some things are done differently between each sub-class, so you don't want to provide any implementation.
        //They are marked as abstract 
        public abstract bool Flee();

        //some things are done the same regardless, they're just methods with default behavior.  This behavior will be used for all sub-classes, unless overridden.  \
        //We're expecting some of this to be overridden, so we mark them as virtual. 
        public virtual bool Attack()
        {
            bool retValue= false;
            //do some logic 
            return retValue;
        }

        public virtual bool Rest()
        {
            bool retValue = true;
            //A simple heal that costs turn.
            return retValue;
        }

        //Some things we want to be the same regardless, so we don't want them to be overridden and we do not make them Virtual
        public int TakeDamage()
        {
            int retValue = _HealthPoints;
            //do some logic
            return retValue;
        }

        //some things can only happen at the main level
        private void Die()
        {
            // do some logic
        }
    }
}
