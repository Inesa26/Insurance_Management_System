using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_System
{
    internal class Menu
    { public static void RunHelloMessage() {
            Console.WriteLine("Hello!\n" +
            "Welcome to InsureEase App.\n" +
            "This application was created to effectively manage the data about insurance policies.\n" +
            "The available functionalities are: entering, viewing and editing data.\n" +
            "Press any key to continue.");
            Console.ReadKey();
        }

        public static int RunMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\tInsureEase Main Menu");
                Console.WriteLine("\t1. Manage Policies");
                Console.WriteLine("\t2. Manage Customers");
                Console.WriteLine("\t3. Manage Agents");
                Console.WriteLine("\t4. Exit");
                Console.Write("\tEnter your choice (1-4): ");

                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        public static int RunPolicyMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\tTravel Health Insurance Management System");
                Console.WriteLine("\t1. Create Policy");
                Console.WriteLine("\t2. View existing Policy");
                Console.WriteLine("\t3. Generate Report");
                Console.WriteLine("\t4. Return to Main Menu");
                Console.Write("\tEnter your choice (1-4): ");

                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public static int SelectTypeOfPolicyReport()
        {
            while (true)
            {

                Console.WriteLine("\n\t1. Generate Report for all Policies");
                Console.WriteLine("\t2. Generate Report for a specific Policy");
                Console.WriteLine("\t3. Return to Travel Health Insurance Management System");
                Console.Write("\tEnter your choice (1-3): ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }


        public static int RunCustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\tCustomer Management System");
                Console.WriteLine("\t1. Add new Customer");
                Console.WriteLine("\t2. View Customer details");
                Console.WriteLine("\t3. Update Customer details");
                Console.WriteLine("\t4. Delete Customer");
                Console.WriteLine("\t5. Generate Customer Report ");
                Console.WriteLine("\t6. Return to Main Menu");
                Console.Write("\tEnter your choice (1-6): ");

                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public static int RunAgentMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\tAgent Management System");
                Console.WriteLine("\t1. Add new Agent");
                Console.WriteLine("\t2. View Agent details");
                Console.WriteLine("\t3. Update Agent details");
                Console.WriteLine("\t4. Delete Agent");
                Console.WriteLine("\t5. Return to Main Menu");
                Console.Write("\tEnter your choice (1-5): ");

                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public static int PersonalDataEditing()
        {
            while (true)
            {
                Console.WriteLine("\n\t1. Edit name");
                Console.WriteLine("\t2. Edit surname");
                Console.WriteLine("\t3. Edit identification number");
                Console.WriteLine("\t4. Edit birthdate");
                Console.WriteLine("\t5. Edit address");
                Console.WriteLine("\t6. Edit phone number");
                Console.Write("\tEnter your choice (1-6): ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public static int ContinueDataEditing()
        {
            while (true)
            {
                Console.WriteLine("\n\t1. Modify the data of the present person");
                Console.WriteLine("\t2. Modify another person's data");
                Console.WriteLine("\t3. Return to Personal Data Editing Menu");
                Console.Write("\tEnter your choice (1-3): ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public static int SelectDestination()
        {
            while (true)
            {
                Console.WriteLine("\n\tPlease select a destination for the policy:");
                Console.WriteLine("\t1. CSI");
                Console.WriteLine("\t2. Europe");
                Console.WriteLine("\t3. World");
                Console.Write("\tEnter your choice (1-3): ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public static int SelectInsuredPerson()
        {
            while (true)
            {
                
                Console.WriteLine("\n\t1. Choose from the list of existing customers");
                Console.WriteLine("\t2. Add new Customer");
                Console.Write("\tEnter your choice (1-2): ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }


    } }
