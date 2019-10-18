using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    /*
     *       _____ _____ _____                _       _
     *      |_   _/  __ \_   _|              (_)     | |
     *        | | | /  \/ | |  ___  ___   ___ _  __ _| |
     *        | | ||      | | / __|/ _ \ / __| |/ _` | |
     *       _| |_| \__/\ | |_\__ \ (_) | (__| | (_| | |
     *      |_____\_____/ |_(_)___/\___/ \___|_|\__,_|_|
     *                   ___
     *                  |  _|___ ___ ___
     *                  |  _|  _| -_| -_|  LICENCE
     *                  |_| |_| |___|___|
     *
     * IT NEWS  <>  PROGRAMMING  <>  HW & SW  <>  COMMUNITY
     *
     * This source code is part of online courses at IT social
     * network WWW.ICT.SOCIAL
     *
     * Feel free to use it for whatever you want, modify it and share it but
     * don't forget to keep this link in code.
     *
     * For more information visit http://www.ict.social/licences
     */

    /// <summary>
    /// Class represents a dice for board game
    /// </summary>
   public class Dice
    {
        /// <summary>
        /// Random number generator
        /// </summary>
        private Random random;
        /// <summary>
        /// Number of dice sides
        /// </summary>
        private int sidesCount;

        /// <summary>
        /// Initializes new 6-sided dice instance
        /// </summary>
        public Dice()
        {
            sidesCount = 6;
            random = new Random();
        }

        /// <summary>
        /// Initializes new dice instance
        /// </summary>
        /// <param name="sidesCount">Number of dice sides</param>
        public Dice(int sidesCount)
        {
            this.sidesCount = sidesCount;
            random = new Random();
        }

        /// <summary>
        /// Returns a number of the dice sides
        /// </summary>
        /// <returns>Number of dice sides</returns>
        public int GetSidesCount()
        {
            return sidesCount;
        }

        /// <summary>
        /// Rolls a dice
        /// </summary>
        /// <returns>A number from 1 to sides count</returns>
        public int Roll()
        {
            return random.Next(1, sidesCount + 1);
        }

        /// <summary>
        /// Returns text representation of our dice
        /// </summary>
        /// <returns>Text representation of the dice</returns>
        public override string ToString()
        {
            return String.Format("Dice with {0} sides", sidesCount);
        }
    }
}
