using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_System
{
    internal class Agent:Person
    {
        private static int lastAgentCode = 10000;
        private int agentCode;
   
        public Agent(string idnp, string name, string surname, DateTime birthdate, string address, string phoneNumber)
             : base(idnp, name, surname, birthdate, address, phoneNumber)
        {
            lastAgentCode++;
            this.agentCode = lastAgentCode;
        }

        public int AgentCode
        {
            get { return agentCode; }
        }

        public override string ToString()
        {
            return $" Agent Code: {agentCode},\n {base.ToString()}";
        }
    }
}
