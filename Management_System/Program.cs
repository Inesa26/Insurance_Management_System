
using Management_System;
using System;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;

class Program
{
    public static void Main(String[] args)
       
    { List<Customer> customers= new List<Customer>();
        Customer customer1 = new ("2001345821342", "Alina", "Bulan", new DateTime(1994, 08, 29), "Mircea cel Batran 28/1 ap.15", "+37379956852");
        Customer customer2 = new ("2005423588423", "Vlad", "Godorozea", new DateTime(2002, 07, 17), "Stefan cel Mare 196 ap.1", "+37378324785");
        Customer customer3 = new ("2004958489632", "Veaceslav", "Focsa", new DateTime(1995, 09, 27), "Grigore Vieru 206 ap.15", "+37379254863");
        customers.Add(customer1);
        customers.Add(customer2);
        customers.Add(customer3);
        List<Agent> agents = new List<Agent>();
        Agent agent1 = new ("2006524895214", "Veronica", "Snegur", new DateTime(1980, 01, 25), "Alexandru cel Bun 51 ap.20", "+37322457395");
        Agent agent2 = new ("2004782349621", "Diana", "Vasilache", new DateTime(1975, 06, 10), "Dacia 15 ap.6", "+37322624875");
        Agent agent3 = new ("2005124782436", "Ion", "Mazilu", new DateTime(1990, 02, 14), "Miron Costin 26 ap.101", "+37322254873");
        agents.Add(agent1);
        agents.Add(agent2);
        agents.Add(agent3);
        List<Policy> policies = new List<Policy>();
        policies.Add(new Policy(new DateTime(2023, 04, 11), new DateTime(2023, 04, 26), 7.52, 30000, Destination.EUROPE, customer1, agent1));
        policies.Add(new Policy(new DateTime(2023, 05, 01), new DateTime(2023, 05, 20), 19.8, 60000, Destination.WORLD, customer1, agent1));
        policies.Add(new Policy(new DateTime(2023, 07, 12), new DateTime(2023, 07, 15), 1.24, 10000, Destination.CSI, customer3, agent3));
        Policy.customers = customers;
        Policy.agents = agents;

        Menu.RunHelloMessage();
        while (true)
        {
            switch (Menu.RunMainMenu())
            {
                case 1:
                    bool backMenu = false;
                    do
                    {
                        switch (Menu.RunPolicyMenu())
                        {
                            case 1: policies.Add(Policy.CreatePolicy()); break;
                            case 2:
                                Policy.ViewPolicy(policies);
                                break;
                            case 3:
                                bool backPolicy = false;
                                do
                                {
                                    switch (Menu.SelectTypeOfPolicyReport())
                                    {
                                        case 1: Report.GeneratePoliciesReport(policies); break;
                                        case 2: Report.GeneratePolicyReport(Policy.FindByNumber(policies)); break;
                                        case 3: backPolicy = true; break;
                                        default: Console.WriteLine("The field with selected number doesn't exist. Please try again."); break;
                                    }
                                } while (!backPolicy);
                                break;
                            case 4: backMenu = true; break;
                            default:
                                Console.WriteLine("The field with selected number doesn't exist. Please try again.");
                                break;
                        } } while (!backMenu) ;
                        break;
                case 2:
                    bool toMain = false;
                    do
                    {
                        switch (Menu.RunCustomerMenu())
                        {
                            case 1:
                                customers.Add(Person.CreatePerson<Customer>());
                                break;
                            case 2:
                                Person.ViewPerson(customers);
                                break;
                            case 3: Customer person = Person.FindByIdnp(customers);
                                Person.UpdatePerson(person);
                                bool correctNr = false; ;
                                do
                                { 
                                    switch (Menu.ContinueDataEditing())
                                    {
                                        case 1:
                                            Person.UpdatePerson(person);
                                            break;
                                        case 2:
                                            Person.UpdatePerson(Person.FindByIdnp(customers));
                                            break;
                                        case 3:
                                            correctNr = true;
                                            break;
                                        default:
                                            Console.WriteLine("The field with selected number doesn't exist. Please try again.");
                                            break;
                                    }
                                } while (!correctNr);
                                break;
                            case 4:
                                Person.DeletePerson(customers);
                                break;
                            case 5:
                                 Report.GenerateCustomerReport(Person.FindByIdnp(customers), policies); break;
                                        
                            case 6: toMain = true; break;
                            default: Console.WriteLine("The field with selected number doesn't exist. Please try again."); break;
                        }
                    } while (!toMain);
                    break;
                case 3:
                    bool backMain = false;
                    do
                    {
                        switch (Menu.RunAgentMenu())
                        {
                            case 1:
                                agents.Add(Person.CreatePerson<Agent>());
                                break;
                            case 2:
                                Person.ViewPerson(agents);
                                break;
                            case 3:
                                Agent person = Person.FindByIdnp(agents);
                                Person.UpdatePerson(person);
                                bool correctNr = false; ;
                                do
                                {
                                    switch (Menu.ContinueDataEditing())
                                    {
                                        case 1:
                                            Person.UpdatePerson(person);
                                            break;
                                        case 2:
                                            Person.UpdatePerson(Person.FindByIdnp(agents));
                                            break;
                                        case 3:
                                            correctNr = true;
                                            break;
                                        default:
                                            Console.WriteLine("The field with selected number doesn't exist. Please try again.");
                                            break;
                                    }
                                } while (!correctNr);
                                break;
                            case 4:
                                Person.DeletePerson(agents);
                                break;
                            case 5: backMain = true; break;
                            default: Console.WriteLine("The field with selected number doesn't exist. Please try again."); break;
                        }
                    } while (!backMain); break;
                case 4: Console.WriteLine("Exiting..."); return;
                default: Console.WriteLine("Invalid choice. Please try again."); break;
            }
        }

    }
}