using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.Objects
{
    class Arena
    {
        //variables which exist for the the life of the object are defined here
        //"Scope" is defined  by {} and is why we indent every time we use a new set of {}
        #region Private Class Variables
        string _Name;  // Madison Square Gardens for example
        List<Being> _arenaAgressorList;
        List<Being> _arenaDefenderList;
        bool _isValid = true;
        #endregion

        //This is the constructor, it has no return type defined
        public Arena(List<Being> agressorList, List<Being> defenderList)
        {
            if (_arenaAgressorList == null || _arenaAgressorList.Count < 1)
            {
                Console.WriteLine("You forgot to show up for the fight, apparently.");
                _isValid = false;
            }
            if (_arenaDefenderList == null || _arenaDefenderList.Count < 1)
            {
                Console.WriteLine("Nobody showed, Max.  The girl didn't show, the guy didn't show.  Nobody showed.");
                _isValid = false;
            }

            if (agressorList.Any(b => b.Turns < 1))
            {
                _isValid = false;
                Console.WriteLine("Someone on your team is out of turns for today and may not participate in the fight.");
            }


            if (agressorList.Any(b => b.CurrentHealthPoints < 1))
            {
                Console.WriteLine("Somone is too weak to fight!");
                _isValid = false;
            }

            bool isDuel = false; //This variable will not be available outside of the constructor
            isDuel = _arenaAgressorList.Count == 1 && _arenaDefenderList.Count == 1; //== is a comparison operator, it returns true or false. &&  means "And"

            if (!isDuel)
            {
                Console.WriteLine("Brawling is outlawed!  You have been ejected from the arena");
                _isValid = false;
            }

            if (!_isValid)
                return;

            //Everything is ok, so we can proceed.
            _arenaAgressorList = agressorList; //_arenaAgressorList was defined at a "higher" level and is accessible here
            _arenaDefenderList = defenderList; // = is the assignment operator.  We are telling Arena to assign the values passed in to the class variables

        }

        public void Fight()
        {
            if (!_isValid)
            {
                Console.WriteLine("We already told you, there's nothing to do here");
                return; 
            }

            //FIGHT!

            //Figure out Initiave
            Being first;
            Being second;
            if (_arenaAgressorList[0].Initiave > _arenaDefenderList[0].Initiave)
            {
                first = _arenaAgressorList[0];
                second = _arenaDefenderList[0];
            }
            else
            {
                second = _arenaAgressorList[0];
                first = _arenaDefenderList[0];
            }
            //First person goes first
            if (first.Attack(second))
            {
                int hpLeft = second.TakeDamage(first.DoDamage());
                if (hpLeft < 1)
                {
                    second.Die();

                }
            }            
        }
    }
}
