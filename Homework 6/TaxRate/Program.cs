using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxRate
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            double salary = 0;
            bool salTest = false;
            double FedTaxesWithheld = 0;
            double FICAWithheld = 0;

            Console.WriteLine("Please input your name");
            name = Console.ReadLine();

            while (salTest != true)
            {
                Console.WriteLine("Please enter your salary");
                salTest = double.TryParse(Console.ReadLine(), out salary);
            }

            FedTaxesWithheld = CalculateFederalTax(salary);
            FICAWithheld = CalculateFICATax(salary);

            DisplayResults(name, salary, FedTaxesWithheld, FICAWithheld);
            
            Console.ReadKey();
        }

        static double CalculateFederalTax(double s)
        {
            
            double TaxRate = 0;
            if(s > 0 && s <= 9525)
            {
                TaxRate = .1;
            }
            else if (s > 9526 && s <= 38700)
            {
                TaxRate = .12;
            }
            else if (s > 38701 && s <= 82500)
            {
                TaxRate = .22;
            }
            else if (s > 82501 && s <= 157500)
            {
                TaxRate = .24;
            }
            else if (s > 157501 && s <= 200000)
            {
                TaxRate = .32;
            }
            else if (s > 200001 && s <= 500000)
            {
                TaxRate = .35;
            }
            else if (s > 500001)
            {
                TaxRate = .37;
            }
            double FedTaxesWithheld = TaxRate * s;
            return FedTaxesWithheld;
        }

        static double CalculateFICATax(double s)
        {
            double FICA = .062;
            double FICAWithheld = FICA * s;
            return FICAWithheld;
        }

        static void DisplayResults(string n, double s, double FedWithheld, double FICA)
        {
            double netSalary = s - FedWithheld - FICA;
            Console.WriteLine(n + "'s salary is " + s + ", they have a Federal Tax of " + FedWithheld + ", a FICA Tax of " + FICA + ", and a net salary of " + netSalary);
        }
    }
}
