using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_System
{
    internal class Report
    {

        public static void GenerateCustomerReport(Customer customer, List<Policy> policies)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\Inesa Godorozea\\source\\repos\\Management_System\\Management_System\\CustomerReport.txt"))
                {    
                    StringBuilder report = new StringBuilder();
                    sw.WriteLine("\tCustomer data:");
                    report.AppendLine(customer.ToString());
                    report.AppendLine("\n\tPolicies:\n");
                    bool found = false;
                    foreach (Policy policy in policies)
                    {
                        if (policy.InsuredPerson.Idnp == customer.Idnp)
                        {
                            found = true;
                            report.AppendLine($"Policy number: {policy.PolicyNumber}");
                            report.AppendLine($"Start date: {policy.StartDate.ToString("dd/MM/yyyy")}");
                            report.AppendLine($"End date: {policy.EndDate.ToString("dd/MM/yyyy")}");
                            report.AppendLine($"Premium amount: {policy.PremiumAmount} EUR");
                            report.AppendLine($"Destination: {policy.Destination}");
                            report.AppendLine($"Insurance sum: {policy.InsuranceSum} EUR");
                            report.AppendLine($"Agent: {policy.Agent.Name} {policy.Agent.Surname}, Code: {policy.Agent.AgentCode}");
                            report.AppendLine();
                        }
                    }
                    if (!found)
                    {
                        report.AppendLine("This customer has no policies.");
                    }
                   
                    sw.WriteLine(report.ToString());
                    sw.Close();
                    Console.WriteLine("\nCustomer Report created successfully!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAn error occurred while creating the customers file: " + e.Message);
            }
        }


        public static void GeneratePoliciesReport(List<Policy> policies)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\Inesa Godorozea\\source\\repos\\Management_System\\Management_System\\PoliciesReport.txt"))
                {
                    sw.WriteLine("\tList of Policies:\n");
                    foreach (Policy p in policies)
                    {
                        sw.WriteLine(p.ToString());
                    }
                    sw.Close();
                }
                Console.WriteLine("\nPolicies Report created successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAn error occurred while creating the policies file: " + e.Message);
            }
        }

        public static void GeneratePolicyReport(Policy policy)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("C:\\Users\\Inesa Godorozea\\source\\repos\\Management_System\\Management_System\\PolicyReport.txt"))
                {
                    sw.WriteLine(policy.ToString());
                    sw.Close();
                    Console.WriteLine("\nPolicy Report created successfully!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAn error occurred while creating the customers file: " + e.Message);
            }
        }

    }
}
