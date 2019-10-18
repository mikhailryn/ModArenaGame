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
    class Program
    {
        static void Main(string[] args)
        {
            // creating objects
            Dice dice = new Dice(10);
            Warrior zalgoren = new Warrior("Zalgoren", 100, 20, 10, dice);
            Warrior shadow = new Warrior("Shadow", 60, 18, 15, dice);
            Arena arena = new Arena(zalgoren, shadow, dice);
            // fight
            arena.Fight();
            Console.ReadKey();
        }
    }
}
