using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace Arena
{
    public class Arena
    {
        private Warrior warrior1;
        private Warrior warrior2;
        private Dice dice;
        private enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        public Arena(Warrior warrior1, Warrior warrior2, Dice dice)
        {
            this.warrior1 = warrior1;
            this.warrior2 = warrior2;
            this.dice = dice;
        }

        //static 
        private Direction ReadMovement(Direction movement)
        {
            if (KeyAvailable)
            {
                var key = ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    movement = Direction.Up;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    movement = Direction.Down;
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    movement = Direction.Left;
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    movement = Direction.Right;
                }
            }

            return movement;
        }
        private void Render()
        {
            Console.Clear();
            Console.WriteLine("-------------- Ринг -------------- \n");
            Console.WriteLine("Здоровье бойцов: \n");
            Console.WriteLine("{0} {1}", warrior1, warrior1.HealthBar());
            Console.WriteLine("{0} {1}", warrior2, warrior2.HealthBar());
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }

        public void Fight()
        {
            // The original order
            Warrior w1 = warrior1;
            Warrior w2 = warrior2;
            Console.WriteLine("Добро пожаловать в ринг!");
            Console.WriteLine("Сегодня {0} будет драться с {1}! \n", warrior1, warrior2);
            // swapping the warriors
            bool warrior2Starts = (dice.Roll() <= dice.GetSidesCount() / 2);
            if (warrior2Starts)
            {
                w1 = warrior2;
                w2 = warrior1;
            }
            Console.WriteLine("Боксер {0} начинает! \nПриступим к бою...", w1);
            Console.ReadKey();

            var currentMovement = Direction.Right;

            while (w1.Alive() && w2.Alive())
            {
                PrintMessage("Выберите направление!");

                var sw = Stopwatch.StartNew();
                while (sw.ElapsedMilliseconds <= 500)
                {
                    currentMovement = ReadMovement(currentMovement);
                }

                PrintMessage($"Направление {currentMovement}");

                switch (currentMovement)
                {
                    case Direction.Left:
                        if (w1.Alive())
                        {
                            w1.Attack(w2);
                            Render();
                            PrintMessage(w1.GetLastMessage()); // message about the attack
                            PrintMessage(w2.GetLastMessage()); // message about the defense
                        }
                        break;
                    case Direction.Right:
                        if (w2.Alive())
                        {
                            w2.Attack(w1);
                            Render();
                            PrintMessage(w2.GetLastMessage()); // message about the attack
                            PrintMessage(w1.GetLastMessage()); // message about the defense
                        }
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}