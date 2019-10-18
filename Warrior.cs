using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arena
{

   public class Warrior
    {

        private string name;

        private int health;
   
        private int maxHealth;
  
        private int damage;
       
        private int defense;
   
        private Dice dice;
     
        private string message;

 
        /// <param name="name">Warrior's name</param>
        /// <param name="health">Health in HP</param>
        /// <param name="damage">Damage in HP</param>
        /// <param name="defense">Defense in HP</param>
        /// <param name="dice">Dice instance</param>
        public Warrior(string name, int health, int damage, int defense, Dice dice)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.damage = damage;
            this.defense = defense;
            this.dice = dice;
        }

        public override string ToString()
        {
            return name;
        }


        public bool Alive()
        {
            return (health > 0);
        }

        public string HealthBar()
        {
            string s = "[";
            int total = 20;
            double count = Math.Round(((double)health / maxHealth) * total);
            if ((count == 0) && (Alive()))
                count = 1;
            for (int i = 0; i < count; i++)
                s += "#";
            s = s.PadRight(total + 1);
            s += "]";
            return s;
        }

        /// <param name="enemy">Enemy instance</param>
        public void Attack(Warrior enemy)
        {
            int hit = damage + dice.Roll();
            SetMessage(String.Format("{0} attacks with {1} hp hit", name, hit));
            enemy.Defend(hit);
        }

        /// <param name="hit">Hit power in HP</param>
        public void Defend(int hit)
        {
            int injury = hit - (defense + dice.Roll());
            if (injury > 0) // Injured
            {
                health -= injury;
                message = String.Format("{0} got an injury of {1} hp", name, injury);
                if (health <= 0)
                {
                    health = 0;
                    message += " and died";
                }
            }
            else // No damage taken
                message = String.Format("{0} parried a hit", name);
            SetMessage(message);
        }

        /// <param name="message">User message about last action</param>
        private void SetMessage(string message)
        {
            this.message = message;
        }

        public string GetLastMessage()
        {
            return message;
        }

    }
}
