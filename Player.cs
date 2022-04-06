using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Casino
{
    class Player
    {
        private string name;
        private float balance;
        public Player(string name, float balance)
        {
            this.name = name;
            this.balance = balance;
        }
        public string Name
        {
            get { return name; }
        }
        public float Balance
        {
            get { return balance; }
        }
        public void updateBalance(float amount, char sign)
        {
            if (sign == '-')
            {
                this.balance -= amount;
            }
            else
            {
                this.balance += amount;
            }
        }
    }
}
