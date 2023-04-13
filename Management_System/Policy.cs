using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Management_System
{
    internal class Policy
    {
        public static List<Customer> customers;
        public static List<Agent> agents;
        private static int lastPolicyNumber = 2000000000;
        private int policyNumber;
        private DateTime startDate;
        private DateTime endDate;
        private double premiumAmount;
        private Destination destination;
        private int insuranceSum;
        private Customer insuredPerson;
        private Agent agent;

        public Policy() { }
        public Policy(DateTime startDate, DateTime endDate, double premiumAmount, int insuranceSum, Destination destination, Customer insuredPerson, Agent agent)
        {
            lastPolicyNumber++;
            policyNumber = lastPolicyNumber;
            this.startDate = startDate;
            this.endDate = endDate;
            this.premiumAmount = premiumAmount;
            this.insuranceSum = insuranceSum;
            this.destination = destination;
            this.insuredPerson = insuredPerson;
            this.agent = agent;
        }

        public int PolicyNumber
        {
            get { return policyNumber; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
        }

        public double PremiumAmount
        {
            get { return premiumAmount; }
        }

        public Destination Destination
        {
            get { return destination; }
        }

        public int InsuranceSum
        {
            get { return insuranceSum; }
        }

        public Customer InsuredPerson
        {
            get { return insuredPerson; }
        }

        public Agent Agent
        {
            get { return agent; }
        }



        public static Policy CreatePolicy()
        {
            Console.WriteLine("\nEnter start date:");
            DateTime startDate = SetDate();
            Console.WriteLine("\nEnter end date:");
            DateTime endDate = SetDate();
            Console.WriteLine("\nAdd the Insured Person:");
            Customer insuredPerson = SetInsuredPerson(customers);
            Console.WriteLine("\nAdd the policy issuer,");
            Agent agent = SetAgent(agents);
            Destination destination = SetDestination();
            int insuranceSum = destination.GetInsuranceSum();
            double tariff = destination.GetTariff();
            double premiumAmount = CalculatePremium(startDate, endDate, tariff);
            Policy newPolicy = new Policy(startDate, endDate, premiumAmount, insuranceSum, destination, insuredPerson, agent);
            Console.WriteLine("The new policy has been successfully saved!");
            return newPolicy;
        }

        public static DateTime SetDate()
        {
            Console.WriteLine("Make shure that the format is dd/MM/yyyy (e.g. 31/12/1990)");
            Regex reg = new Regex(@"^\d{2}/\d{2}/\d{4}$");
            string date = Console.ReadLine();
            while (!reg.IsMatch(date))
            {
                Console.WriteLine("Date written incorrectly. Please write it again");
                date = Console.ReadLine();
            }
            return DateTime.Parse(date);
        }

        public static Destination SetDestination()
        {
            bool isValidSelection = false;
            Destination destination = Destination.CSI;

            while (!isValidSelection)
            {
                int selection = Menu.SelectDestination();
                switch (selection)
                {
                    case 1:
                        destination = Destination.CSI;
                        isValidSelection = true;
                        break;
                    case 2:
                        destination = Destination.EUROPE;
                        isValidSelection = true;
                        break;
                    case 3:
                        destination = Destination.WORLD;
                        isValidSelection = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please select again.");
                        break;
                }
            }

            return destination;
        }

        public static Customer SetInsuredPerson(List<Customer> customers)
        {
            Customer insuredPerson = null;
            bool isValidSelection = false;
            while (!isValidSelection)
            {
                int selection = Menu.SelectInsuredPerson();
                switch (selection)
                {
                    case 1:
                        insuredPerson = Person.FindByIdnp(customers);
                        isValidSelection = true;
                        break;
                    case 2:
                        insuredPerson = Person.CreatePerson<Customer>();
                        customers.Add(insuredPerson);
                        isValidSelection = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please select again.");
                        break;
                }
            }
            return insuredPerson;
        }

        public static Agent SetAgent(List<Agent> agents)
        {
            Agent agent = Person.FindByIdnp(agents);
            return agent;
        }

        public static double CalculatePremium(DateTime startDate, DateTime endDate, double tariff)
        {
            int numberOfDays = (int)(endDate - startDate).Days + 1;
            double premiumAmount = numberOfDays * tariff;
            return premiumAmount;
        }
        public static void ViewPolicy(List<Policy> policies)
        {
            Policy toView = FindByNumber(policies);
            if (toView == null)
            {
                Console.WriteLine("Data cannot be displayed. There is no policy with that number.");
            }
            else
            {
                Console.WriteLine(toView.ToString());
            }
        }

        public static Policy FindByNumber(List<Policy> policies)
        {
            Policy found = null;
            Console.WriteLine("Enter policy number");
            Regex reg = new Regex(@"^2\d{9}$");
            string number = Console.ReadLine();
            int parsedNumber = int.Parse(number);
            while (!reg.IsMatch(number))
            {
                Console.WriteLine("Policy number written incorrectly. Please write it again");
                number = Console.ReadLine();

            }
            foreach (Policy policy in policies)
            {
                if (policy.policyNumber == parsedNumber)
                {
                    found = policy;
                    break;
                }
            }
            return found;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Policy Information:\n");
            sb.AppendLine($"Policy number: {policyNumber}");
            sb.AppendLine($"Insured person: {insuredPerson}");
            sb.AppendLine($"Start date: {startDate.ToShortDateString()}");
            sb.AppendLine($"End date: {endDate.ToShortDateString()}");
            sb.AppendLine($"Destination: {destination}");
            sb.AppendLine($"Insurance sum: {insuranceSum} EUR");
            sb.AppendLine($"Premium amount: {premiumAmount} EUR");
            sb.AppendLine($"Agent: {agent.AgentCode}");
            return sb.ToString();
        }
    }
}

