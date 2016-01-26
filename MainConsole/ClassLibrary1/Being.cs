using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Objects
{
    public abstract class Being
    {
        //Beings represent things one can interact with inside the game
        //Beings share certain characteristics, here are a few basic ones

        string Name;
        public int Turns;
        public int Level;
        public int ExperiencePoints;
        public int Strength;
        public int Dexterity;
        public int MaxHealthPoints;
        public int CurrentHealthPoints;
        public int MaxManaPoints;
        public int CurrentManaPoints;        //Magic juice for those that pursue magic
        public int Initiave { get { return Dexterity + Dice.d6(); } private set { } }



        //Beings can also DO things, again, here are a few basic ones

        //Some things are done differently between each sub-class, so you don't want to provide any implementation.
        //They are marked as abstract 
        public abstract bool Flee();

        //some things are done the same regardless, they're just methods with default behavior.  This behavior will be used for all sub-classes, unless overridden.  \
        //We're expecting some of this to be overridden, so we mark them as virtual. 
        public virtual bool Attack(Being targetBeing)
        {
            int target = 11;
            int modtarget = target + ((Dexterity - targetBeing.Dexterity) / 3);
            bool retValue = false;

            // Roll 11 or less on 3d6 + ( targetBeing.Dexterity - Dexterity ) / 3

            int actualroll = Dice.d6() + Dice.d6() + Dice.d6();
            Console.WriteLine("To hit, ", Name, " wanted to roll 11 or less {", modtarget, " modifier}");
            Console.WriteLine(Name, " rolled ", actualroll);
            if (actualroll <= modtarget)
            {
                Console.WriteLine(Name, " hit!");
                retValue = true;
            }
            else
            {
                Console.WriteLine(Name, " missed!");
                retValue = false;
            }
       
            //do some logic 
            return retValue;
        }

        

        //Some things we want to be the same regardless, so we don't want them to be overridden and we do not make them Virtual
        public int TakeDamage(int damageDone)
        {
            //TODO: Think about damage mitigating features?  Armor??
            CurrentHealthPoints -= damageDone;
            //do some logic
            return CurrentHealthPoints;
        }

        public int DoDamage()
        {
            int retValue = 0;
            
            switch(Strength)
            {
                case 18:
                    retValue += 3;
                    break;
                case 17:
                    retValue += 2;
                    break;
                case 16:
                case 15:
                    retValue += 1;
                    break;
                case 6:
                case 5:
                    retValue -= 1;
                    break;
                case 4:
                    retValue -= 2;
                    break;
                case 3:
                    retValue -= 3;
                    break;
                default:
                    retValue = 0;
                    break;
                    // Melee damage is d4 for now 
            }
            retValue += Dice.d4();

            return retValue;
        }

        public void Die()
        {
            // do some logic
        }
    }
}
